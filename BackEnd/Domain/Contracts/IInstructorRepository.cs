﻿using EduCore.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.BackEnd.Domain.Contracts
{
    public interface IInstructorRepository : IGenericRepository<User>
    {
        public IQueryable<User> GetListInstructor();
        public Task<User> GetInstructorDetailById(int instructorId);

    }
}
