
using EduCore.Domain.DTOs;
using System.Text;
using System.Text.Json;

namespace EduCore.Web.Services
{
    public class CheckoutService : ICheckoutService
    {

        private readonly HttpClient _httpClient;
        private readonly string APIRoute = "https://localhost:7004/api";

        public CheckoutService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }

        public async Task<int> AddCheckout(CheckoutDTO newCheckout)
        {
            var response = await _httpClient.PostAsync($"{APIRoute}/Checkout/addCheckout", new StringContent(JsonSerializer.Serialize(newCheckout), Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode ? 1 : -1;
        }

        public async Task<CheckoutDTO> GetCheckoutById(int id)
        {
            var response = await _httpClient.GetAsync($"{APIRoute}/Checkout/getListCheckout?$filter=checkoutId eq {id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CheckoutDTO>();

        }
    }
}
