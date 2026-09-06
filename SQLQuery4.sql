USE SkillBazaar;
GO

-- 1. Insert Users (Generates UserIds 1 through 6)
INSERT INTO Users (FullName, Email, Password, Phone, Address, UserType, Status) VALUES
('Platform Owner', 'owner@skillbazaar.com', 'hashed_pw_1', '01700000001', 'Dhaka, Bangladesh', 'SuperAdmin', 'Approved'),
('Rafiq Ahmed', 'rafiq@codersbd.com', 'hashed_pw_2', '01700000002', 'Uttara, Dhaka', 'Admin', 'Approved'),
('Nusrat Jahan', 'nusrat@examprep.com', 'hashed_pw_3', '01700000003', 'Dhanmondi, Dhaka', 'Admin', 'Pending'),
('Samorpita Islam', 'samorpita@student.com', 'hashed_pw_4', '01700000004', 'Mirpur, Dhaka', 'Customer', 'Approved'),
('Tosim Hossain', 'tosim@student.com', 'hashed_pw_5', '01700000005', 'Banani, Dhaka', 'Customer', 'Approved'),
('Fahim Rahman', 'fahim@student.com', 'hashed_pw_6', '01700000006', 'Mohammadpur, Dhaka', 'Customer', 'Approved');

-- 2. Insert Institutes (Uses OwnerIds 2 and 3)
INSERT INTO Institutes (OwnerId, InstituteName, Category, Address, ContactPhone, Status) VALUES
(2, 'Coders BD Academy', 'Programming', 'Uttara, Dhaka', '01700000002', 'Approved'),
(3, 'ExamPrep Institute', 'Admission Prep', 'Dhanmondi, Dhaka', '01700000003', 'Pending');

-- 3. Insert Courses (Uses InstituteIds 1 and 2)
INSERT INTO Courses (InstituteId, Title, Category, Price, PricingType, DurationMonths, SeatsAvailable, MinSeats, Description, ImagePath) VALUES
(1, 'C# OOP Fundamentals', 'Programming', 1500.00, 'OneTime', NULL, 40, 10, 'Learn classes, inheritance, polymorphism in C#.', 'img/csharp.png'),
(1, 'Full Stack Web Development', 'Programming', 3000.00, 'Subscription', 6, 25, 5, 'HTML, CSS, JS, React and Node in 6 months.', 'img/webdev.png'),
(2, 'AIUB Admission Crash Course', 'Admission Prep', 2000.00, 'OneTime', NULL, 60, 15, 'Complete prep for AIUB admission test.', 'img/admission.png');

-- 4. Insert Cart Items (Uses StudentIds 4, 5, 6 and CourseIds 1, 2, 3)
INSERT INTO Cart (StudentId, CourseId, Quantity) VALUES
(4, 1, 1),
(5, 3, 1),
(6, 2, 1);

-- 5. Insert Orders
INSERT INTO Orders (StudentId, OrderDate, TotalAmount, PaymentMethod, Status) VALUES
(4, '2026-08-01 10:15:00', 1500.00, 'bKash', 'Paid'),
(5, '2026-08-05 14:30:00', 2000.00, 'Card', 'Paid'),
(6, '2026-08-10 09:00:00', 3000.00, 'Nagad', 'Pending');

-- 6. Insert Order Items (Linking Orders to Courses)
INSERT INTO OrderItems (OrderId, CourseId, Quantity, UnitPrice, Subtotal) VALUES
(1, 1, 1, 1500.00, 1500.00),
(2, 3, 1, 2000.00, 2000.00),
(3, 2, 1, 3000.00, 3000.00);

-- 7. Insert Reviews
INSERT INTO Reviews (StudentId, CourseId, Rating, Comment, ReviewDate) VALUES
(4, 1, 5, 'Excellent explanation of OOP concepts, very practical.', '2026-08-03 12:00:00'),
(5, 3, 2, 'Content was too basic for the price.', '2026-08-06 18:20:00'),
(6, 2, 4, 'Good course but the pace is fast.', '2026-08-11 20:10:00');

-- 8. Insert Offers
INSERT INTO Offers (CourseId, DiscountPercent, StartDate, EndDate) VALUES
(1, 20.00, '2026-08-10', '2026-08-31'),
(3, 15.00, '2026-08-01', '2026-08-20');
GO