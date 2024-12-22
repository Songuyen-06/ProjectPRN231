using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public class LectureService : ILectureService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute = "https://localhost:7004/api";
        public LectureService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<LectureDetailDTO> GetLectureDetailById(int id)
        {
            return await _httpClient.GetAsync($"{_baseAPIRoute}/Lecture/getLectureDetailById/{id}").Result.
               Content.ReadFromJsonAsync<LectureDetailDTO>();
        }
    }
}
