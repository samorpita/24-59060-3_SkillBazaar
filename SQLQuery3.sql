-- 1. First, make sure you are using your project's database
USE SkillBazaar;
GO

-- 2. Create the Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Phone VARCHAR(20),
    Address VARCHAR(200),
    UserType VARCHAR(20) NOT NULL CHECK (UserType IN ('SuperAdmin', 'Admin', 'Customer')),
    Status VARCHAR(20) NOT NULL DEFAULT 'Approved' CHECK (Status IN ('Pending', 'Approved', 'Suspended')),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- 3. Create the Institutes table (Required before Courses because of the Foreign Key)
CREATE TABLE Institutes (
    InstituteId INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId INT NOT NULL,
    InstituteName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Address VARCHAR(200),
    ContactPhone VARCHAR(20),
    Status VARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Approved', 'Suspended')),
    FOREIGN KEY (OwnerId) REFERENCES Users(UserId)
);

-- 4. Create the Courses table
CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    InstituteId INT NOT NULL,
    Title VARCHAR(150) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    PricingType VARCHAR(20) NOT NULL DEFAULT 'OneTime' CHECK (PricingType IN ('OneTime', 'Subscription')),
    DurationMonths INT NULL,
    SeatsAvailable INT NOT NULL DEFAULT 0 CHECK (SeatsAvailable >= 0),
    MinSeats INT NOT NULL DEFAULT 5,
    Description VARCHAR(1000),
    ImagePath VARCHAR(255),
    FOREIGN KEY (InstituteId) REFERENCES Institutes(InstituteId)
);

-- 5. Create the Cart table
CREATE TABLE Cart (
    CartId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    AddedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

-- 6. Create the Orders table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    PaymentMethod VARCHAR(20) NOT NULL CHECK (PaymentMethod IN ('bKash', 'Nagad', 'Card', 'Cash')),
    Status VARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Paid', 'Cancelled')),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId)
);

-- 7. Create the OrderItems junction table
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    CourseId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

-- 8. Create the Reviews table
CREATE TABLE Reviews (
    ReviewId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Comment VARCHAR(500),
    ReviewDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Users(UserId),
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

-- 9. Create the Offers table
CREATE TABLE Offers (
    OfferId INT IDENTITY(1,1) PRIMARY KEY,
    CourseId INT NOT NULL,
    DiscountPercent DECIMAL(5,2) NOT NULL CHECK (DiscountPercent BETWEEN 0 AND 100),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO