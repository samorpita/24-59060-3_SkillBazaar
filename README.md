# SkillBazaar - Online Course and Tuition Marketplace

SkillBazaar is a complete three role C# WinForms marketplace for independent
instructors, coaching centers, and students. It uses SQL Server LocalDB through
ADO.NET and targets .NET Framework 4.7.2.

## Quick start

1. Open `24-59060-3_SkillBazaar.sln` in Visual Studio 2022.
2. Install the **.NET desktop development** workload if Visual Studio requests it.
3. Select **Build > Rebuild Solution**.
4. Press **F5**.

On first run, the application automatically creates the `SkillBazaar` database,
all required tables, constraints, sample data, offers, orders, and reviews on
`(LocalDB)\MSSQLLocalDB`.

If automatic setup is unavailable, connect SSMS to
`(LocalDB)\MSSQLLocalDB` and execute `Database/schema_sqlserver.sql` once.

## Test credentials

| Role | Email | Password | Status |
|---|---|---|---|
| Super Admin | owner@skillbazaar.com | admin123 | Approved |
| Instructor | rafiq@codersbd.com | teacher123 | Approved |
| Customer | samorpita@student.com | student123 | Approved |
| Instructor approval demo | nusrat@examprep.com | teacher123 | Pending |

## Implemented modules

### Super Admin

- Secure login and role based routing
- Platform revenue, instructor, customer, and approval statistics
- Approve or reject pending instructor registrations
- Search, approve, suspend, and reactivate instructor accounts
- View, hide, restore, or delete marketplace courses
- Instructor sales, platform commission, best selling course reports
- Low rated course monitoring
- Approve or reject instructor payout requests with balance validation

### Instructor

- Registration with institute name, category, address, and contact details
- Login only after Super Admin approval
- Course create, read, update, and delete operations
- One time and subscription pricing with duration validation
- Course visibility, seat count, and low seat threshold management
- Active discount offer creation and removal
- Enrollment and student contact list
- Ratings and reviews for owned courses
- Gross sales, 80 percent net earnings, and payout history
- Payout requests limited to the real available balance
- Institute profile updates

### Customer

- Registration, login, and profile update
- Course search by title or institute
- Filters for category, price range, and minimum rating
- Course details, current offers, seat count, and all reviews
- Add to cart, change quantity, and remove items
- Automatic active offer calculation in the cart and at checkout
- Transactional bKash, Nagad, Card, or Cash checkout simulation
- Invoice confirmation and payment reference storage
- Duplicate enrollment and overselling protection
- My Learning purchase history
- Create or update a review only after purchasing a course

## Database

The database is normalized around these tables:

- `Users`
- `Institutes`
- `Courses`
- `Cart`
- `Orders`
- `OrderItems`
- `Reviews`
- `Offers`
- `PayoutRequests`

`OrderItems` resolves the many to many relationship between orders and courses.
The checkout operation uses a serializable SQL transaction so order creation,
discount capture, seat reduction, and cart clearing either all succeed or all
roll back. All user supplied values are sent through SQL parameters.

## OOP implementation

- **Abstraction:** `User` is an abstract base class.
- **Inheritance:** `Student`, `Instructor`, and `SuperAdmin` inherit from `User`.
- **Polymorphism:** each subclass overrides `GetDashboardFormName()` for role routing.
- **Encapsulation:** connection and query execution are centralized in
  `DatabaseConnection`; automatic first run setup is handled by
  `DatabaseInitializer`.

## Project structure

```text
24-59060-3_SkillBazaar.sln
24-59060-3_SkillBazaar.csproj
App.config
Program.cs
Database/
  DatabaseConnection.cs
  DatabaseInitializer.cs
  schema_sqlserver.sql
Models/
  User.cs
  Student.cs
  Instructor.cs
  SuperAdmin.cs
Forms/
  Ui.cs
  LoginForm.cs
  LoginForm.Designer.cs
  SignUpForm.cs
  SuperAdminDashboardForm.cs
  InstructorDashboardForm.cs
  CustomerDashboardForm.cs
  CourseDetailsForm.cs
  CheckoutForm.cs
docs/
  Project_Report.pdf
```

## Connection configuration

The default connection in `App.config` is:

```text
Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SkillBazaar;Integrated Security=True;Connect Timeout=30
```

If the computer uses SQL Server Express instead, change only this connection
string to the instance displayed in SSMS.

## Submission information

Course: CSC 2210 Object Oriented Programming 2  
Semester: Summer 2025 to 2026  
Section: D  
Group: 08

The original project report is included under `docs/Project_Report.pdf`.
