﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDomain.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsExistingUser(int? userId);
        Task<User> GetById(int id);
        Task UpdateUser(User user);
        Task Add(User user);
        Task<int> CountAsync();
    }
}