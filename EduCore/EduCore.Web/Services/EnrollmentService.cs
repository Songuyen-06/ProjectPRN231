using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System.Text;
using System.Text.Json;

namespace EduCore.Web.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute;

        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAPIRoute = "https://localhost:7004/api";
        }


        public async Task<int> AddEnrollment(EnrollmentDTO e)
        {
            var response = await _httpClient.PostAsync($"{_baseAPIRoute}/Enrollment/addEnrollment", new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode ? 1 : -1;
        }

        public async Task<List<EnrollmentDetailDTO>> GetListEnrollment()
        {
            return await _httpClient.GetAsync($"{_baseAPIRoute}/Enrollment/getListEnrollment").Result.Content.ReadFromJsonAsync<List<EnrollmentDetailDTO>>();
        }

        public async Task<List<RevenueDTO>> GetMonthlyRevenueByInstructorId(int revenueSharePercentage, int instructorId, int year)
        {
            return await _httpClient.GetAsync($"{_baseAPIRoute}/Enrollment/getMonthlyRevenueByInstructorId/{revenueSharePercentage}/{instructorId}/{year}").Result.Content.ReadFromJsonAsync<List<RevenueDTO>>();


        } 
        public async Task<List<RevenueDTO>> GetMonthlyRevenueBySoldCourses(int revenueSharePercentage, int year)
        {
            return await _httpClient.GetAsync($"{_baseAPIRoute}/Enrollment/getMonthlyRevenueBySoldedCourses/{revenueSharePercentage}/{year}").Result.Content.ReadFromJsonAsync<List<RevenueDTO>>();


        }
    }
}
