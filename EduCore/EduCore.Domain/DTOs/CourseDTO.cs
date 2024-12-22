using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EduCore.Domain.DTOs
{
    public class CourseDTO
    {
        [Key]
        [JsonPropertyOrder(0)]
        public int CourseId { get; set; }

        [JsonPropertyOrder(1)]
        public string Title { get; set; }

        [JsonPropertyOrder(2)]
        public int? CategoryId { get; set; }

        [JsonPropertyOrder(3)]
        public int? SubCategoryId { get; set; }

        [JsonPropertyOrder(4)]
        public string? SubCategoryName { get; set; }

        [JsonPropertyOrder(5)]
        public string? Level { get; set; }

        [JsonPropertyOrder(6)]
        public int? SectionNumber { get; set; }

        [JsonPropertyOrder(7)]
        public int? LectureNumber { get; set; }

        [JsonPropertyOrder(8)]
        public string? Duration { get; set; }

        [JsonPropertyOrder(9)]
        public int? InstructorId { get; set; }

        [JsonPropertyOrder(10)]
        public string? InstructorName { get; set; }

        [JsonPropertyOrder(11)]
        public decimal? Rating { get; set; }

        [JsonPropertyOrder(12)]
        public int? RatingNumber { get; set; }

        [JsonPropertyOrder(13)]
        public decimal? PriceAfterSale { get; set; }

        [JsonPropertyOrder(14)]
        public decimal? Price { get; set; }

        [JsonPropertyOrder(15)]
        public int? Sale { get; set; }

        [JsonPropertyOrder(16)]
        public int? StudentNumber { get; set; }

        [JsonPropertyOrder(17)]
        public string? Url { get; set; }


        [JsonPropertyOrder(18)]
        public DateTime? CreateTime { get; set; }   
        
        [JsonPropertyOrder(19)]
        public bool IsCompleted { get; set; }

        




    }
}
