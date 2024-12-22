using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string Type { get; set; } = null!;
        public string? Description { get; set; }
        public string? ExerciseUrl { get; set; }
        public List<QuestionDTO> Questions { get; set; }

    }
}
