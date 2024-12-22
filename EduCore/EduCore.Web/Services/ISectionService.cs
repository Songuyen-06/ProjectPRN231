using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface ISectionService
    {
        public Task<List<SectionDTO>> GetAllSectionByCourseId(int courseId);
    }
}
