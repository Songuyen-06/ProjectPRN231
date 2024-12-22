using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


<<<<<<< HEAD:EduCore/EduCore.Domain/DTOs/SubCategoryDetailDTO.cs
namespace EduCore.Domain.DTOs
=======
namespace CourseDomain.DTOs
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/DTOs/SubCategoryDetailDTO.cs
{
    public class SubCategoryDetailDTO:SubCategoryDTO
    {
        [JsonPropertyOrder(2)]
        public int  CategoryId { get; set; }

        [JsonPropertyOrder(3)]
<<<<<<< HEAD:EduCore/EduCore.Domain/DTOs/SubCategoryDetailDTO.cs


=======
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/DTOs/SubCategoryDetailDTO.cs
        public string CategoryName {  get; set; }
    }
}
