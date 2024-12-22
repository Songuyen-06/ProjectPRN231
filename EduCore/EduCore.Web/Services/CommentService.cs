
using EduCore.Domain.DTOs;
using System.Text;
using System.Text.Json;

namespace EduCore.Web.Services
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAPIRoute = "https://localhost:7004/api";
        }

        public async Task<int> AddComment(AddedCommentDTO comment)
        {

            var response = await _httpClient.PostAsync($"{_baseAPIRoute}/Comment/addComment", new StringContent(JsonSerializer.Serialize(comment), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode ? 1 : -1;
        }

        public async Task<CommentDTO> GetCommentById(int? id)
        {
            return await _httpClient.GetAsync($"{_baseAPIRoute}/Comment/getCommentById/{id}").Result.Content.ReadFromJsonAsync<CommentDTO>();
        }
    }
}
