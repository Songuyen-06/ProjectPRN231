using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class RevenueDTO
    {
        [Key]
        public int RevenueId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal? Amount { get; set; }
        public RevenueDTO() { }

    }
}
