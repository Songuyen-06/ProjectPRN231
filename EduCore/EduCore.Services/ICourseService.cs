


using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;

namespace EduCore.Services
{
    public interface ICourseService
    {
        Task AddStudentCourse(StudentCourseDTO sc);



        Task<List<CourseDTO>> GetListCourse();
        Task<List<CourseDTO>> GetListCourseByStudentId(int stdId, bool isInCart);

        Task AddCourse(CourseDTO cDTO);
        Task UpdateCourse(CourseDTO cDTO, int courseId);
        Task DeleteCourse(Course course);

        public Task<List<CourseDTO>> GetTopSellingCourses();

        public Task<List<CourseDTO>> GetTopSellingCoursesByCateId(int cateId);

        public Task<List<CourseDTO>> GetTopSellingCoursesBySubCateId(int subCateId);

        public Task<List<CourseDTO>> GetListCourseByInstructorId(int instructorId);
        public Task<List<CourseDTO>> GetEnrolledCourseListByStudentId(int stdId);


        public Task<CourseDetailDTO> GetCourseDetailByCourseId(int cId);

        public Task<CourseDetailDTO> GetStatusCourseDetailByStudentIdAndCourseId(int courseId, int stdId);
    }
}