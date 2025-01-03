using EduCore.Domain.DTOs;

using System.Text;
using System.Text.Json;
namespace EduCore.Web.Services;


public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAPIRoute = "https://localhost:7004/api";

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public Task<bool> CreateUser(UserDTO user)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<UserDTO> GetUserByEmailAndPassword(UserDTO u)
    {
        try
        {
            // Make the asynchronous GET request
            var response = await _httpClient.GetAsync($"{_baseAPIRoute}/User/getListUser?$filter=email eq '{u.Email}' and password eq '{u.Password}'");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
                return user.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<UserDTO>> GetListUser()
    {
        var response = await _httpClient.GetAsync($"{_baseAPIRoute}/User/getlistUser");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<UserDTO>>();
        }
        return null;
    }
    public async Task<UserDTO> GetUserById(int? id)
    {
        var response = await _httpClient.GetAsync($"{_baseAPIRoute}/User/getUserById/{id}");


        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }
        return null;
    }
    public async Task<int> UpdateUser(UserDTO user)
    {
        var jsonContent = JsonSerializer.Serialize(user);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseAPIRoute}/User/updateUser?userId={user.UserId}", httpContent);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to update user. Status Code: {response.StatusCode}, Error: {errorContent}");
        }
        return response.IsSuccessStatusCode ? 1 : -1;
    }

    public async Task<int> UpdateStatusUser(UserStatusDTO userStatus)
    {
        var jsonContent = JsonSerializer.Serialize(userStatus);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseAPIRoute}/User/updateStatusUser", httpContent);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to update status user. Status Code: {response.StatusCode}, Error: {errorContent}");
        }
        return response.IsSuccessStatusCode ? 1 : -1;
    }



    public async Task DeleteUser(int userId)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAPIRoute}/User/deleteUser?userId={userId}");
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to delete user. Status Code: {response.StatusCode}, Error: {errorContent}");
        }
    }
    public async Task<bool> CreateUser(UserDTO user)
    {
        var jsonContent = JsonSerializer.Serialize(user);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseAPIRoute}/User/addUser", httpContent);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to create user. Status Code: {response.StatusCode}, Error: {errorContent}");
        }
        return response.IsSuccessStatusCode;
    }
    public async Task<int> GetNumberUser()
    {
        return await _httpClient.GetAsync("https://localhost:7004/odata/User/$count").Result.Content.ReadFromJsonAsync<int>();
    }



}

