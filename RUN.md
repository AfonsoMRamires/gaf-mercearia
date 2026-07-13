# Running GAF on Windows

GAF is a VB.NET WinForms desktop app targeting **.NET Framework 4.7.2**. It uses
**SQL Server LocalDB** with a database file (`GAF.mdf`) attached at runtime. All
three dependencies are Windows-only, so the app builds and runs only on Windows.

---

## 1. Prerequisites

Install on the Windows machine:

- **Windows 10/11**
- One of:
  - **Visual Studio 2022** (Community is fine) with the **.NET desktop development** workload, or
  - **Build Tools for Visual Studio 2022** + the **.NET Framework 4.7.2 targeting pack**
- **SQL Server Express LocalDB** — ships with Visual Studio; otherwise install the
  [standalone LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) package.

Verify LocalDB is available (Command Prompt / PowerShell):

```powershell
sqllocaldb info
```

If the default instance is missing, create it:

```powershell
sqllocaldb create MSSQLLocalDB
sqllocaldb start MSSQLLocalDB
```

---

## 2. Get the code

```powershell
git clone https://github.com/AfonsoMRamires/gaf-mercearia.git
cd gaf-mercearia
```

---

## 3. Database (required — read this first)

The connection string (`GAF/App.config`) attaches a local database file:

```
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GAF.mdf;Integrated Security=True;Connect Timeout=30
```

`GAF.mdf` and `GAF_log.ldf` are **gitignored and NOT in the repo** (database files
don't belong in source control). You must supply a `GAF.mdf` before the app will run.

The app **auto-creates** the `Artigos` and `Entregas` tables on startup
(`Stock.EnsureSchema`), but it does **not** create the core `Utentes` table — that
must already exist in the database.

Pick one:

**A. You already have a `GAF.mdf`** (from a colleague / previous machine)
Copy it into `GAF/` next to `App.config`. Done.

**B. Create a fresh database**
1. Open **View → SQL Server Object Explorer** in Visual Studio (or SSMS), connect to
   `(LocalDB)\MSSQLLocalDB`.
2. Create a database named `GAF` (this produces `GAF.mdf` + `GAF_log.ldf`).
3. Create the `Utentes` table. It must contain at least these columns (types inferred
   from the code; adjust as needed):

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
4. Copy the resulting `GAF.mdf` (and `.ldf`) into `GAF/`.

> **Tip:** prefer `DATE` columns over `DATETIME`. Unset dates are written as
> `1900-01-01`; `DATETIME` also works, but `DATE` avoids any min-value edge cases.

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
> compiling locally (you still need to supply `GAF.mdf` and LocalDB to run it).

---

## 5. Run

**From Visual Studio:** press **F5** (Debug) or **Ctrl+F5** (Run without debugging).

**From the build output:**

```powershell
GAF\bin\Release\GAF.exe
```

`GAF.mdf` is copied next to `GAF.exe` on build (`CopyToOutputDirectory=Always`), so
the running app uses the copy in the output folder, not the one in `GAF/`.

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
| `MSB3030: Could not copy ... GAF.mdf` on build | `GAF.mdf` missing — see section 3. |
| App starts but every action errors "Invalid object name 'Utentes'" | `Utentes` table not created in the DB — see section 3B. |
| `A network-related or instance-specific error ... LocalDB` | LocalDB not installed/started — see section 1. |
| Insert fails on a date column | Ensure date columns are `DATE` (or `DATETIME`); unset dates map to `1900-01-01`. |
| Photos fail to load | `foto` / `fotoAut` must be `VARBINARY(MAX)` holding JPEG bytes. |
