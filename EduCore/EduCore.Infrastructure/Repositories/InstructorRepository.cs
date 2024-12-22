using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Infrastructure.Repositories
{
    internal class InstructorRepository : GenericRepository<User>, IInstructorRepository
    {
        public InstructorRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<User> GetListInstructor()
        {
            return _entitySet.Where(u => u.RoleId == 2).
                  Include(u => u.Courses).ThenInclude(c => c.Enrollments)
                    .Include(u => u.Courses).ThenInclude(c => c.SubCategory).ThenInclude(s => s.Category);
        }
        public async Task<User> GetInstructorDetailById(int instructorId)
        {

            return await GetListInstructor().Include(u => u.Courses).ThenInclude(c => c.Sections).ThenInclude(s => s.Lectures)
                .Include(u => u.Courses).ThenInclude(c => c.Reviews).ThenInclude(r => r.Student)
                .Include(u => u.Courses).ThenInclude(c => c.Enrollments)
                .FirstOrDefaultAsync(u => u.UserId == instructorId);
        }

    }
}
