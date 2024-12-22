using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public decimal Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int? ReOpen { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? Student { get; set; }
    }
}
