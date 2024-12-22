using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Contracts
{
    public interface IInstructorRepository : IGenericRepository<User>
    {
        public IQueryable<User> GetListInstructor();
        public Task<User> GetInstructorDetailById(int instructorId);

    }
}
