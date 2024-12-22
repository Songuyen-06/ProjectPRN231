using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class EnrollmentDetailDTO : EnrollmentDTO
    {
        public EnrollmentDetailDTO()
        {
        }

        public string StudentName { get; set; }
        public string StudentImage { get; set; }
        public string CourseTitle { get; set; }
        public string CourseImage { get; set; }
        public decimal CoursePrice {  get; set; }
        public int CourseSale {  get; set; }
        public int  CourseInstructorId { get; set; }

    }
}

