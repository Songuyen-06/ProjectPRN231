
using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public class StudentService : IStudentService

    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute = "https://localhost:7004/api";

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetNumberStudents()
        {
            return await _httpClient.GetAsync("https://localhost:7004/odata/User/$count?$filter=roleId eq 1").Result.Content.ReadFromJsonAsync<int>();
        }
        public async Task<List<StudentDTO>> GetListStudent()
        {
            var response = await _httpClient.GetAsync($"{_baseAPIRoute}/Student/getListStudent");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<StudentDTO>>();
            }
            return null;
        }
    }
}
