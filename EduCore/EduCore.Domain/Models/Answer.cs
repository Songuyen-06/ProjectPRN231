using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; } = null!;
        public bool IsCorrect { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question? Question { get; set; }
    }
}
