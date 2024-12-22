using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class SectionDTO
    {
        [Key]
        public int SectionId { get; set; }
        public string Title { get; set; }

        public int LectureNumber { get; set; }

        public String  Duration { get; set; }

        public bool IsCompleted { get; set; }

        public List<LectureDTO> Lectures { get; set; }
    }
}
