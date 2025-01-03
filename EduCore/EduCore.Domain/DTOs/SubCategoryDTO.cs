using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EduCore.Domain.DTOs
{
    public  class SubCategoryDTO
    {
        [Key]
        [JsonPropertyOrder(0)]
        public int? SubCategoryId { get; set; }

        [JsonPropertyOrder(1)]
        public string SubCategoryName { get; set; }


    }
}
