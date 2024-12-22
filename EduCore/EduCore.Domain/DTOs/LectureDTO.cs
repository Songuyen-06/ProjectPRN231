using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduCore.Domain.DTOs
{
    public  class LectureDTO
    {
        [Key]
        [JsonPropertyOrder(0)]
        public int LectureId { get; set; }

        [JsonPropertyOrder(1)]

        public string Title { get; set; } = null!;



        [JsonPropertyOrder(2)]

        public string? Duration { get; set; }

        [JsonPropertyOrder(3)]
        public bool IsCompleted { get; set; }

    }
}
