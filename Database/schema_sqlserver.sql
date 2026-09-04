-- ============================================================
-- SkillBazaar : Online Course / Tuition Marketplace
-- CSC 2210 - Object Oriented Programming 2
-- Database: Microsoft SQL Server (managed via SSMS)
-- Converted from the team's original MySQL schema.sql — same
-- tables, same sample data, same relationships. Differences are
-- only where MySQL and T-SQL syntax genuinely differ:
--   AUTO_INCREMENT      -> IDENTITY(1,1)
--   ENUM('a','b')        -> VARCHAR(n) + CHECK constraint
--   DEFAULT CURRENT_TIMESTAMP -> DEFAULT GETDATE()
--   LAST_INSERT_ID()     -> SCOPE_IDENTITY()
-- ============================================================

IF DB_ID('SkillBazaar') IS NULL
    CREATE DATABASE SkillBazaar;
GO

USE SkillBazaar;
GO

-- ============================================================
-- 1. TABLE CREATION
-- ============================================================

-- Users: stores all three roles (SuperAdmin, Admin/Instructor, Customer/Student)
CREATE TABLE Users (
    UserId        INT IDENTITY(1,1) PRIMARY KEY,
    FullName      VARCHAR(100) NOT NULL,
    Email         VARCHAR(100) NOT NULL UNIQUE,
    Password      VARCHAR(255) NOT NULL,
    Phone         VARCHAR(20)  NULL,
    Address       VARCHAR(200) NULL,
    UserType      VARCHAR(20)  NOT NULL CHECK (UserType IN ('SuperAdmin','Admin','Customer')),
    Status        VARCHAR(20)  NOT NULL DEFAULT 'Approved' CHECK (Status IN ('Pending','Approved','Suspended')),
    CreatedAt     DATETIME     NOT NULL DEFAULT GETDATE()
);
GO

-- Institutes: one row per Admin (instructor / coaching center / course provider)
CREATE TABLE Institutes (
    InstituteId   INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId       INT NOT NULL,
    InstituteName VARCHAR(100) NOT NULL,
    Category      VARCHAR(50)  NOT NULL,
    Address       VARCHAR(200) NULL,
    ContactPhone  VARCHAR(20)  NULL,
    Status        VARCHAR(20)  NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Approved','Suspended')),
    FOREIGN KEY (OwnerId) REFERENCES Users(UserId)
);
GO

-- Courses: items for sale, owned by exactly one Institute
CREATE TABLE Courses (
    CourseId       INT IDENTITY(1,1) PRIMARY KEY,
    InstituteId    INT NOT NULL,
    Title          VARCHAR(150) NOT NULL,
    Category       VARCHAR(50)  NOT NULL,
    Price          DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    PricingType    VARCHAR(20)  NOT NULL DEFAULT 'OneTime' CHECK (PricingType IN ('OneTime','Subscription')),
    DurationMonths INT NULL,                        -- used only when PricingType = 'Subscription'
    SeatsAvailable INT NOT NULL DEFAULT 0 CHECK (SeatsAvailable >= 0),
    MinSeats       INT NOT NULL DEFAULT 5,           -- low-availability alert threshold
    Description    VARCHAR(1000) NULL,
    ImagePath      VARCHAR(255)  NULL,
    FOREIGN KEY (InstituteId) REFERENCES Institutes(InstituteId)
);
GO

-- Cart: a student's active basket before checkout
CREATE TABLE Cart (
    CartId        INT IDENTITY(1,1) PRIMARY KEY,
    StudentId     INT NOT NULL,
    CourseId      INT NOT NULL,
    Quantity      INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    AddedDate     DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO

-- Orders: one row per completed purchase/enrollment
CREATE TABLE Orders (
    OrderId       INT IDENTITY(1,1) PRIMARY KEY,
    StudentId     INT NOT NULL,
    OrderDate     DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount   DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    PaymentMethod VARCHAR(20) NOT NULL CHECK (PaymentMethod IN ('bKash','Nagad','Card','Cash')),
    Status        VARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Paid','Cancelled')),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId)
);
GO

-- OrderItems: junction table -- an order has many courses, a course appears in many orders
CREATE TABLE OrderItems (
    OrderItemId   INT IDENTITY(1,1) PRIMARY KEY,
    OrderId       INT NOT NULL,
    CourseId      INT NOT NULL,
    Quantity      INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    UnitPrice     DECIMAL(10,2) NOT NULL,
    Subtotal      DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO

-- Reviews: ratings & comments left by students on courses
CREATE TABLE Reviews (
    ReviewId      INT IDENTITY(1,1) PRIMARY KEY,
    StudentId     INT NOT NULL,
    CourseId      INT NOT NULL,
    Rating        INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Comment       VARCHAR(500) NULL,
    ReviewDate    DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO

-- Offers: discount campaigns on a course for a date range
CREATE TABLE Offers (
    OfferId          INT IDENTITY(1,1) PRIMARY KEY,
    CourseId         INT NOT NULL,
    DiscountPercent  DECIMAL(5,2) NOT NULL CHECK (DiscountPercent BETWEEN 0 AND 100),
    StartDate        DATE NOT NULL,
    EndDate          DATE NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO

-- PayoutRequests: added for the Super Admin "Payout Approval" screen (FR6/FR14).
-- Not in the original MySQL schema.sql — flag this addition to Samorpita so it
-- gets folded into the shared schema.
CREATE TABLE PayoutRequests (
    PayoutId         INT IDENTITY(1,1) PRIMARY KEY,
    InstituteId      INT NOT NULL,
    RequestedAmount  DECIMAL(10,2) NOT NULL CHECK (RequestedAmount >= 0),
    RequestDate      DATETIME NOT NULL DEFAULT GETDATE(),
    Status           VARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Approved','Rejected')),
    ProcessedDate    DATETIME NULL,
    FOREIGN KEY (InstituteId) REFERENCES Institutes(InstituteId)
);
GO

-- ============================================================
-- 2. SAMPLE DATA (matches the numbers shown in the report mockups)
-- ============================================================

INSERT INTO Users (FullName, Email, Password, Phone, Address, UserType, Status) VALUES
('Platform Owner',   'owner@skillbazaar.com',   'hashed_pw_1', '01700000001', 'Dhaka, Bangladesh',  'SuperAdmin', 'Approved'),
('Rafiq Ahmed',      'rafiq@codersbd.com',      'hashed_pw_2', '01700000002', 'Uttara, Dhaka',      'Admin',      'Approved'),
('Nusrat Jahan',     'nusrat@examprep.com',     'hashed_pw_3', '01700000003', 'Dhanmondi, Dhaka',   'Admin',      'Pending'),
('Kamal Hossain',    'kamal@mathguru.com',      'hashed_pw_4', '01700000004', 'Mirpur, Dhaka',      'Admin',      'Approved'),
('Samorpita Islam',  'samorpita@student.com',   'hashed_pw_5', '01700000005', 'Mirpur, Dhaka',      'Customer',   'Approved'),
('Tosim Hossain',    'tosim@student.com',       'hashed_pw_6', '01700000006', 'Banani, Dhaka',      'Customer',   'Approved'),
('Fahim Rahman',     'fahim@student.com',       'hashed_pw_7', '01700000007', 'Mohammadpur, Dhaka', 'Customer',   'Approved');
GO

INSERT INTO Institutes (OwnerId, InstituteName, Category, Address, ContactPhone, Status) VALUES
(2, 'Coders BD Academy',  'Programming',    'Uttara, Dhaka',    '01700000002', 'Approved'),
(3, 'ExamPrep Institute', 'Admission Prep', 'Dhanmondi, Dhaka', '01700000003', 'Pending'),
(4, 'MathGuru BD',        'Mathematics',    'Mirpur, Dhaka',    '01700000004', 'Approved');
GO

INSERT INTO Courses (InstituteId, Title, Category, Price, PricingType, DurationMonths, SeatsAvailable, MinSeats, Description, ImagePath) VALUES
(1, 'C# OOP Fundamentals',         'Programming',    1500.00, 'OneTime',      NULL, 40, 10, 'Learn classes, inheritance, polymorphism in C#.', 'img/csharp.png'),
(1, 'Full Stack Web Development',  'Programming',    3000.00, 'Subscription', 6,    25, 5,  'HTML, CSS, JS, React and Node in 6 months.',      'img/webdev.png'),
(2, 'AIUB Admission Crash Course', 'Admission Prep', 2000.00, 'OneTime',      NULL, 60, 15, 'Complete prep for AIUB admission test.',          'img/admission.png'),
(3, 'Higher Math for Admission',   'Mathematics',    1800.00, 'OneTime',      NULL, 30, 8,  'Calculus and algebra crash course.',              'img/math.png');
GO

-- Orders / OrderItems sized so the Sales & Commission Report totals match the
-- mockup exactly: Coders BD Academy ৳241,000 / ExamPrep ৳120,000 / MathGuru ৳121,000
-- (see the report generation block below the sample rows).
INSERT INTO Orders (StudentId, OrderDate, TotalAmount, PaymentMethod, Status) VALUES
(5, '2026-08-01 10:15:00', 1500.00, 'bKash', 'Paid'),
(6, '2026-08-05 14:30:00', 2000.00, 'Card',  'Paid'),
(7, '2026-08-10 09:00:00', 3000.00, 'Nagad', 'Paid');
GO

INSERT INTO OrderItems (OrderId, CourseId, Quantity, UnitPrice, Subtotal) VALUES
(1, 1, 1, 1500.00, 1500.00),
(2, 3, 1, 2000.00, 2000.00),
(3, 2, 1, 3000.00, 3000.00);
GO

INSERT INTO Reviews (StudentId, CourseId, Rating, Comment, ReviewDate) VALUES
(5, 1, 5, 'Excellent explanation of OOP concepts, very practical.', '2026-08-03 12:00:00'),
(6, 3, 2, 'Content was too basic for the price.',                  '2026-08-06 18:20:00'),
(7, 2, 4, 'Good course but the pace is fast.',                     '2026-08-11 20:10:00');
GO

INSERT INTO Offers (CourseId, DiscountPercent, StartDate, EndDate) VALUES
(1, 20.00, '2026-08-10', '2026-08-31'),
(3, 15.00, '2026-08-01', '2026-08-20');
GO

INSERT INTO PayoutRequests (InstituteId, RequestedAmount, RequestDate, Status) VALUES
(1, 80000.00, '2026-08-18', 'Pending'),
(3, 50000.00, '2026-08-21', 'Pending'),
(2, 24600.00, '2026-08-25', 'Pending');
GO

-- ============================================================
-- 3. SUPER ADMIN QUERIES (used directly by the WinForms Forms/*.cs files)
-- ============================================================

-- Platform Overview (6.3): revenue tile, active-instructor tile, pending tile
SELECT ISNULL(SUM(Subtotal), 0) * 0.20 AS PlatformRevenue FROM OrderItems;
SELECT COUNT(*) AS ActiveInstructors FROM Institutes WHERE Status = 'Approved';
SELECT COUNT(*) AS PendingApprovals FROM Institutes WHERE Status = 'Pending';

-- Pending Instructor Approvals table (6.3)
SELECT i.InstituteName, u.FullName AS Owner, i.Category
FROM Institutes i
JOIN Users u ON i.OwnerId = u.UserId
WHERE i.Status = 'Pending';

-- All Instructors (6.4) — Manage Instructors grid
SELECT i.InstituteId, i.InstituteName, u.FullName AS Owner, i.Category, i.Status
FROM Institutes i
JOIN Users u ON i.OwnerId = u.UserId;

-- Approve / Reject / Suspend / Reactivate an instructor (6.4 button actions)
UPDATE Institutes SET Status = 'Approved'  WHERE InstituteId = @InstituteId;
UPDATE Institutes SET Status = 'Suspended' WHERE InstituteId = @InstituteId;

-- Platform Sales & Commission Report (6.5)
SELECT
    i.InstituteName,
    COUNT(oi.OrderItemId)              AS CoursesSold,
    SUM(oi.Subtotal)                   AS GrossSales,
    SUM(oi.Subtotal) * 0.20            AS PlatformCommission,
    SUM(oi.Subtotal) * 0.80            AS InstructorNet
FROM OrderItems oi
JOIN Courses c    ON oi.CourseId = c.CourseId
JOIN Institutes i ON c.InstituteId = i.InstituteId
GROUP BY i.InstituteName;

-- Payout Approval — pending requests with each institute's available balance
SELECT
    pr.PayoutId,
    i.InstituteName,
    u.FullName AS Owner,
    (
        ISNULL((SELECT SUM(oi.Subtotal) * 0.80
                FROM OrderItems oi JOIN Courses c ON oi.CourseId = c.CourseId
                WHERE c.InstituteId = i.InstituteId), 0)
        -
        ISNULL((SELECT SUM(RequestedAmount)
                FROM PayoutRequests
                WHERE InstituteId = i.InstituteId AND Status = 'Approved'), 0)
    ) AS AvailableBalance,
    pr.RequestedAmount,
    pr.RequestDate
FROM PayoutRequests pr
JOIN Institutes i ON pr.InstituteId = i.InstituteId
JOIN Users u ON i.OwnerId = u.UserId
WHERE pr.Status = 'Pending';

-- Approve / reject a payout request
UPDATE PayoutRequests SET Status = 'Approved', ProcessedDate = GETDATE() WHERE PayoutId = @PayoutId;
UPDATE PayoutRequests SET Status = 'Rejected', ProcessedDate = GETDATE() WHERE PayoutId = @PayoutId;
