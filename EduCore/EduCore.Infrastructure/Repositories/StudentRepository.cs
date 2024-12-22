using EduCore.Domain.Contracts;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Infrastructure.Repositories
{
    internal class StudentRepository : GenericRepository<User>, IStudentRepository
    {
        public StudentRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<User> GetListStudent()
        {
            return _entitySet.Include(st => st.Enrollments).ThenInclude(en=>en.Course).Where(st=>st.RoleId==1);
        }
    }
}
