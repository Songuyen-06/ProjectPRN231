using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class EnrollmentDTO
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
