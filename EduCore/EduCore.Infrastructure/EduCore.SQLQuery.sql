select * from dbo.Users u where u.UserID=2

select * from dbo.Courses  c where c.SubCategoryId=1

select * from dbo.Courses  c where c.SubCategoryId=2 and c.Price =0 and c.Level='Beginner'

select * from dbo.Courses  c where c.SubCategoryId in (select s.SubCategoryId  from dbo.SubCategory s where s.CategoryId=1) order by c.CreateTime desc


SELECT TOP (1000) [EnrollmentID]
      ,e.[StudentID]
      ,e.[CourseID]
      ,e.[EnrollmentDate],
	  c.InstructorID
  FROM [CoursesDB].[dbo].[Enrollments]   e 
  join dbo.Courses c on e.CourseID = c.CourseID
  where  Year(e.EnrollmentDate)=2024 and MONTH(e.EnrollmentDate)=10 and c.InstructorID=2



  SELECT 
    MONTH(e.EnrollmentDate) AS Month,
    YEAR(e.EnrollmentDate) AS Year,
    SUM(c.Price - (c.Price * c.Sale / 100)) AS Amount
FROM 
    [CoursesDB].[dbo].[Enrollments] e
JOIN 
    [CoursesDB].[dbo].[Courses] c ON e.CourseID = c.CourseID
WHERE 



    YEAR(e.EnrollmentDate) = 2024
    AND c.InstructorId = 2
GROUP BY 
    MONTH(e.EnrollmentDate), YEAR(e.EnrollmentDate)
ORDER BY 
    Month;

    select * from Courses c where c.InstructorID=4


	select e.StudentID, (c.Price-(c.Price*c.Sale/100))as Price from Enrollments e JOIN 
    [CoursesDB].[dbo].[Courses] c ON e.CourseID = c.CourseID
	where   MONTH(e.EnrollmentDate)=11 and  YEAR(e.EnrollmentDate) =2024     and     e.CourseID=99;


select * from Users u where u.RoleID=1


 alter table  dbo.Users 
  add column  IsVerified(BIT DEFAULT 0), 