﻿using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Contracts
{
    public interface IStudentRepository : IGenericRepository<User>

    {
        public IQueryable<User> GetListStudent();
    }
}
