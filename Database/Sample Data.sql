-- Insert Categories
INSERT INTO Categories (CategoryName) VALUES 
('Programming'),
('Web Development'),
('Database'),
('Data Science'),
('Mobile Development');
GO

-- Insert Instructor
INSERT INTO Instructors (Username, Password, FullName, Email) VALUES 
('rafiq', 'password123', 'Rafiq', 'rafiq@codersbd.com');
GO

-- Insert Sample Courses
INSERT INTO Courses (InstructorID, CategoryID, Title, Description, Price, TotalSeats, AvailableSeats) VALUES 
(1, 1, 'C# OOP Fundamentals', 'Learn C# Object-Oriented Programming', 1500, 40, 39),
(1, 2, 'Full Stack Web Dev', 'Complete Full Stack Development Course', 3000, 25, 3),
(1, 1, 'Data Structures in C#', 'Advanced Data Structures Course', 1800, 30, 28);
GO

-- Insert Sample Enrollments
INSERT INTO Enrollments (CourseID, StudentID) VALUES 
(1, 1), (2, 1);
GO

-- Insert Sample Reviews
INSERT INTO Reviews (CourseID, StudentID, Rating, Comment) VALUES 
(1, 1, 4, 'Great course!'),
(2, 1, 5, 'Excellent content!');
GO