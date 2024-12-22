using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        public readonly ILectureService lectureService;
        public LectureController(ILectureService _lectureService)
        {
            lectureService = _lectureService;
        }
        [HttpGet("getLectureDetailById/{lectureId}")]
        public async Task<IActionResult> GetLectureDetailById(int lectureId)
        {
            return Ok(await lectureService.GetLectureDetailById(lectureId));
        }
    }
}
