using EduCore.Domain.DTOs;
using EduCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Course.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        public ICommentService commentService;
        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] AddedCommentDTO commentDTO)
        {
            await commentService.AddComment(commentDTO);
            return Ok();
        }
        [HttpGet("getCommentById/{commentId}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
           
            return Ok(await commentService.GetCommentById(commentId));
        }

    }


}
