using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class LectureDetailDTO:LectureDTO
    {

        [JsonPropertyOrder(4)]
        public int SectionId {  get; set; }


        [JsonPropertyOrder(5)]
        public string SectionTitle {  get; set; }


        [JsonPropertyOrder(6)]
        public string? Content { get; set; }

        [JsonPropertyOrder(7)]
        public string? VideoUrl { get; set; }

        [JsonPropertyOrder(8)]
        public List<CommentDTO>? Comments { get; set; }

        [JsonPropertyOrder(9)]
        public List<ExerciseDTO>? Exercises { get; set; }
    }
}
