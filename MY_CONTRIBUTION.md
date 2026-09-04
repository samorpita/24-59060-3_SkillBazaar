# SkillBazaar — My Contribution (Samorpita Paul, 24-59060-3)

This document describes my individual contribution to the SkillBazaar group project,
for CSC 2210 Individual Submission purposes.

## My Module
**Database + Core/Shared Module** — the foundation every other module depends on.

## Files I Wrote

### Database
- `Database/DatabaseConnection.cs` — central ADO.NET connection class (SQL Server). Every form in the app uses this instead of creating its own connection, so all database access is consistent and centralized.
- `database/schema.sql` — full database script: 8 tables, sample data (minimum 3 rows per table), and all feature queries.

### Models (OOP core)
- `Models/User.cs` — abstract base class holding shared properties (UserId, FullName, Email, UserType, Status) and the abstract method `GetDashboardFormName()`.
- `Models/Student.cs`, `Models/Instructor.cs`, `Models/SuperAdmin.cs` — concrete subclasses inheriting from `User`. Each overrides `GetDashboardFormName()` to return its own dashboard form name — this is the polymorphism hook that lets `LoginForm` route any logged-in user to the correct screen without an if/else chain on role.

### Forms
- `Forms/LoginForm.cs` + `.Designer.cs` — validates credentials against the `Users` table (SHA-256 hashed passwords), checks account `Status` (Pending/Approved/Suspended), and routes to the correct dashboard based on `UserType`.
- `Forms/SignUpForm.cs` + `.Designer.cs` — registers new Students (auto-approved) or Instructors (Pending until Super Admin approval), including creating the linked `Institutes` row for new instructors.

## OOP Concepts Used

| Concept | Where |
|---|---|
| Abstraction | `User` is an abstract class — cannot be instantiated directly |
| Inheritance | `Student`, `Instructor`, `SuperAdmin` extend `User` |
| Polymorphism | `GetDashboardFormName()` is overridden differently per subclass |
| Encapsulation | All database access goes through `DatabaseConnection`; forms never build raw SQL connections themselves |

## Sample Non-Trivial Code

```csharp
public User CreateUserFromType(string userType, int userId, string fullName, string email, string status)
{
    switch (userType)
    {
        case "SuperAdmin":
            return new SuperAdmin(userId, fullName, email, status);
        case "Admin":
            return new Instructor(userId, fullName, email, status);
        case "Customer":
        default:
            return new Student(userId, fullName, email, status);
    }
}

private void OpenDashboard(User user)
{
    switch (user.GetDashboardFormName())
    {
        case "SuperAdminDashboardForm":
            new SuperAdminDashboardForm((SuperAdmin)user).Show();
            break;
        case "InstructorDashboardForm":
            new InstructorDashboard((Instructor)user).Show();
            break;
        case "CourseCatalogForm":
        default:
            new CourseCatalogForm((Student)user).Show();
            break;
    }
}
```

This is the factory method in `LoginForm.cs` that turns a database row into the correct
`User` subclass after checking credentials, then calls `GetDashboardFormName()` polymorphically
to decide which screen to open — `LoginForm` never needs to know the exact subclass, only that
it's some kind of `User`. This keeps the login flow open to extension (adding a 4th role later
would mean adding one more subclass and one more `case`, not rewriting the login logic). This
class is also the integration point that connects my module to every other group member's
dashboard forms — once they finished their own dashboard forms, I only needed to uncomment
one line per role here to wire everything together.

## SQL I Wrote

Example — login query that authenticates a user and returns their role in one step,
used to decide which dashboard to open:

```sql
SELECT UserId, FullName, UserType, Status
FROM Users
WHERE Email = @email AND Password = @pwd;
```

Example — Sign Up, which also creates the linked Institutes row for new instructors
(demonstrates a multi-table INSERT sequence, not just a single-table one):

```sql
INSERT INTO Users (FullName, Email, Password, Phone, Address, UserType, Status)
VALUES (@fullName, @email, @pwd, @phone, @address, @userType, @status);
SELECT SCOPE_IDENTITY();

INSERT INTO Institutes (OwnerId, InstituteName, Category, Status)
VALUES (@ownerId, @instituteName, @category, 'Pending');
```

## Database Engine & Connection String

- **Engine:** Microsoft SQL Server (LocalDB via SSMS)
- **Connection string location:** `App.config`, key `SkillBazaarDB`
- **Value:** `Server=(localdb)\MSSQLLocalDB;Database=SkillBazaar;Trusted_Connection=True;`
- To point at a different SQL Server instance, only this one line needs to change.

## My Contribution Percentage: 28%
(Group agreement: Yes)

