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
    public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
    {
        public LectureRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<Lecture> GetListLectureByInclude()
        {
            return _entitySet.Include(l => l.Section).Include(l => l.Comments).ThenInclude(c => c.User)
                 .Include(l => l.Exercises).ThenInclude(ex => ex.Questions).ThenInclude(q => q.Answers);
        }

        public async Task<Lecture> GetLectureDetailById(int id)
        {
            return GetListLectureByInclude().FirstOrDefault(l => l.LectureId.Equals(id));
        }
    }


}
