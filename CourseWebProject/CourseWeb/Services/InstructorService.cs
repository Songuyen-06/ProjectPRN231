﻿using CourseDomain.DTOs;

namespace CourseWeb.Services
{
    public class InstructorService : IInstructorService

    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAPIRoute = "https://localhost:7004/api";

        public InstructorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<InstructorDTO>> GetListInstructor()
        {
            return _httpClient.GetAsync($"{_baseAPIRoute}/Instructor/getListInstructor").Result.Content.ReadFromJsonAsync<List<InstructorDTO>>();
        }
    }
}