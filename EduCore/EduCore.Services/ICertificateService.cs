<<<<<<< HEAD:EduCore/EduCore.Services/ICertificateService.cs
﻿using EduCore.Domain.DTOs;
=======
﻿using CourseDomain.DTOs;
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseService/ICertificateService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:EduCore/EduCore.Services/ICertificateService.cs
namespace EduCore.Services
=======
namespace CourseServices
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseService/ICertificateService.cs
{
    public interface ICertificateService
    {
        public Task<IEnumerable<CertificateDTO>> GetListCertificate();

    }
}
