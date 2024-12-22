using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using EduCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EduCore.Infrastructure
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        public bool IsExitEnrollment(Enrollment enrollment)
        {
            return _entitySet.Any(e => e.StudentId == enrollment.StudentId && e.CourseId == enrollment.CourseId);
        }


        public async Task<List<RevenueDTO>> GetMonthlyRevenueByInstructorId(int revenueSharePercentage, int instructorId, int year)
        {
            var monthlyRevenue = await _entitySet.Include(en => en.Course).
              Where(en => en.Course.InstructorId == instructorId && en.EnrollmentDate.Year == year)
              .GroupBy(er => er.EnrollmentDate.Month)
              .Select(gr => new RevenueDTO
              {
                  RevenueId = gr.Key,
                  Month = gr.Key,
                  Year = year,
                  Amount = gr.Sum(en => (en.Course.Price - (en.Course.Price * en.Course.Sale / 100) ) * revenueSharePercentage / 100),
              }).ToListAsync();


            return monthlyRevenue;
        } 
        
        public async Task<List<RevenueDTO>> GetMonthlyRevenueBySoldCourses(int revenueSharePercentage, int year)
        {
            var monthlyRevenue = await _entitySet.Include(en => en.Course).
              Where(en => en.EnrollmentDate.Year == year)
              .GroupBy(er => er.EnrollmentDate.Month)
              .Select(gr => new RevenueDTO
              {
                  RevenueId = gr.Key,
                  Month = gr.Key,
                  Year = year,
                  Amount = gr.Sum(en => (en.Course.Price - (en.Course.Price * en.Course.Sale / 100)) * revenueSharePercentage / 100),
              }).ToListAsync();


            return monthlyRevenue;
        }
        public IQueryable<Enrollment> GetListEnrollmentByInclude()
        {
            return _entitySet.Include(en => en.Course).Include(en => en.Student);

        }
    }
}
