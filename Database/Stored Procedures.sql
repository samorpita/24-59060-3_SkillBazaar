-- Get Instructor Dashboard Data
CREATE PROCEDURE sp_GetInstructorDashboard
    @InstructorID INT
AS
BEGIN
    -- Get total courses
    SELECT COUNT(*) AS TotalCourses FROM Courses WHERE InstructorID = @InstructorID AND IsActive = 1;
    
    -- Get total enrollments
    SELECT COUNT(DISTINCT e.StudentID) AS TotalEnrollments 
    FROM Enrollments e 
    INNER JOIN Courses c ON e.CourseID = c.CourseID 
    WHERE c.InstructorID = @InstructorID;
    
    -- Get total earnings and available balance (after 20% fee)
    SELECT 
        ISNULL(SUM(c.Price), 0) AS TotalEarnings,
        ISNULL(SUM(c.Price * 0.8), 0) AS AvailableBalance
    FROM Enrollments e 
    INNER JOIN Courses c ON e.CourseID = c.CourseID 
    WHERE c.InstructorID = @InstructorID;
    
    -- Get average rating
    SELECT ISNULL(AVG(r.Rating), 0) AS AvgRating
    FROM Reviews r 
    INNER JOIN Courses c ON r.CourseID = c.CourseID 
    WHERE c.InstructorID = @InstructorID;
    
    -- Get course statistics
    SELECT 
        c.CourseID,
        c.Title,
        c.Price,
        c.TotalSeats,
        (c.TotalSeats - c.AvailableSeats) AS Enrolled,
        c.AvailableSeats AS SeatsLeft,
        CASE 
            WHEN c.AvailableSeats > 10 THEN 'OK'
            WHEN c.AvailableSeats BETWEEN 5 AND 10 THEN 'LOW SEATS'
            ELSE 'CRITICAL'
        END AS SeatStatus
    FROM Courses c 
    WHERE c.InstructorID = @InstructorID AND c.IsActive = 1;
END
GO

-- Get Courses with Search and Filter
CREATE PROCEDURE sp_GetInstructorCourses
    @InstructorID INT,
    @SearchTerm NVARCHAR(100) = NULL,
    @CategoryID INT = NULL
AS
BEGIN
    SELECT 
        c.CourseID,
        c.Title,
        cat.CategoryName,
        c.Price,
        c.TotalSeats,
        (c.TotalSeats - c.AvailableSeats) AS EnrolledSeats,
        c.AvailableSeats AS AvailableSeats,
        c.IsActive
    FROM Courses c
    INNER JOIN Categories cat ON c.CategoryID = cat.CategoryID
    WHERE c.InstructorID = @InstructorID
    AND (@SearchTerm IS NULL OR c.Title LIKE '%' + @SearchTerm + '%')
    AND (@CategoryID IS NULL OR c.CategoryID = @CategoryID)
    ORDER BY c.CreatedDate DESC;
END
GO

-- Update Course
CREATE PROCEDURE sp_UpdateCourse
    @CourseID INT,
    @Title NVARCHAR(200),
    @Price DECIMAL(10,2),
    @TotalSeats INT,
    @CategoryID INT
AS
BEGIN
    UPDATE Courses 
    SET 
        Title = @Title,
        Price = @Price,
        TotalSeats = @TotalSeats,
        AvailableSeats = @TotalSeats - (SELECT COUNT(*) FROM Enrollments WHERE CourseID = @CourseID),
        CategoryID = @CategoryID
    WHERE CourseID = @CourseID;
END
GO

-- Get Seat Availability
CREATE PROCEDURE sp_GetSeatAvailability
    @InstructorID INT
AS
BEGIN
    SELECT 
        c.CourseID,
        c.Title,
        c.TotalSeats,
        c.AvailableSeats,
        CASE 
            WHEN c.AvailableSeats > 10 THEN 10
            WHEN c.AvailableSeats BETWEEN 5 AND 10 THEN 5
            ELSE 1
        END AS MinThreshold,
        CASE 
            WHEN c.AvailableSeats > 10 THEN 'OK'
            WHEN c.AvailableSeats BETWEEN 5 AND 10 THEN 'LOW SEATS'
            ELSE 'CRITICAL'
        END AS Status
    FROM Courses c 
    WHERE c.InstructorID = @InstructorID AND c.IsActive = 1;
    
    -- Count low seat courses
    SELECT COUNT(*) AS LowSeatCount
    FROM Courses c 
    WHERE c.InstructorID = @InstructorID 
    AND c.IsActive = 1 
    AND c.AvailableSeats <= 10;
END
GO

-- Request Payout
CREATE PROCEDURE sp_RequestPayout
    @InstructorID INT,
    @Amount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Payouts (InstructorID, Amount, Status, PayoutDate)
    VALUES (@InstructorID, @Amount, 'Pending', GETDATE());
END
GO