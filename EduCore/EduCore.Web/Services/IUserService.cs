<<<<<<< HEAD:EduCore/EduCore.Web/Services/IUserService.cs
﻿using EduCore.Domain.DTOs;
using System.Collections;

namespace EduCore.Web.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(int? id);
        Task<bool> CreateUser(UserDTO user);
        public Task<UserDTO> GetUserByEmailAndPassword(UserDTO u);
        public Task<List<UserDTO>> GetListUser();
        Task<int> UpdateUser(UserDTO user);
        Task<int> UpdateStatusUser(UserStatusDTO user);
=======
﻿using CourseDomain.DTOs;
using System.Collections;

namespace CourseWeb.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(int id);
        Task<bool> CreateUser(UserDTO user);
        public Task<UserDTO> GetUserByEmailAndPassword(UserDTO u);
        public Task<List<UserDTO>> GetListUser();
        Task<bool> UpdateUser(UserDTO user);
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseWeb/Services/IUserService.cs
        Task DeleteUser(int userId);
        public Task<int> GetNumberUser();

    }
}
