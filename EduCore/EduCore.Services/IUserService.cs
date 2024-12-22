using EduCore.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetListUser();
        Task UpdateUser(UserDTO userDTO);
        Task AddUser(UserDTO userDTO);
        Task DeleteUser(int userId);
        Task UpdateStatusUser(UserStatusDTO userStatus);
        public Task<UserDTO> GetUserById(int userId);
    }
}
