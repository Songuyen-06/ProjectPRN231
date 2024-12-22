using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface ICheckoutService
    {
        public Task<CheckoutDTO> GetCheckoutById(int cateId);
        public  Task<int> AddCheckout(CheckoutDTO newCheckout);
    }
}
