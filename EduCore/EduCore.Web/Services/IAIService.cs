using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface IAIService
    {
        public Task<double> EvaluateAnswer();

    }
}
