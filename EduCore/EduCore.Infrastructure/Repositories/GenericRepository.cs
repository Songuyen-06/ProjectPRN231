using AutoMapper;
using EduCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduCore.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CoursesDbContext _dbContext;
        protected readonly DbSet<T> _entitySet;
        public GenericRepository(CoursesDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();

        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);


        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await _entitySet.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entitySet.ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _entitySet.Where(expression).ToListAsync();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);

        }


        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
