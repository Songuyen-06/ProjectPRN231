using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface ICompletionStatusService
    {
        public Task<List<CompletionStatusDTO>> GetCompletionStatusListByStudentId(int stdId);
    }
}
