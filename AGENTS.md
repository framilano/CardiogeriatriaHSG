# CardiogeriatriaHSG — Agent guide

## Stack

- **.NET 10** Avalonia Desktop app (MVVM with CommunityToolkit.Mvvm source generators)
- **SQLite** via EF Core 10 (design-time factory: `AppDbFactory` uses `design.db`)
- **Serilog** (console + rolling file at `logs/CardiogeriatriaHSG-{date}.log`, 7-day retention)
- **NuGet** SDK-style references, no lockfile

## Build & run

```bash
dotnet build                           # debug build
dotnet publish -c Release -r linux-x64 --self-contained true
```

## EF Core migrations

```bash
dotnet ef migrations add <Name>        # generates migration against design.db
dotnet ef migrations remove            # rolls back last migration
```

Runtime DB: `%APPDATA%/CardiogeriatriaHSG/cardiogeriatriahsg.sqlite` (created on first launch via `Database.Migrate()`).

## Architecture

- **View → ViewModel → Model → Repository → EF Core DbContext → SQLite**
- 1 solution, 1 project, 11 models (Patient + Visit + 9 sub-visit tables), 38 migrations
- Patient codes: user input is SHA256-hashed, truncated to first 10 base64 chars
- `AvaloniaUseCompiledBindingsByDefault=true` — recompile after ViewModel property changes
- Sidebar nav order: Anagrafica → Anamnesi geriatrica → APR → Terapia domiciliare → Raccordo clinico → Esami Ematici → Esami Obiettivo → ECO → CGA → Conclusioni → *(TFV, Consigli — not implemented)* → Referto

## Constraints

- **No tests, no linter, no formatter, no CI** — add them if you introduce them
- Nullable enabled, brand color `#6d1a61`, `.sln` targets `net10.0`
- IDE: JetBrains Rider (`.idea/` config present), no `.vscode/`, no `.editorconfig`
- Does not use `Directory.Build.props` or `NuGet.config`
