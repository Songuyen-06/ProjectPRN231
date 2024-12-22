using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:EduCore/EduCore.Domain/DTOs/UserDTO.cs
namespace EduCore.Domain.DTOs
=======
namespace CourseDomain.DTOs
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/DTOs/UserDTO.cs
{
    public class UserDTO
    {
        [Key]
        [JsonPropertyOrder(1)]
        public int UserId { get; set; }

        [JsonPropertyOrder(2)]
        public string? FullName { get; set; }

        [JsonPropertyOrder(3)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [JsonPropertyOrder(4)]
        public string? Phone { get; set; }

        [JsonPropertyOrder(5)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [JsonPropertyOrder(6)]
        public string? Bio { get; set; }

        [JsonPropertyOrder(7)]
        public string? UrlImage { get; set; }

        [JsonPropertyOrder(8)]
        public int? RoleId { get; set; }


        [JsonPropertyOrder(9)]
        public bool IsActive { get; set; } = true;


    }
}
