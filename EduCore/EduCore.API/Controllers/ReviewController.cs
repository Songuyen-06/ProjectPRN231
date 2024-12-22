using EduCore.Domain;
using EduCore.Domain.Models;
using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("getListReview")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reviewService.GetListReview());
        }

        [HttpGet("getListReviewByCourseIdAndFilterByRating/{courseId}/{rating}")]
        public async Task<IActionResult> GetListReviewByCourseIdAndFilterByRating(int courseId, int rating)
        {
            return Ok(await _reviewService.GetListReviewByCourseIdAndFilterByRating(courseId, rating));
        }

        [HttpGet("getListReviewByCourseIdAndFilterByDate/{courseId}/{isNewest}")]
        public async Task<IActionResult> GetListReviewByCourseIdAndFilterByDate(int courseId, bool isNewest)
        {
            return Ok(await _reviewService.GetListReviewByCourseIdAndFilterByDate(courseId, isNewest));
        }

        [HttpGet("getListReviewByCourseIdAndFilterByAll/{courseId}/{isNewest}/{rating}")]
        public async Task<IActionResult> GetListReviewByCourseIdAndFilterByAll(int courseId, bool isNewest, int rating)
        {
            return Ok(await _reviewService.GetListReviewByCourseIdAndFilterByAll(courseId, isNewest, rating));
        }


        [HttpGet("getListReviewByCourseId/{courseId}")]
        public async Task<IActionResult> getListReviewByCourseId(int courseId)
        {
            return Ok(await _reviewService.GetListReviewByCourseId(courseId));
        }
    }
}
