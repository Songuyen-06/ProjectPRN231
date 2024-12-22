<<<<<<< HEAD:EduCore/EduCore.Web/Services/ICertificateService.cs
﻿using EduCore.Domain;
using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
=======
﻿using CourseDomain;
using CourseDomain.DTOs;

namespace CourseWeb.Services
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseWeb/Services/ICertificateService.cs
{
    public interface ICertificateService
    {
        public Task<List<CertificateDTO>> GetCertificates();
        public Task<int> GetNumberCertificates();

    }
}
