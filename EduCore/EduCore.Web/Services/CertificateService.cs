<<<<<<< HEAD:EduCore/EduCore.Web/Services/CertificateService.cs
﻿using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
=======
﻿using CourseDomain.DTOs;

namespace CourseWeb.Services
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseWeb/Services/CertificateService.cs
{
    public class CertificateService : ICertificateService

    {
        private readonly HttpClient _httpClient;
        private readonly string APIRoute = "https://localhost:7004/api";

        public CertificateService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<CertificateDTO>> GetCertificates()
        {
            return await _httpClient.GetAsync($"{APIRoute}/Certificate/getListCertificate").Result.Content.ReadFromJsonAsync<List<CertificateDTO>>();
        }
        public async Task<int> GetNumberCertificates()
        {
            return await _httpClient.GetAsync("https://localhost:7004/odata/Certificate/$count").Result.Content.ReadFromJsonAsync<int>();

        }
    }
}
