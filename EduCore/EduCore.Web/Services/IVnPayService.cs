using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, CheckoutDTO model);
        CheckoutDTO PaymentExecute(IQueryCollection collections);
    }
}