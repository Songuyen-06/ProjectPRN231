using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface IReviewService
    {
        public Task<List<ReviewDTO>> GetListReview();


    }
}
