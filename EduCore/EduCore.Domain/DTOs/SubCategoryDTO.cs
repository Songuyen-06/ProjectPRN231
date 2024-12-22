using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
<<<<<<< HEAD:EduCore/EduCore.Domain/DTOs/SubCategoryDTO.cs
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/DTOs/SubCategoryDTO.cs

namespace EduCore.Domain.DTOs
{
    public  class SubCategoryDTO
    {
        [Key]
        [JsonPropertyOrder(0)]
<<<<<<< HEAD:EduCore/EduCore.Domain/DTOs/SubCategoryDTO.cs
        public int? SubCategoryId { get; set; }
=======
        public int SubCategoryId { get; set; }
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/DTOs/SubCategoryDTO.cs

        [JsonPropertyOrder(1)]
        public string SubCategoryName { get; set; }


    }
}
