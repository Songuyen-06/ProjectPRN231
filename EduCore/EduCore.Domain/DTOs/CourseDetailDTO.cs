using System.Text.Json.Serialization;

namespace EduCore.Domain.DTOs
{
    public class CourseDetailDTO : CourseDTO
    {

        [JsonPropertyOrder(20)]
        public string? Description { get; set; }

        [JsonPropertyOrder(21)]
        public List<SectionDTO>? Sections { get; set; }

        [JsonPropertyOrder(22)]
        public List<ReviewDTO>? Reviews { get; set; }

        [JsonPropertyOrder(23)]
        public List<DocumentDTO>? Documents { get; set; }


    }

}
