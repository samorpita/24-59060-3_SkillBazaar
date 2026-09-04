IF DB_ID('SkillBazaar') IS NULL
    CREATE DATABASE SkillBazaar;
GO

USE SkillBazaar;
GO

IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        UserId INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Password VARCHAR(64) NOT NULL,
        Phone NVARCHAR(20) NULL,
        Address NVARCHAR(200) NULL,
        UserType VARCHAR(20) NOT NULL CHECK (UserType IN ('SuperAdmin','Admin','Customer')),
        Status VARCHAR(20) NOT NULL DEFAULT 'Approved' CHECK (Status IN ('Pending','Approved','Suspended')),
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
END;
GO

IF OBJECT_ID('dbo.Institutes', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Institutes (
        InstituteId INT IDENTITY(1,1) PRIMARY KEY,
        OwnerId INT NOT NULL UNIQUE,
        InstituteName NVARCHAR(100) NOT NULL,
        Category NVARCHAR(50) NOT NULL,
        Address NVARCHAR(200) NULL,
        ContactPhone NVARCHAR(20) NULL,
        Status VARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Approved','Suspended')),
        CONSTRAINT FK_Institutes_Users FOREIGN KEY (OwnerId) REFERENCES dbo.Users(UserId)
    );
END;
GO

IF OBJECT_ID('dbo.Courses', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Courses (
        CourseId INT IDENTITY(1,1) PRIMARY KEY,
        InstituteId INT NOT NULL,
        Title NVARCHAR(150) NOT NULL,
        Category NVARCHAR(50) NOT NULL,
        Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
        PricingType VARCHAR(20) NOT NULL DEFAULT 'OneTime' CHECK (PricingType IN ('OneTime','Subscription')),
        DurationMonths INT NULL CHECK (DurationMonths IS NULL OR DurationMonths > 0),
        SeatsAvailable INT NOT NULL DEFAULT 0 CHECK (SeatsAvailable >= 0),
        MinSeats INT NOT NULL DEFAULT 5 CHECK (MinSeats >= 0),
        Description NVARCHAR(1000) NULL,
        ImagePath NVARCHAR(255) NULL,
        Status VARCHAR(20) NOT NULL DEFAULT 'Active' CHECK (Status IN ('Active','Hidden')),
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Courses_Institutes FOREIGN KEY (InstituteId) REFERENCES dbo.Institutes(InstituteId)
    );
END;
GO
IF COL_LENGTH('dbo.Courses', 'Status') IS NULL
    ALTER TABLE dbo.Courses ADD Status VARCHAR(20) NOT NULL CONSTRAINT DF_Courses_Status DEFAULT 'Active';
GO
IF COL_LENGTH('dbo.Courses', 'CreatedAt') IS NULL
    ALTER TABLE dbo.Courses ADD CreatedAt DATETIME NOT NULL CONSTRAINT DF_Courses_CreatedAt DEFAULT GETDATE();
GO

IF OBJECT_ID('dbo.Cart', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Cart (
        CartId INT IDENTITY(1,1) PRIMARY KEY,
        StudentId INT NOT NULL,
        CourseId INT NOT NULL,
        Quantity INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
        AddedDate DATETIME NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Cart_Users FOREIGN KEY (StudentId) REFERENCES dbo.Users(UserId),
        CONSTRAINT FK_Cart_Courses FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId)
    );
END;
GO
;WITH Duplicates AS (SELECT CartId,ROW_NUMBER() OVER(PARTITION BY StudentId,CourseId ORDER BY AddedDate,CartId) AS rn FROM dbo.Cart)
DELETE FROM Duplicates WHERE rn>1;
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='UX_Cart_Student_Course' AND object_id=OBJECT_ID('dbo.Cart'))
    CREATE UNIQUE INDEX UX_Cart_Student_Course ON dbo.Cart(StudentId, CourseId);
GO

IF OBJECT_ID('dbo.Orders', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Orders (
        OrderId INT IDENTITY(1,1) PRIMARY KEY,
        StudentId INT NOT NULL,
        OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
        TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
        PaymentMethod VARCHAR(20) NOT NULL CHECK (PaymentMethod IN ('bKash','Nagad','Card','Cash')),
        PaymentReference NVARCHAR(100) NULL,
        Status VARCHAR(20) NOT NULL DEFAULT 'Paid' CHECK (Status IN ('Pending','Paid','Cancelled')),
        CONSTRAINT FK_Orders_Users FOREIGN KEY (StudentId) REFERENCES dbo.Users(UserId)
    );
END;
GO
IF COL_LENGTH('dbo.Orders', 'PaymentReference') IS NULL
    ALTER TABLE dbo.Orders ADD PaymentReference NVARCHAR(100) NULL;
GO

IF OBJECT_ID('dbo.OrderItems', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.OrderItems (
        OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
        OrderId INT NOT NULL,
        CourseId INT NOT NULL,
        Quantity INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
        UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
        DiscountPercent DECIMAL(5,2) NOT NULL DEFAULT 0 CHECK (DiscountPercent BETWEEN 0 AND 100),
        Subtotal DECIMAL(10,2) NOT NULL CHECK (Subtotal >= 0),
        CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId),
        CONSTRAINT FK_OrderItems_Courses FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId)
    );
END;
GO
IF COL_LENGTH('dbo.OrderItems', 'DiscountPercent') IS NULL
    ALTER TABLE dbo.OrderItems ADD DiscountPercent DECIMAL(5,2) NOT NULL CONSTRAINT DF_OrderItems_Discount DEFAULT 0;
GO

IF OBJECT_ID('dbo.Reviews', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Reviews (
        ReviewId INT IDENTITY(1,1) PRIMARY KEY,
        StudentId INT NOT NULL,
        CourseId INT NOT NULL,
        Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
        Comment NVARCHAR(500) NULL,
        ReviewDate DATETIME NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Reviews_Users FOREIGN KEY (StudentId) REFERENCES dbo.Users(UserId),
        CONSTRAINT FK_Reviews_Courses FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId)
    );
END;
GO
;WITH Duplicates AS (SELECT ReviewId,ROW_NUMBER() OVER(PARTITION BY StudentId,CourseId ORDER BY ReviewDate DESC,ReviewId DESC) AS rn FROM dbo.Reviews)
DELETE FROM Duplicates WHERE rn>1;
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='UX_Reviews_Student_Course' AND object_id=OBJECT_ID('dbo.Reviews'))
    CREATE UNIQUE INDEX UX_Reviews_Student_Course ON dbo.Reviews(StudentId, CourseId);
GO

IF OBJECT_ID('dbo.Offers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Offers (
        OfferId INT IDENTITY(1,1) PRIMARY KEY,
        CourseId INT NOT NULL,
        DiscountPercent DECIMAL(5,2) NOT NULL CHECK (DiscountPercent BETWEEN 0 AND 100),
        StartDate DATE NOT NULL,
        EndDate DATE NOT NULL,
        CONSTRAINT CK_Offers_Dates CHECK (EndDate >= StartDate),
        CONSTRAINT FK_Offers_Courses FOREIGN KEY (CourseId) REFERENCES dbo.Courses(CourseId)
    );
END;
GO

IF OBJECT_ID('dbo.PayoutRequests', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PayoutRequests (
        PayoutId INT IDENTITY(1,1) PRIMARY KEY,
        InstituteId INT NOT NULL,
        RequestedAmount DECIMAL(10,2) NOT NULL CHECK (RequestedAmount > 0),
        RequestDate DATETIME NOT NULL DEFAULT GETDATE(),
        Status VARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Approved','Rejected')),
        ProcessedDate DATETIME NULL,
        CONSTRAINT FK_Payouts_Institutes FOREIGN KEY (InstituteId) REFERENCES dbo.Institutes(InstituteId)
    );
END;
GO

-- Passwords are SHA-256 hashes produced by LoginForm.HashPassword.
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email='owner@skillbazaar.com')
    INSERT dbo.Users (FullName,Email,Password,Phone,Address,UserType,Status) VALUES (N'Platform Owner','owner@skillbazaar.com','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9','01700000001',N'Dhaka, Bangladesh','SuperAdmin','Approved');
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email='rafiq@codersbd.com')
    INSERT dbo.Users (FullName,Email,Password,Phone,Address,UserType,Status) VALUES (N'Rafiq Ahmed','rafiq@codersbd.com','cde383eee8ee7a4400adf7a15f716f179a2eb97646b37e089eb8d6d04e663416','01700000002',N'Uttara, Dhaka','Admin','Approved');
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email='nusrat@examprep.com')
    INSERT dbo.Users (FullName,Email,Password,Phone,Address,UserType,Status) VALUES (N'Nusrat Jahan','nusrat@examprep.com','cde383eee8ee7a4400adf7a15f716f179a2eb97646b37e089eb8d6d04e663416','01700000003',N'Dhanmondi, Dhaka','Admin','Pending');
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email='kamal@mathguru.com')
    INSERT dbo.Users (FullName,Email,Password,Phone,Address,UserType,Status) VALUES (N'Kamal Hossain','kamal@mathguru.com','cde383eee8ee7a4400adf7a15f716f179a2eb97646b37e089eb8d6d04e663416','01700000004',N'Mirpur, Dhaka','Admin','Approved');
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email='samorpita@student.com')
    INSERT dbo.Users (FullName,Email,Password,Phone,Address,UserType,Status) VALUES (N'Samorpita Islam','samorpita@student.com','703b0a3d6ad75b649a28adde7d83c6251da457549263bc7ff45ec709b0a8448b','01700000005',N'Mirpur, Dhaka','Customer','Approved');
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email='tosim@student.com')
    INSERT dbo.Users (FullName,Email,Password,Phone,Address,UserType,Status) VALUES (N'Tosim Hossain','tosim@student.com','703b0a3d6ad75b649a28adde7d83c6251da457549263bc7ff45ec709b0a8448b','01700000006',N'Banani, Dhaka','Customer','Approved');
UPDATE dbo.Users SET Password='240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9' WHERE Email='owner@skillbazaar.com' AND LEN(Password)<>64;
UPDATE dbo.Users SET Password='cde383eee8ee7a4400adf7a15f716f179a2eb97646b37e089eb8d6d04e663416' WHERE Email IN ('rafiq@codersbd.com','nusrat@examprep.com','kamal@mathguru.com') AND LEN(Password)<>64;
UPDATE dbo.Users SET Password='703b0a3d6ad75b649a28adde7d83c6251da457549263bc7ff45ec709b0a8448b' WHERE Email IN ('samorpita@student.com','tosim@student.com') AND LEN(Password)<>64;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Institutes WHERE OwnerId=(SELECT UserId FROM dbo.Users WHERE Email='rafiq@codersbd.com'))
    INSERT dbo.Institutes (OwnerId,InstituteName,Category,Address,ContactPhone,Status) SELECT UserId,N'Coders BD Academy',N'Programming',Address,Phone,'Approved' FROM dbo.Users WHERE Email='rafiq@codersbd.com';
IF NOT EXISTS (SELECT 1 FROM dbo.Institutes WHERE OwnerId=(SELECT UserId FROM dbo.Users WHERE Email='nusrat@examprep.com'))
    INSERT dbo.Institutes (OwnerId,InstituteName,Category,Address,ContactPhone,Status) SELECT UserId,N'ExamPrep Institute',N'Admission Prep',Address,Phone,'Pending' FROM dbo.Users WHERE Email='nusrat@examprep.com';
IF NOT EXISTS (SELECT 1 FROM dbo.Institutes WHERE OwnerId=(SELECT UserId FROM dbo.Users WHERE Email='kamal@mathguru.com'))
    INSERT dbo.Institutes (OwnerId,InstituteName,Category,Address,ContactPhone,Status) SELECT UserId,N'MathGuru BD',N'Mathematics',Address,Phone,'Approved' FROM dbo.Users WHERE Email='kamal@mathguru.com';
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Title=N'C# OOP Fundamentals')
    INSERT dbo.Courses (InstituteId,Title,Category,Price,PricingType,DurationMonths,SeatsAvailable,MinSeats,Description) SELECT InstituteId,N'C# OOP Fundamentals',N'Programming',1500,'OneTime',NULL,40,10,N'Learn classes, inheritance, encapsulation and polymorphism through practical C# projects.' FROM dbo.Institutes WHERE InstituteName=N'Coders BD Academy';
IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Title=N'Full Stack Web Development')
    INSERT dbo.Courses (InstituteId,Title,Category,Price,PricingType,DurationMonths,SeatsAvailable,MinSeats,Description) SELECT InstituteId,N'Full Stack Web Development',N'Programming',3000,'Subscription',6,25,5,N'HTML, CSS, JavaScript, React and Node in a guided six month program.' FROM dbo.Institutes WHERE InstituteName=N'Coders BD Academy';
IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Title=N'Higher Math for Admission')
    INSERT dbo.Courses (InstituteId,Title,Category,Price,PricingType,DurationMonths,SeatsAvailable,MinSeats,Description) SELECT InstituteId,N'Higher Math for Admission',N'Mathematics',1800,'OneTime',NULL,30,8,N'Calculus, algebra and problem solving for university admission tests.' FROM dbo.Institutes WHERE InstituteName=N'MathGuru BD';
IF NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Title=N'Physics Admission Masterclass')
    INSERT dbo.Courses (InstituteId,Title,Category,Price,PricingType,DurationMonths,SeatsAvailable,MinSeats,Description) SELECT InstituteId,N'Physics Admission Masterclass',N'Physics',2200,'OneTime',NULL,18,5,N'Focused physics preparation with model tests and problem solving.' FROM dbo.Institutes WHERE InstituteName=N'MathGuru BD';
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Offers o JOIN dbo.Courses c ON o.CourseId=c.CourseId WHERE c.Title=N'C# OOP Fundamentals')
    INSERT dbo.Offers (CourseId,DiscountPercent,StartDate,EndDate) SELECT CourseId,20,DATEADD(day,-7,CAST(GETDATE() AS DATE)),DATEADD(day,30,CAST(GETDATE() AS DATE)) FROM dbo.Courses WHERE Title=N'C# OOP Fundamentals';
IF NOT EXISTS (SELECT 1 FROM dbo.Offers o JOIN dbo.Courses c ON o.CourseId=c.CourseId WHERE c.Title=N'Higher Math for Admission')
    INSERT dbo.Offers (CourseId,DiscountPercent,StartDate,EndDate) SELECT CourseId,10,DATEADD(day,-7,CAST(GETDATE() AS DATE)),DATEADD(day,30,CAST(GETDATE() AS DATE)) FROM dbo.Courses WHERE Title=N'Higher Math for Admission';
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Orders)
BEGIN
    DECLARE @StudentId INT=(SELECT UserId FROM dbo.Users WHERE Email='samorpita@student.com');
    DECLARE @CourseId INT=(SELECT CourseId FROM dbo.Courses WHERE Title=N'C# OOP Fundamentals');
    DECLARE @OrderId INT;
    INSERT dbo.Orders(StudentId,TotalAmount,PaymentMethod,PaymentReference,Status) VALUES(@StudentId,1200,'bKash','DEMO10001','Paid');
    SET @OrderId=SCOPE_IDENTITY();
    INSERT dbo.OrderItems(OrderId,CourseId,Quantity,UnitPrice,DiscountPercent,Subtotal) VALUES(@OrderId,@CourseId,1,1500,20,1200);
    SET @StudentId=(SELECT UserId FROM dbo.Users WHERE Email='tosim@student.com');
    SET @CourseId=(SELECT CourseId FROM dbo.Courses WHERE Title=N'Higher Math for Admission');
    INSERT dbo.Orders(StudentId,TotalAmount,PaymentMethod,PaymentReference,Status) VALUES(@StudentId,1620,'Card','DEMO10002','Paid');
    SET @OrderId=SCOPE_IDENTITY();
    INSERT dbo.OrderItems(OrderId,CourseId,Quantity,UnitPrice,DiscountPercent,Subtotal) VALUES(@OrderId,@CourseId,1,1800,10,1620);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Reviews)
BEGIN
    INSERT dbo.Reviews(StudentId,CourseId,Rating,Comment) SELECT u.UserId,c.CourseId,5,N'Clear lessons and useful practical examples.' FROM dbo.Users u CROSS JOIN dbo.Courses c WHERE u.Email='samorpita@student.com' AND c.Title=N'C# OOP Fundamentals';
    INSERT dbo.Reviews(StudentId,CourseId,Rating,Comment) SELECT u.UserId,c.CourseId,4,N'Good explanations and helpful admission practice.' FROM dbo.Users u CROSS JOIN dbo.Courses c WHERE u.Email='tosim@student.com' AND c.Title=N'Higher Math for Admission';
END;
GO
