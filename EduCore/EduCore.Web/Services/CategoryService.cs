using EduCore.Domain.DTOs;
using System.Text;
using System.Text.Json;

namespace EduCore.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string APIRoute = "https://localhost:7004/api";

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }

        public async Task<CategoryDTO> GetCategoryByCateId(int cateId)
        {
            var response = await _httpClient.GetAsync($"{APIRoute}/Category/GetCategoryByCateId/{cateId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();

        }
        public async Task<List<CategoryDTO>> GetListCategory()
        {
            var response = await _httpClient.GetAsync($"{APIRoute}/Category/GetListCategory");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
        }
        public async Task<bool> UpdateCategory(CategoryDTO category)
        {
            var jsonContent = JsonSerializer.Serialize(category);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{APIRoute}/Category/UpdateCategory", httpContent);
            return response.IsSuccessStatusCode;
        }
        public async Task DeleteCategory(int categoryId)
        {
            var response = await _httpClient.DeleteAsync($"{APIRoute}/Category/deleteCategory/{categoryId}");
            response.EnsureSuccessStatusCode();
        }
        public async Task AddCategory(CategoryDTO category)
        {
            var jsonContent = JsonSerializer.Serialize(category);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{APIRoute}/Category/AddCategory", httpContent);
            response.EnsureSuccessStatusCode();
        }
        public async Task<int> GetNumberCategories()
        {
            return await _httpClient.GetAsync("https://localhost:7004/odata/Category/$count").Result.Content.ReadFromJsonAsync<int>();
        }
    }
}
