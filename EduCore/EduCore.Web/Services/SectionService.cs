using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{


    public class SectionService : ISectionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute = "https://localhost:7004/api";

        public SectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SectionDTO>> GetAllSectionByCourseId(int courseId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7004/api/Section/getListSectionByCourseId/1");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<SectionDTO>>(); 
        }
    }
}
