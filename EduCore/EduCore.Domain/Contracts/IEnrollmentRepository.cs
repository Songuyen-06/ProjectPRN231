using EduCore.Domain;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Contracts
{
    public interface IEnrollmentRepository:IGenericRepository<Enrollment>
    {
        public bool IsExitEnrollment(Enrollment enrollment);
        public  Task<List<RevenueDTO>> GetMonthlyRevenueByInstructorId(int revenueSharePercentage, int instructorId, int year);
        public Task<List<RevenueDTO>> GetMonthlyRevenueBySoldCourses(int revenueSharePercentage, int year);

        public IQueryable<Enrollment> GetListEnrollmentByInclude();

    }
}
