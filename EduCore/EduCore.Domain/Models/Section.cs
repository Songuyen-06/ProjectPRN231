using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Section
    {
        public Section()
        {
            CompletionStatuses = new HashSet<CompletionStatus>();
            Lectures = new HashSet<Lecture>();
        }

        public int SectionId { get; set; }
        public int? CourseId { get; set; }
        public string Title { get; set; } = null!;
        public TimeSpan? Duration { get; set; }
        public int? Position { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<CompletionStatus> CompletionStatuses { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
