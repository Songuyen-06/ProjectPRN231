using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public string Text { get; set; } = null!;
        public bool IsCorrect { get; set; }
    }
}
