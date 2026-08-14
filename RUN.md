# Running GAF on Windows

GAF is a VB.NET WinForms desktop app targeting **.NET Framework 4.7.2**. It uses a
**SQL Server Express** instance (database `GAF` on `.\SQLEXPRESS`) over Integrated
Security. All dependencies are Windows-only, so the app builds and runs only on
Windows.

---

## 1. Prerequisites

Install on the Windows machine:

- **Windows 10/11**
- One of:
  - **Visual Studio 2022** (Community is fine) with the **.NET desktop development** workload, or
  - **Build Tools for Visual Studio 2022** + the **.NET Framework 4.7.2 targeting pack**
- **SQL Server Express**, with an instance named `SQLEXPRESS` (the default instance
  name the installer proposes). Installing SQL Server Express itself requires admin
  rights on the machine — if you don't have them, ask whoever manages the machine to
  install it once; after that, creating/using databases on the instance does not
  require admin.

Verify the instance is installed and running (Command Prompt / PowerShell):

```powershell
Get-Service | Where-Object { $_.Name -like "*SQL*" }
```

You should see `MSSQL$SQLEXPRESS` with status `Running`. If it's `Stopped`:

```powershell
Start-Service "MSSQL$SQLEXPRESS"
```

---

## 2. Get the code

```powershell
git clone https://github.com/AfonsoMRamires/gaf-mercearia.git
cd gaf-mercearia
```

---

## 3. Database (required — read this first)

The connection string (`GAF/App.config`) connects to a named database on the local
SQLEXPRESS instance:

```
Data Source=.\SQLEXPRESS;Initial Catalog=GAF;Integrated Security=True;Connect Timeout=30
```

There's no database file to copy around — the `GAF` database lives inside the
SQLEXPRESS instance itself, same as any other SQL Server database.

The app **auto-creates** the `Artigos`, `Entregas`, `SaidasStock` and `Notas` tables
on startup (`Stock.EnsureSchema`), but it does **not** create the core `Utentes`
table — that must already exist in the database.

**Create the database (first time only):**

1. Connect to `.\SQLEXPRESS` with SSMS, Visual Studio's SQL Server Object Explorer,
   or `sqlcmd`.
2. Create a database named `GAF`:
   ```sql
   CREATE DATABASE GAF;
   ```
3. Create the `Utentes` table. It must contain at least these columns (types
   inferred from the code; adjust as needed):

   | Column | Type | Notes |
   |---|---|---|
   | `codUtente` | `CHAR(4)` | primary key, e.g. `U001` |
   | `nome`, `morada`, `complemento`, `autorizado` | `NVARCHAR` | |
   | `telefone`, `telemovel`, `nif`, `ss`, `id` | `NVARCHAR` | |
   | `pais`, `estCivil`, `sexo`, `codPostal`, `obs`, `utilizador` | `NVARCHAR` | |
   | `dataNasc`, `dataEntrada`, `dataSaida`, `dtCriacao`, `ultimaEntrega` | `DATE` | use `DATE`, not `DATETIME` |
   | `hrCriacao` | `TIME` | stored as `HH:mm:ss` |
   | `ativo` | `BIT` | |
   | `codFamilia` | `INT` | |
   | `receita`, `despesa` | `DECIMAL(10,2)` | |
   | `foto`, `fotoAut` | `VARBINARY(MAX)` | JPEG bytes |

   > Column **order matters**: `AddUtente` uses `INSERT INTO Utentes VALUES (...)`
   > without a column list, so the table's physical column order must match the order
   > in `Utentes.vb` `AddUtente`.

> **Tip:** prefer `DATE` columns over `DATETIME`. Unset dates are written as
> `1900-01-01`; `DATETIME` also works, but `DATE` avoids any min-value edge cases.

If you already have a colleague's populated `GAF` database, restore/attach it to
your own SQLEXPRESS instance under the name `GAF` instead of creating an empty one.

---

## 4. Build

**Option A — Visual Studio**
Open `GAF.sln`, then **Build → Build Solution** (`Ctrl+Shift+B`).

**Option B — command line** (Developer Command Prompt / PowerShell):

```powershell
nuget restore GAF.sln          # optional; no NuGet packages currently
msbuild GAF.sln /p:Configuration=Release /p:Platform="Any CPU"
```

Output lands in `GAF\bin\Release\` (or `bin\Debug\`).

> CI already verifies the build on every push — see
> `.github/workflows/build.yml` (runs on `windows-latest`). A green run's
> **GAF-Release** artifact is a ready-to-run build you can download instead of
> compiling locally (you still need a SQLEXPRESS instance with a `GAF` database to
> run it).

---

## 5. Run

**From Visual Studio:** press **F5** (Debug) or **Ctrl+F5** (Run without debugging).

**From the build output:**

```powershell
GAF\bin\Release\GAF.exe
```

---

## 6. Logs

The app writes a monthly rotating log to:

```
%LocalAppData%\GAF\GAF_yyyy-MM.log
```

e.g. `C:\Users\<you>\AppData\Local\GAF\GAF_2026-07.log`. Check it if the app misbehaves —
DB errors are logged there with a stack trace.

---

## 7. Troubleshooting

| Symptom | Likely cause / fix |
|---|---|
| App starts but every action errors "Invalid object name 'Utentes'" | `Utentes` table not created in the DB — see section 3. |
| `A network-related or instance-specific error ... SQL Server` | SQLEXPRESS instance not installed/running — see section 1. |
| `Cannot open database "GAF" requested by the login` | The `GAF` database doesn't exist yet on this instance — see section 3. |
| Insert fails on a date column | Ensure date columns are `DATE` (or `DATETIME`); unset dates map to `1900-01-01`. |
| Photos fail to load | `foto` / `fotoAut` must be `VARBINARY(MAX)` holding JPEG bytes. |
