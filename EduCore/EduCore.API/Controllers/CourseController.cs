using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduCore.Domain;
using EduCore.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.OData.Query;
using EduCore.Domain.DTOs;
using System.Runtime.InteropServices;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getListCourseByStudentId/{stdId}/{isInCart}")]
        public async Task<IActionResult> GetListCourseByStudentId(int stdId, bool isInCart)
        {
            var courses = await _courseService.GetListCourseByStudentId(stdId, isInCart);
            return Ok(courses);
        }

        [HttpGet("getListCourseByInstructorId/{instructorId}")]
        public async Task<IActionResult> GetListCourseByInstructorId(int instructorId)
        {
            var courses = await _courseService.GetListCourseByInstructorId(instructorId);
            return Ok(courses);
        }

        // GET: api/Course
        [HttpGet("getCourseDetailByCourseId/{courseId}")]
        public async Task<IActionResult> GetCourseDetailByCourseId(int courseId)
        {
            var courses = await _courseService.GetCourseDetailByCourseId(courseId);


            return Ok(courses);

        } 
        
        [HttpGet("getStatusCourseDetailByStudentIdAndCourseId/{courseId}/{studentId}")]
        public async Task<IActionResult> GetStatusCourseDetailByStudentIdAndCourseId(int courseId,int studentId)
        {
            var courses = await _courseService.GetStatusCourseDetailByStudentIdAndCourseId(courseId,studentId);


            return Ok(courses);

        }

        [HttpGet("getListCourse")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var courses = await _courseService.GetListCourse();


            return Ok(courses);
        }




        [HttpPost("addStudentCourse")]
        public async Task<IActionResult> AddStudentCourse([FromBody] StudentCourseDTO scDTO)
        {
            await _courseService.AddStudentCourse(scDTO);

            return Ok();
        }

        [HttpPost("addCourse")]
        public async Task<IActionResult> AddCourse([FromBody] CourseDTO cDTO)
        {
            await _courseService.AddCourse(cDTO);

            return Ok();
        }


        [HttpPost("updateCourse/{courseId}")]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseDTO cDTO, int courseId)
        {
            await _courseService.UpdateCourse(cDTO, courseId);

            return Ok();
        }

        [HttpGet("getTopSellingCourses")]
        [EnableQuery]
        public async Task<IActionResult> GetTopSellingCourses()
        {
            return Ok(await _courseService.GetTopSellingCourses());

        }
        [HttpGet("getTopSellingCoursesByCateId/{cateId}")]
        [EnableQuery]
        public async Task<IActionResult> GetTopSellingCoursesByCateId(int cateId)
        {
            return Ok(await _courseService.GetTopSellingCoursesByCateId(cateId));

        }

        [HttpGet("getTopSellingCoursesBySubCateId/{subCateId}")]
        [EnableQuery]
        public async Task<IActionResult> GetTopSellingCoursesBySubCateId(int subCateId)
        {
            return Ok(await _courseService.GetTopSellingCoursesBySubCateId(subCateId));

        }
        [HttpGet("getEnrolledCourseListByStudentId/{studentId}")]
        public async Task<IActionResult> GetEnrolledCourseListByStudentId(int studentId)
        {
            return Ok(await _courseService.GetEnrolledCourseListByStudentId(studentId));

        }

    }
}
