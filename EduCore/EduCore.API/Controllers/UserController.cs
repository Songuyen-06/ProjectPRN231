using EduCore.Domain.DTOs;
using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getListUser")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var listUser = await _userService.GetListUser();
            return Ok(listUser);
        } 
        
        [HttpGet("getUserById/{uID}")]
        [EnableQuery]
        public async Task<IActionResult> GetUserById(int uID)
        {
            var user = await _userService.GetUserById(uID);
            return Ok(user);
        }
        
        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _userService.UpdateUser(userDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }  
        
        [HttpPut("updateStatusUser")]
        public async Task<IActionResult> UpdateStatusUserById([FromBody] UserStatusDTO userStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _userService.UpdateStatusUser(userStatus);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDto)
        {
            await _userService.AddUser(userDto);
            return Ok();
        }
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await _userService.DeleteUser(userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        
    }
}
