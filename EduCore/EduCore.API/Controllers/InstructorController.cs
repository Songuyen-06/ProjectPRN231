using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        IInstructorService instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            this.instructorService = instructorService;
        }
        [HttpGet("getListInstructor")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {

            return Ok(await instructorService.GetListInstructor());
        }
        [HttpGet("getInstructorDetailById/{instructorId}")]
        public async Task<IActionResult> GetInstructorDetailById(int instructorId)
        {

            return Ok(await instructorService.GetInstructorDetailById(instructorId));
        }     
        
        
        
        
        }
    }

