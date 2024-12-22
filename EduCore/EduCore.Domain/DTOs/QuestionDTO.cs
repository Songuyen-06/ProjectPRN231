using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string Text { get; set; } = null!;
        public List<AnswerDTO> Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
