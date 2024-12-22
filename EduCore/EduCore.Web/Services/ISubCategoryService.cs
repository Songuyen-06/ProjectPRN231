using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface ISubCategoryService
    {
        public Task<List<SubCategoryDTO>> GetAllSubCategory();
    }
}
