using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using EduCore.Domain.DTOs;


namespace EduCore.Domain.DTOs
{
    public class SubCategoryDetailDTO:SubCategoryDTO
    {
        [JsonPropertyOrder(2)]
        public int  CategoryId { get; set; }

        [JsonPropertyOrder(3)]


        public string CategoryName {  get; set; }
    }
}
