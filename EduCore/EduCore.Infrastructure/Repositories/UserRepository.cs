using EduCore.Domain;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }
       
        
        
        
        
        //public async Task DeleteUserById(int userId)
        //{
        //    var userCourses = _entitySet.FirstOrDefault(u => u.UserId == userId).Courses;
        //    if (userCourses != null)
        //    {
        //        foreach (var c in userCourses)
        //        {
        //            c.InstructorId = null;
        //        }
        //        _dbContext.UpdateRange(userCourses);
        //    }


        //        _dbContext.Remove(_entitySet.Include(u => u.StudentCertificates)
        //            .Include(u => u.Reviews)
        //            .Include(u => u.StudentCourses)
        //            .Include(u => u.SystemSettings)
        //            .Include(u => u.Enrollments)
        //            .Include(u => u.Checkouts).FirstOrDefaultAsync(u => u.UserId == userId));



        //}


    }
}
