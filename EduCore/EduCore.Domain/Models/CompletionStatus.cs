using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class CompletionStatus
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public int LectureId { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Lecture Lecture { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
