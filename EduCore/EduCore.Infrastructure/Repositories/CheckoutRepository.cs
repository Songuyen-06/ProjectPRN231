using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.Models;
using EduCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Infrastructure
{
    internal class CheckoutRepository : GenericRepository<StudentCheckout>, ICheckoutRepository
    {
        public CheckoutRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        

        public IQueryable<StudentCheckout> GetListCheckoutByInclude()
        {
            return _entitySet.Include(c => c.Course).Include(c => c.Student);
        }

    }
}
