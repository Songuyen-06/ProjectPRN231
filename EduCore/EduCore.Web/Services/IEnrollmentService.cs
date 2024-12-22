using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface IEnrollmentService
    {
        public Task<int> AddEnrollment(EnrollmentDTO e);
        public Task<List<EnrollmentDetailDTO>> GetListEnrollment();
        public Task<List<RevenueDTO>> GetMonthlyRevenueByInstructorId(int revenueSharePercentage,int instructorId, int year);
        public Task<List<RevenueDTO>> GetMonthlyRevenueBySoldCourses(int revenueSharePercentage, int year);

    }
}
