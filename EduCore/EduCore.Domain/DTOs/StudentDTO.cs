using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public  class StudentDTO:UserDTO
    {
        [JsonPropertyOrder(9)]
        public int NumberEnrolledCourses { get; set; }
        [JsonPropertyOrder(10)]
        public decimal TuitionFee { get; set; }
    }
}
