<<<<<<< HEAD:EduCore/EduCore.API/Controllers/CertificateController.cs
﻿using EduCore.Services;
=======
﻿using CourseServices;
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseAPI/Controllers/CertificateController.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

<<<<<<< HEAD:EduCore/EduCore.API/Controllers/CertificateController.cs
namespace EduCore.API.Controllers
=======
namespace CourseAPI.Controllers
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseAPI/Controllers/CertificateController.cs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
      public   ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        [HttpGet("getListCertificate")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _certificateService.GetListCertificate());
        }
    }
}
