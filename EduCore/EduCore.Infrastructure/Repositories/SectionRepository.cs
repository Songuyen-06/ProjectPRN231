using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.Models;
using EduCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Infrastructure
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<Section> GetListSectionByInclude()
        {
            return _entitySet.Include(s => s.Lectures);
                 
        }
        public async Task<IEnumerable<Section>> GetListSectionByCourseId(int courdId)
        {

            return await GetListSectionByInclude().Where(s => s.CourseId == courdId).ToListAsync();
        }
    }
}
