using EduCore.Domain.DTOs;
using EduCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EduCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        public ICheckoutService checkoutService { get; set; }
        public CheckoutController(ICheckoutService checkoutService)
        {
            this.checkoutService = checkoutService;
        }
        [HttpGet("getListCheckout")]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(checkoutService.GetCheckoutList());
        }
        [HttpPost("addCheckout")]
        public async Task<IActionResult> AddCheckout([FromBody] CheckoutDTO checkout)
        {
            checkoutService.AddCheckout(checkout);
            return Ok();
        }
    }
}
