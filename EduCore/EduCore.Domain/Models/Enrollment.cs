using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}
