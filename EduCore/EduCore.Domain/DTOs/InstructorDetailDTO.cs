using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EduCore.Domain.DTOs
{
    public  class InstructorDetailDTO: InstructorDTO
    {
        [JsonPropertyOrder(14)]
        public  List<CourseDTO> Courses {  get; set; }

        [JsonPropertyOrder(15)]
        public List<ReviewDTO> Reviews { get; set; }
    }
}
