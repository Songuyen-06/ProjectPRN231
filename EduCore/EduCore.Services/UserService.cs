using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> GetListUser()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _unitOfWork.UserRepository.Get(u => u.UserId == userId);
            return _mapper.Map<UserDTO>(user);
        }


        public async Task UpdateUser(UserDTO userDto)
        {
            var user = await _unitOfWork.UserRepository.Get(u => u.UserId == userDto.UserId);
            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;
            user.Password = userDto.Password;
            user.Bio = userDto.Bio;
            user.UrlImage = userDto.UrlImage;
            user.RoleId = userDto.RoleId;
            user.IsActive = userDto.IsActive;

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync(); 
        }
        public async Task AddUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
        }
        public async Task DeleteUser(int userId)
        {

            try
            {
                var user = await _unitOfWork.UserRepository.Get(u => u.UserId.Equals(userId));
                _unitOfWork.UserRepository.Remove(user);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateStatusUser(UserStatusDTO userStatus)
        {
            var user = await _unitOfWork.UserRepository.Get(u => u.UserId.Equals(userStatus.UserId));
            if (user == null)
            {
                throw new Exception($"User with ID {userStatus.UserId} not found in the database.");
            }
            user.IsActive = userStatus.IsActive;
             _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();

        }
    }
}
