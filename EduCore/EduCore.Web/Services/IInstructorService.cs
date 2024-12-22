using EduCore.Domain.DTOs;
using System.Collections;

namespace EduCore.Web.Services
{
    public interface IInstructorService
    {
        public Task<List<InstructorDTO>> GetListInstructor(string searchInfo = null);

        public Task<List<InstructorDTO>> GetListInstructorByFilter(int? cateId, int? subCateId, int? rating = null, string? status = null);
        public Task<int> GetNumberInstructors();
        public int GetNumberPageInstructor(int numberInstructor);
        public Task<InstructorDetailDTO> GetInstructorDetailById(int id);

        public Task<List<InstructorDTO>> SortInstructorList(string sortBy, List<InstructorDTO> instructors);

    }
}
