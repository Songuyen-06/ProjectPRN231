using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface IStudentService
    {
        public Task<int> GetNumberStudents();
        public Task<List<StudentDTO>> GetListStudent();

    }
}
