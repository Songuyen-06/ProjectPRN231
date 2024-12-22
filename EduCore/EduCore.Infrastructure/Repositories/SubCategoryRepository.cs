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
    internal class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<SubCategory>> GetAllSubCategory()
        {
            return _entitySet.ToListAsync();
        }

        public async Task<bool> IsExistingSubCategory(int? cateId)
        {
            return await _entitySet.AnyAsync(c => c.CategoryId == cateId);

        }
    }
}
