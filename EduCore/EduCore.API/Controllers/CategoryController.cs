using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using EduCore.Domain.DTOs;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getListCategory")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetListCategory());

        }
        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO cDTO)
        {
            await _categoryService.AddCategory(cDTO);
            return Ok();
        }
        [HttpGet("getCategoryByCateId/{cateId}")]

        public async Task<IActionResult> GetCategoryByCateId(int cateId)
        {
            return Ok(await _categoryService.GetCategoryByCateId(cateId));

        }
        [HttpPut("updateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO cDTO)
        {
            await _categoryService.UpdateCategory(cDTO);
            return Ok();
        }
        [HttpDelete("deleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            return Ok();
        }
    }
}