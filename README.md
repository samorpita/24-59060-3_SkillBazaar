# SkillBazaar — Online Course / Tuition Marketplace
> A three-tier C# WinForms marketplace connecting independent instructors and coaching centers with students, with automatic commission-based revenue sharing.

**Course:** CSC 2210 — Object Oriented Programming 2
**Semester:** Summer 2025–2026 · **Section:** D · **Group:** 08
**Supervised by:** Dr. Md. Iftekharul Mobin

## Team Members
| Name | ID | Contribution |
|------|----|--------------|
| Samorpita Paul | 24-59060-3 | 28% — Database schema design, DatabaseConnection class, User/Student/Instructor/SuperAdmin classes (inheritance), Login & Sign Up forms |
| Sadia Islam Shorna | 23-51988-2 | 24% — Super Admin module |
| Redwan Ahmed Chowdhury | 24-56819-1 | 24% —Customer module, report compilation |
| Saurav Avik Biswas | 25-60982-1 | 24% —Instructor module (Dashboard, Course CRUD, Seat Availability, Earnings), SQL queries |

## Table of Contents
1. [Case Study](#1-case-study)
2. [Functional Requirements](#2-functional-requirements)
3. [User Stories](#3-user-stories)
4. [Project Structure](#4-project-structure)
5. [Database Design](#5-database-design)
6. [OOP Design](#6-oop-design)
7. [How to Run](#7-how-to-run)
8. [Test Credentials](#8-test-credentials)
9. [Screens Implemented](#9-screens-implemented)
10. [Report](#10-report)

## 1. Case Study

Bangladesh has seen rapid growth in demand for supplementary education — university students preparing for admission tests, professionals learning new technical skills, and school students seeking subject tutoring. Currently, independent instructors and small coaching centers rely on scattered channels — Facebook pages, WhatsApp groups, or word-of-mouth — to sell their courses, with no central platform to manage payments, track enrollment, or build credibility through reviews.

SkillBazaar is a three-tier online marketplace that solves this by connecting independent instructors and coaching centers with students, while the platform owner (Super Admin) earns a commission on every transaction. It follows a "one platform, many sellers" model similar to Daraz or Foodpanda, but applied to online education.

Instructors register on the platform and submit their institute details for approval by the Super Admin — a required step so the platform maintains quality and prevents scam listings. Once approved, an instructor can list unlimited courses, setting the price, category, available seats, and whether the course is a one-time purchase or a recurring subscription. Students browse the catalog, filter by category or price, add courses to a cart, and check out using mobile financial services (bKash/Nagad) or card payment. On every successful payment, the system automatically splits the amount — a fixed 20% commission is credited to the platform's revenue, and the remaining 80% is added to the instructor's pending balance. Instructors can request a payout of their accumulated balance at any time, which the Super Admin reviews and approves.

## 2. Functional Requirements

### 2.1 Super Admin
- Log in through a dedicated portal.
- View all pending instructor registrations and approve or reject them.
- Suspend or reactivate any instructor account.
- View/delete any course that violates platform policy.
- View platform-wide reports: total revenue, best-selling courses, top-earning instructors.
- View and approve/reject instructor payout requests.
- View courses/instructors with an average rating below a threshold.

### 2.2 Admin (Instructor / Course Provider)
- Register and submit institute details for approval.
- Log in only after Super Admin approval.
- Create, edit, and delete own courses.
- Set course price, seat count, category, and pricing type (one-time/subscription).
- View current earnings balance (after 20% platform commission).
- View seat availability with low-seat alerts.

### 2.3 Customer (Student)
- Register and log in.
- Browse/search/filter courses by category, price range, and rating.
- Add a course to cart, check out, and pay (simulated).
- View enrolled/purchased courses ("My Learning").
- Leave a rating and review for a course enrolled in.

## 3. User Stories

- As a Super Admin, I want to review pending instructor applications so that only legitimate instructors can sell courses.
- As a Super Admin, I want to see total platform revenue so that I can track business performance.
- As an Instructor, I want to create a new course listing so that students can find and buy it.
- As an Instructor, I want to see how many seats are left so that I don't oversell a course.
- As an Instructor, I want to view my earnings balance so that I know how much I can withdraw.
- As a Student, I want to filter courses by price so that I can find one within my budget.
- As a Student, I want to pay with bKash so that I can complete my purchase easily.
- As a Student, I want to leave a review after finishing a course so that I can help other students decide.

## 4. Project Structure

```
24-59060-3_SkillBazaar/
├── Database/
│   └── DatabaseConnection.cs      Reusable SQL Server connection class (ADO.NET)
├── Models/
│   ├── User.cs                    Abstract base class
│   ├── Student.cs                 Subclass — Customer role
│   ├── Instructor.cs              Subclass — Admin role
│   └── SuperAdmin.cs              Subclass — SuperAdmin role
├── Forms/
│   ├── LoginForm.cs / .Designer.cs
│   └── SignUpForm.cs / .Designer.cs
├── docs/
│   ├── Project_Report.pdf
│   ├── diagrams/
│   └── screenshots/
├── database/
│   └── schema.sql                 Full SQL Server database script
├── Program.cs                     Application entry point
├── App.config                     Connection string configuration
└── 24-59060-3_SkillBazaar.csproj
```

## 5. Database Design

**Engine:** Microsoft SQL Server (LocalDB via SSMS)
**Tables (8):** Users, Institutes, Courses, Cart, Orders, OrderItems, Reviews, Offers

`OrderItems` is a junction table resolving the many-to-many relationship between `Orders` and `Courses`. Schema is normalized to 3NF — see [`database/schema.sql`](database/schema.sql) for full `CREATE TABLE` statements, sample data, and feature queries (filtering, cart, checkout, JOIN/GROUP BY/HAVING earnings and rating reports).

Example JOIN + GROUP BY query (Instructor earnings, splitting the 80/20 commission):
```sql
SELECT i.InstituteName AS Instructor,
       SUM(oi.Subtotal) * 0.80 AS NetEarnings,
       SUM(oi.Subtotal) * 0.20 AS PlatformCommission
FROM OrderItems oi
JOIN Courses c ON oi.CourseId = c.CourseId
JOIN Institutes i ON c.InstituteId = i.InstituteId
GROUP BY i.InstituteName;
```

## 6. OOP Design

- **Abstraction:** `User` is an abstract base class — it can never be instantiated directly.
- **Inheritance:** `Student`, `Instructor`, `SuperAdmin` all inherit from `User`.
- **Polymorphism:** each subclass overrides `GetDashboardFormName()`, so `LoginForm` can call the same method on any `User` object and get role-appropriate routing without an if/else chain on user type.
- **Encapsulation:** database access is centralized in `DatabaseConnection`, so no form talks to SQL Server directly — everything goes through parameterized queries in one place.

## 7. How to Run

1. Install SQL Server / SSMS (or use LocalDB, which ships with Visual Studio).
2. Open `database/schema.sql` in SSMS and execute it — creates the `SkillBazaar` database, 8 tables, and sample data.
3. Open `24-59060-3_SkillBazaar.slnx` in Visual Studio 2022.
4. Open `App.config` and confirm the `SkillBazaarDB` connection string points to your SQL Server instance (default: `(localdb)\MSSQLLocalDB`).
5. Build (Ctrl+Shift+B) and Run (F5). The app starts on `LoginForm`.

## 8. Test Credentials

| Role | Email | Password |
|---|---|---|
| Student | samorpita@student.com | (create via Sign Up) |
| Instructor | (create via Sign Up, then approve manually in SSMS — see below) |

To approve a newly-registered Instructor account for testing:
```sql
UPDATE Users SET Status = 'Approved' WHERE Email = 'the-email-you-used';
UPDATE Institutes SET Status = 'Approved' WHERE OwnerId = (SELECT UserId FROM Users WHERE Email = 'the-email-you-used');
```

## 9. Screens Implemented

- Login / Sign Up (role selection: Student or Instructor)

Dashboard forms for each role (Super Admin, Instructor, Customer) are being built by
other group members — see [Work Distribution](#team-members).

## 10. Report

Full project report (case study, requirements, diagrams, SQL, UI mockups): [`docs/Project_Report.pdf`](docs/Project_Report.pdf)
