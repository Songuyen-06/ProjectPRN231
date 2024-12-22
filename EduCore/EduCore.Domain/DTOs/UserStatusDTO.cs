using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class UserStatusDTO
    {
        [Key]
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
