using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Infrastructure.Repositories
{
    public class CompletionStatusRepository : GenericRepository<CompletionStatus>, ICompletionStatusRepository
    {
        public CompletionStatusRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        
    }
}
