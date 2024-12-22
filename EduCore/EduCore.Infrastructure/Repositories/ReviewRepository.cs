using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.Models;
using EduCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Infrastructure
{
    internal class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<Review> GetListReviewByInclude()
        {
            return _entitySet.Include(r => r.Course).Include(r => r.Student);
        }
        public IQueryable<Review> GetListReviewByCourseId(int courseId)
        {
            return GetListReviewByInclude().Where(r => r.CourseId == courseId).OrderBy(r => r.ReviewDate);
        }
        public IQueryable<Review> GetListReviewByCourseIdAndFilterByRating(int courseId, decimal rating)
        {
            return GetListReviewByCourseId(courseId).Where(r => r.Rating == rating);
        }
        public IQueryable<Review> GetListReviewByCourseIdAndFilterByDate(int courseId, bool isNewest)
        {
            var query = GetListReviewByCourseId(courseId);
            return query = isNewest ? query.OrderByDescending(r => r.ReviewDate) : query.OrderBy(r => r.ReviewDate);
        }
        public IQueryable<Review> GetListReviewByCourseIdAndFilterByAll(int courseId, bool isNewest, int rating)
        {
            var query = GetListReviewByCourseId(courseId).Where(r => r.Rating == rating);
            return query = isNewest ? query.OrderByDescending(r => r.ReviewDate) : query.OrderBy(r => r.ReviewDate);
        }
    }
}
