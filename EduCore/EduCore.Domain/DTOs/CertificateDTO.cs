using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EduCore.Domain.DTOs
{
    public  class CertificateDTO
    {
        [Key]
        [JsonPropertyOrder(0)]
        public int CertificateId { get; set; }

        [JsonPropertyOrder(1)]
        public string Title { get; set; }

        [JsonPropertyOrder(2)]
        public string Description { get; set; } = null!;




        [JsonPropertyOrder(3)]
        public string IssuedBy { get; set; } = null!;

        [JsonPropertyOrder(4)]
        public string CertificateUrl { get; set; } = null!;
    }
}
