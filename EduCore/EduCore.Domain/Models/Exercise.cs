using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            Questions = new HashSet<Question>();
        }

        public int ExerciseId { get; set; }
        public int LectureId { get; set; }
        public string Type { get; set; } = null!;
        public string? Description { get; set; }
        public string? ExerciseUrl { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
    }
}
