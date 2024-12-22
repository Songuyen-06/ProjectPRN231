using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute = "https://localhost:7004/api";

        public SubCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<SubCategoryDTO>> GetAllSubCategory()
        {
            var response = await _httpClient.GetAsync("https://localhost:7004/SubCategories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<SubCategoryDTO>>();
        }
    }
}
