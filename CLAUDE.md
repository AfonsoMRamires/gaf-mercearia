# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

GAF — VB.NET WinForms desktop app for a mercearia (grocery/food-bank) client registry
and stock management. Windows-only: .NET Framework 4.7.2 + SQL Server LocalDB. Single
project (`GAF/GAF.vbproj`), single solution (`GAF.sln`), no test project exists.

## Build / run

Windows only (LocalDB + WinForms). From a Developer Command Prompt or PowerShell:

```powershell
nuget restore GAF.sln
msbuild GAF.sln /p:Configuration=Release /p:Platform="Any CPU"
GAF\bin\Release\GAF.exe
```

Or open `GAF.sln` in Visual Studio 2022 (.NET desktop development workload) and
F5/Ctrl+F5. CI (`.github/workflows/build.yml`) runs the same msbuild build on
`windows-latest` and uploads the `GAF-Release` output as an artifact.

No test suite exists — there is nothing to run beyond a successful build.

### Database is required before the app runs

`GAF.mdf`/`GAF_log.ldf` are gitignored and not in the repo (`CopyToOutputDirectory=Always`
copies them into the build output). The app auto-creates `Artigos` and `Entregas` on
startup (`Stock.EnsureSchema`) but does **not** create `Utentes` — that table must
already exist in whatever `GAF.mdf` you supply. See `RUN.md` for full setup
(LocalDB install, column list/types for `Utentes`, troubleshooting table).

Key gotcha from `RUN.md`: `Utentes.AddUtente` does `INSERT INTO Utentes VALUES (...)`
with no column list, so the physical column order in the table must match the order
of parameters in `Utentes.vb`'s `AddUtente`. Prefer `DATE` over `DATETIME` for date
columns (unset dates write as `1900-01-01`, which `DATETIME` also accepts but `DATE`
avoids min-value edge cases entirely).

## Architecture

Three-layer split, all in the single `GAF` project:

- **Forms** (`UtentesScreen.vb`, `StockScreen.vb`, `PesquisaUtenteModal.vb` +
  their `.Designer.vb`/`.resx` pairs) — UI only, calls into the service classes below.
- **Service classes** (`Utentes.vb`, `Stock.vb`) — one per domain table, each owns
  its own `*Obj` data-holder class (e.g. `Utentes.UtentesObj`, `Stock.ArtigoObj`,
  `Stock.EntregaObj`) and CRUD methods. Not static/shared (except `Stock.EnsureSchema`
  and CRUD are called on instances) — forms instantiate the service class directly.
- **`GAFDataBase.vb`** — single source of the connection string (reads
  `App.config`'s `GAF.My.MySettings.GAFConnectionString`) and a `NewConnection()`
  factory. Every service method still opens its own `Using`-scoped `SqlConnection`
  rather than sharing one — follow that pattern for new DB code.

### Conventions used throughout the service layer

- Every CRUD method returns `Boolean` and takes `ByRef Message As String` for the
  user-facing outcome/error text (in Portuguese) — not exceptions. Callers check the
  boolean, not try/catch. Follow this signature shape for new service methods.
- All SQL uses parameterized `SqlCommand` + `AddWithValue` — never string-concatenate
  user input into SQL.
- All DB errors are caught, written to `Message`, and also logged via
  `AppLogger.Error(context, ex)`; the exception is swallowed, not rethrown.
- Multi-statement writes that must be atomic use an explicit `SqlTransaction`
  (see `Stock.RegistarEntrega`: insert delivery, decrement stock guarded by a
  `WHERE stockAtual >= @quantidade` row-count check, update the client's
  `ultimaEntrega` cache — all committed or rolled back together).
- `Stock.ModArtigo` deliberately excludes `stockAtual` from its UPDATE — on-hand
  quantity only moves through `EntradaStock` / `RegistarEntrega`, never through the
  generic edit path.
- `Utentes.GetNewCodUtente` generates the next code (`U001`, `U002`, ... rolling
  into `A001`, `B001`, etc. after `999`) by ranking the letter prefix in a fixed
  sequence rather than a plain `MAX()`, since `MAX("U999") > MAX("A001")` lexically
  and would regenerate duplicates after a rollover.

### Logging

`AppLogger.vb` is a standalone module (no DI): monthly rotating log file at
`%LocalAppData%\GAF\GAF_yyyy-MM.log`, thread-safe via `SyncLock`, never throws
back to the caller. Call `AppLogger.Info/Warn/Error(context, ...)` directly from
anywhere; don't introduce a different logging mechanism.

## Project-file quirks

- `OptionStrict` is `Off` project-wide — implicit conversions are allowed
  throughout; don't assume Option Strict On semantics when reasoning about types.
- No NuGet packages currently in use (`nuget restore` is a no-op today, but is
  still run in CI/build docs for when that changes).
