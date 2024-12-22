using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public ISectionService _sectionService { get; set; }

        [HttpGet("getListSectionByCourseId/{courseId}")]
        [EnableQuery]
        public async Task<IActionResult> Get(int courseId)
        {

            var sections = await _sectionService.GetListSectionByCourseId(courseId);
            return Ok(sections);
        }
    }

}

