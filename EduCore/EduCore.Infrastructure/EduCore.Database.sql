--create database Courses--- ;
 use Courses;
-- B?ng Role
-- B?ng Role
CREATE TABLE Role (
   RoleID INT PRIMARY KEY IDENTITY,
   Name VARCHAR(50) NOT NULL
);

-- Insert m?u
INSERT INTO Role (Name)
VALUES
    ('Student'),
    ('Instructor'),
    ('Admin');

-- B?ng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    FullName VARCHAR(100),
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(100),
    Password VARCHAR(255) NOT NULL,
    Bio NVARCHAR(500),
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);

-- Insert m?u
INSERT INTO Users (FullName, Email, Phone, Password, Bio, RoleID)
VALUES
    ('John Doe', 'john.doe@example.com', '123-456-7890', 'password123', 'Software engineer with 5 years of experience', 1),
    ('Jane Smith', 'jane.smith@example.com', '987-654-3210', 'password456', 'Web developer interested in UX design', 2),
    ('Michael Johnson', 'michael.johnson@example.com', '456-789-0123', 'password789', 'Machine learning researcher', 1),
    ('Emily Brown', 'emily.brown@example.com', '789-012-3456', 'passwordabc', 'Data scientist with a focus on natural language processing', 3);

-- B?ng Categories
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
);

-- Insert m?u
INSERT INTO Categories (Name)
VALUES
    ('Programming'),
    ('Web Development'),
    ('Machine Learning'),
    ('Data Science');

-- B?ng Courses
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY,
    Title VARCHAR(255) NOT NULL,
    InstructorID INT,
    Description TEXT,
    Level VARCHAR(50),
    Duration VARCHAR(50),
    Price DECIMAL(10, 2),
    Rating DECIMAL(2, 1),
    CategoryID INT,  
	URL VARCHAR(255),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)  ,
    FOREIGN KEY (InstructorID) REFERENCES Users(UserID)  

);

-- Insert m?u
INSERT INTO Courses (Title, InstructorID, Description, Level, Duration, Price, Rating, CategoryID)
VALUES
    ('Introduction to Programming', 1, 'Learn the basics of programming', 'Beginner', '6 weeks', 99.99, 4.5, 1),
    ('Web Development Bootcamp', 2, 'Comprehensive course on web development', 'Intermediate', '12 weeks', 199.99, 4.8, 2),
    ('Machine Learning Essentials', 3, 'Fundamentals of machine learning', 'Advanced', '8 weeks', 149.99, 4.2, 3),
    ('Data Science Foundations', 4, 'Introduction to data science concepts', 'Intermediate', '10 weeks', 129.99, 4.6, 4);

-- B?ng Sections
CREATE TABLE Sections (
    SectionID INT PRIMARY KEY IDENTITY,
    CourseID INT,
    Title VARCHAR(255) NOT NULL,
    Duration VARCHAR(50),
    Position INT,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Insert m?u
INSERT INTO Sections (CourseID, Title, Duration, Position)
VALUES
    (1, 'Introduction to Programming Basics', '2 weeks', 1),
    (1, 'Advanced Programming Concepts', '4 weeks', 2),
    (2, 'HTML and CSS Fundamentals', '3 weeks', 1),
    (3, 'Linear Regression', '2 weeks', 1);

-- B?ng Lectures
CREATE TABLE Lectures (
    LectureID INT PRIMARY KEY IDENTITY,
    SectionID INT,
    Title VARCHAR(255) NOT NULL,
    Content TEXT,
    VideoURL VARCHAR(255), 
    Duration VARCHAR(50),
    Position INT,
    FOREIGN KEY (SectionID) REFERENCES Sections(SectionID)
);

-- Insert m?u
INSERT INTO Lectures (SectionID, Title, Content, VideoURL, Duration, Position)
VALUES
    (1, 'Introduction to Programming Languages', 'Basic concepts of programming languages', 'https://example.com/lecture1', '30 minutes', 1),
    (1, 'Variables and Data Types', 'Understanding variables and data types in programming', 'https://example.com/lecture2', '45 minutes', 2),
    (2, 'Object-Oriented Programming', 'Principles of object-oriented programming', 'https://example.com/lecture3', '1 hour', 1),
    (3, 'Introduction to HTML', 'Basic tags and structure in HTML', 'https://example.com/lecture4', '45 minutes', 1);

-- B?ng StudentCourses
CREATE TABLE StudentCourses (
    UserID INT,
    CourseID INT,
    IsInCart BIT NOT NULL,
    PRIMARY KEY(UserID, CourseID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Insert m?u
INSERT INTO StudentCourses (UserID, CourseID, IsInCart)
VALUES
    (1, 1, 0), -- John Doe enrolled in Introduction to Programming
    (2, 2, 1), -- Jane Smith added Web Development Bootcamp to cart
    (3, 3, 0), -- Michael Johnson enrolled in Machine Learning Essentials
    (4, 4, 0); -- Emily Brown enrolled in Data Science Foundations

-- B?ng Enrollments
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Insert m?u
INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
VALUES
    (1, 1, '2024-06-18'), -- John Doe enrolled in Introduction to Programming
    (2, 2, '2024-06-19'), -- Jane Smith enrolled in Web Development Bootcamp
    (3, 3, '2024-06-20'), -- Michael Johnson enrolled in Machine Learning Essentials
    (4, 4, '2024-06-21'); -- Emily Brown enrolled in Data Science Foundations

-- B?ng Reviews
CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY IDENTITY,
    StudentID INT,
    CourseID INT,
    Rating DECIMAL(2, 1) NOT NULL,
    Comment TEXT,
    ReviewDate DATE NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Insert m?u
INSERT INTO Reviews (StudentID, CourseID, Rating, Comment, ReviewDate)
VALUES
    (1, 1, 4.5, 'Great course for beginners!', '2024-06-18'),
    (2, 2, 4.8, 'Excellent content and explanations.', '2024-06-19'),
    (3, 3, 4.2, 'Could use more practical examples.', '2024-06-20'),
    (4, 4, 4.6, 'Informative and well-structured.', '2024-06-21');


	CREATE TABLE Checkouts (
    CheckoutID INT PRIMARY KEY IDENTITY,
    StudentID INT,
    CourseID INT,
    PaymentDate DATE NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentStatus VARCHAR(50) NOT NULL,
    TransactionID VARCHAR(255) NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Users(UserID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
-- Chèn dữ liệu vào bảng Checkouts
INSERT INTO Checkouts (StudentID, CourseID, PaymentDate, Amount, PaymentStatus, TransactionID)
VALUES (2, 1, '2024-06-19', 49.99, 'Completed', 'TXN1234567890'),
       (2, 2, '2024-06-20', 59.99, 'Completed', 'TXN0987654321');

-- Tạo bảng Certificate
CREATE TABLE Certificates (
    CertificateId INT PRIMARY KEY,
    Title NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    CompletionDate DATE NOT NULL,
    CompletionTime TIME NOT NULL,
    IssuedBy NVARCHAR(MAX) NOT NULL,
    CertificateUrl NVARCHAR(MAX) NOT NULL
);

-- Tạo bảng StudentCertificates
CREATE TABLE StudentCertificates (
    UserId INT,
    CertificateId INT,
    PRIMARY KEY (UserId, CertificateId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),  -- Đảm bảo thay thế Users bằng tên bảng người dùng thực tế nếu khác
    FOREIGN KEY (CertificateId) REFERENCES Certificates(CertificateId)
);

-- Insert dữ liệu vào bảng Certificate
INSERT INTO Certificates (CertificateId, Title, Description, CompletionDate, CompletionTime, IssuedBy, CertificateUrl)
VALUES
(1, 'Certificate of Achievement', 'This certificate recognizes achievement in the course.', '2024-06-27', '12:00:00', 'Course Academy', 'https://example.com/certificate1'),
(2, 'Advanced Certificate', 'Advanced certification for specialized skills.', '2024-06-25', '14:30:00', 'Education Hub', 'https://example.com/certificate2');

-- Insert dữ liệu vào bảng StudentCertificate
INSERT INTO StudentCertificates (UserId, CertificateId)
VALUES
(1, 1),  -- UserId = 1, CertificateId = 1
(2, 2);  -- UserId = 2, CertificateId = 2
