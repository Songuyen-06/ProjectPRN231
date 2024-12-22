using EduCore.Domain.DTOs;
using System.Collections;

namespace EduCore.Web.Services
{
    public interface ICourseService
    {
        public  Task<CourseDetailDTO> GetStatusCourseDetailByStudentIdAndCourseId(int courseId, int stdId);


        public Task<List<CourseDTO>> GetTopSellingCourses();

        public Task<List<CourseDTO>> GetTopSellingCoursesByCateId(int? cateId);
        public Task<List<CourseDTO>> GetTopSellingCoursesBySubCateId(int? subCateId);

        public Task<CourseDetailDTO> GetCourseDetailByCourseId(int courseId);

        public Task<int> GetNumberCourses(string filter = "true");

        public Task<List<CourseDTO>> GetListCoursesBySubCategoryId(int? subCateId);



        public Task<List<CourseDTO>> GetListCourseByInstructorId(int instructorId);

        public int GetTotalPageCourse(int numberCourse, int pageSize);

        public Task<List<CourseDTO>> GetListRelatedCourseBySubcates(List<SubCategoryDetailDTO> subCategories);

        Task<List<CourseDTO>> GetListCourseByStudentId(int stdId, bool isInCart);

        public Task<int> AddStudentCourse(StudentCourseDTO stC);

        public Task<List<CourseDTO>> GetListCourseByFilter(int  cateId,int? subCateId, string? levels, int? rating, string? price, string sortBy);

        public List<CourseDTO> GetListCourseByPagging(List<CourseDTO> courses, int pageIndex, int pageSize);

        public   Task DownloadFileAsync(string fileUrl, string saveDirectory);
        public Task DownloadFilesAsync(List<string> fileUrls, string saveDirectory);


        public Task<List<CourseDTO>> GetEnrolledCourseListByStudentId(int stdId);

    }
}
