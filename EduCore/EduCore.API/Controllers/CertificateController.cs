using EduCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
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
