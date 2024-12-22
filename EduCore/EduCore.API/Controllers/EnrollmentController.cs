using EduCore.Domain.DTOs;
using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        public IEnrollmentService enrollmentService { get; set; }
        public EnrollmentController(IEnrollmentService _enrollmentService)
        {
            enrollmentService = _enrollmentService;
        }

        [HttpPost("addEnrollment")]
        public async Task<IActionResult> AddEnrollment([FromBody] EnrollmentDTO e)
        {
            try
            {
                await enrollmentService.AddEnrollment(e);
                return Ok(new { message = "Enrollment added successfully." });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while adding the enrollment.", details = ex.Message });
            }
        }
        [HttpGet("getListEnrollment")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await enrollmentService.GetListEnrollment());
        }
        [HttpGet("getMonthlyRevenueByInstructorId/{revenueSharePercentage}/{instructorId}/{year}")]
        public async Task<IActionResult> GetMonthlyRevenueByInstructorId(int revenueSharePercentage,int instructorId, int year)
        {

            return Ok(await enrollmentService.GetMonthlyRevenueByInstructorId(revenueSharePercentage, instructorId, year));
        } 
        
        [HttpGet("getMonthlyRevenueBySoldedCourses/{revenueSharePercentage}/{year}")]
        public async Task<IActionResult> GetMonthlyRevenueBySoldedCourses(int revenueSharePercentage, int year)
        {

            return Ok(await enrollmentService.GetMonthlyRevenueBySoldedCourses(revenueSharePercentage, year));
        }

    }
}
