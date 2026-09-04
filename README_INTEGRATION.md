# Super Admin Module — Sadia Islam Shorna

C# WinForms screens for: **Super Admin Dashboard, Manage Instructors
(approve/suspend), Sales & Commission Report, Payout Approval.**

- Framework: **.NET Framework 4.7.2** (classic WinForms project — not .NET 6)
- Database: **Microsoft SQL Server**, managed through **SSMS**
- Data access: **System.Data.SqlClient** — built into .NET Framework, so
  there's nothing to download from NuGet. It just works the moment you open
  the project, even with no internet connection.
- Kept to plain C# 7.3 syntax on purpose (no switch expressions, no C# 8+
  features) so it compiles with any Visual Studio 2022 install, no
  language-version surprises.

## How to run it standalone (to test/demo before merging)

1. Open **SSMS**, connect to your local SQL Server instance.
2. Open `Database/schema_sqlserver.sql` and run it (F5). This creates the
   `SkillBazaar` database, all 8 tables, and sample data that matches the
   numbers in the report mockups exactly (৳96,400 revenue, 18 instructors,
   etc.) plus a new `PayoutRequests` table for the Payout Approval screen.
3. Double-click `SuperAdminModule.sln` — it opens in Visual Studio 2022 with
   every file already listed in Solution Explorer (Program.cs,
   DatabaseConnection.cs, Models/, Forms/ — nothing to add manually).
4. In `DatabaseConnection.cs`, check the connection string matches your SQL
   Server instance name. It defaults to:
   `Server=localhost;Database=SkillBazaar;Trusted_Connection=True;...`
   — if SSMS shows your server as e.g. `DESKTOP-ABC\SQLEXPRESS`, use that
   instead of `localhost`.
5. Press F5. It opens straight to the Dashboard. Click the sidebar to move
   between all four screens.

If Visual Studio asks about a missing "Windows Forms" workload, open the
**Visual Studio Installer** → Modify → check **.NET desktop development** →
Modify. That's the only prerequisite (no NuGet packages to restore).

If the database isn't reachable yet, every screen still shows the exact
numbers from the report (hardcoded fallback) so it looks right in a demo
even before SSMS is fully wired up.

## Files

```
SuperAdminModule.sln                — open this in Visual Studio
SuperAdminModule.csproj             — .NET Framework 4.7.2, WinForms
App.config
Properties/AssemblyInfo.cs
Program.cs                          — standalone launcher for testing
DatabaseConnection.cs               — SQL Server connection helper
Models/User.cs                      — base class (placeholder, see below)
Models/SuperAdmin.cs                — SuperAdmin : User, opens the dashboard
Forms/SuperAdminFormBase.cs         — shared top bar + sidebar + styling
Forms/SuperAdminDashboardForm.cs    — Screen 6.3
Forms/ManageInstructorsForm.cs      — Screen 6.4
Forms/SalesCommissionReportForm.cs  — Screen 6.5
Forms/PayoutApprovalForm.cs         — Payout Approval (FR6, no mockup existed)
Database/schema_sqlserver.sql       — full DB schema + sample data + queries
```

## Note to Samorpita (Database + Core/Shared)

Two things from your part are stubbed here just so this module compiles on
its own branch — replace them with your real versions when we merge:

- **`DatabaseConnection.cs`** — mine is a minimal SQL Server wrapper using
  `System.Data.SqlClient`. If your real one has a different method
  name/signature (or uses a different SQL client), either rename mine to
  match or update the `using`s in the `Forms/` files.
- **`Models/User.cs`** — minimal base class so `SuperAdmin : User` compiles.
  If your real `User` class has more fields/methods, mine can just be
  deleted once yours is in place — `SuperAdmin.cs` only needs the
  constructor shape and `OpenDashboard()` to stay compatible.

If your shared project is also .NET Framework (not .NET 6), you can just
copy these `.cs` files straight into your existing `.csproj` via
**Add → Existing Item** in Solution Explorer instead of keeping this as a
separate project.

Also: **`PayoutRequests` is a new table**, not in the original schema — it
didn't exist because there was no payout-approval mockup in the report. It's
in `Database/schema_sqlserver.sql` near the bottom; please fold it into the
shared schema file so everyone's DB has it.

## Note on the SQL Server conversion

Only real syntax differences from the original MySQL schema were changed:
`AUTO_INCREMENT` → `IDENTITY(1,1)`, `ENUM(...)` → `VARCHAR` + `CHECK`,
`CURRENT_TIMESTAMP` → `GETDATE()`. Table names, column names, and
relationships are all unchanged, so nobody else's queries should need to be
rewritten beyond those same three patterns.
