using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string Text { get; set; } = null!;
        public int? ExerciseId { get; set; }

        public virtual Exercise? Exercise { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
