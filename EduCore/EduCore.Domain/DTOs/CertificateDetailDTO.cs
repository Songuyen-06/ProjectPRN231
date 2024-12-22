using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

<<<<<<< HEAD:EduCore/EduCore.Domain/DTOs/CertificateDetailDTO.cs
namespace EduCore.Domain.DTOs
=======
namespace CourseDomain.DTOs
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/DTOs/CertificateDetailDTO.cs
{
    public class CertificateDetailDTO:CertificateDTO
    {
        [JsonPropertyOrder(5)]
        public DateTime CompletionDate { get; set; }

        [JsonPropertyOrder(6)]
        public DateTime CompletionTime { get; set; }
    }
}
