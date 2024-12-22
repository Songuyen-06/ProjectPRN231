using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        public ISubCategoryService SubCategoryService { get; set; }
        public SubCategoryController(ISubCategoryService subCategoryService) 
        {
            this.SubCategoryService = subCategoryService;
        }
        [HttpGet("/SubCategories")]
        public async Task<IActionResult> Get()
        {
            var subCategories = await SubCategoryService.GetAllSubCategory();
            return Ok(subCategories);
        }
    }
}
