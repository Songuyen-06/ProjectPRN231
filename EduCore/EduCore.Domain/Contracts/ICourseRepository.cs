


using EduCore.Domain.DTOs;
using EduCore.Domain.Models;

namespace EduCore.Domain
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        

        public IQueryable<Course> GetListCourseByInclude();

        public Task<IEnumerable<Course>> GetListCourseByInstructorId(int Id);


        public  Task<IEnumerable<Course>> GetListCourseByStudentId(int stdId, bool isInCart);
        public Task<bool> IsExistingCourse(int courseId);

        public  IQueryable<Course> GetTopSellingCourses();
        public Task<IEnumerable<Course>> GetTopSellingCoursesByCateId(int cateId);

        public Task<Course> GetCourseDetailByCourseId(int Id);
<<<<<<< HEAD:EduCore/EduCore.Domain/Contracts/ICourseRepository.cs
        public  Task<IEnumerable<Course>> GetTopSellingCoursesBySubCateId(int subCateId);
=======
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/Contracts/ICourseRepository.cs

        public  Task<IEnumerable<Course>> GetEnrolledCourseListByStudentId(int stdId);

    }
}
