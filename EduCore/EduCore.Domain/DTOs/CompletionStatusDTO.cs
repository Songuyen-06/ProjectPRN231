using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class CompletionStatusDTO
    {
        [Key]
        public int UserId { get; set; }
       
        public int CourseId { get; set; }
      
        public int LectureId { get; set; }
       
        public int SectionId { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
