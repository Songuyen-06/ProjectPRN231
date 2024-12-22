using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Comments = new HashSet<Comment>();
            CompletionStatuses = new HashSet<CompletionStatus>();
            Exercises = new HashSet<Exercise>();
        }

        public int LectureId { get; set; }
        public int? SectionId { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public string? VideoUrl { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Position { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CompletionStatus> CompletionStatuses { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
