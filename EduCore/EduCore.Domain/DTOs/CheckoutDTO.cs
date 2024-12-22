using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public  class CheckoutDTO
    {
        [Key]
        public int? CheckoutId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string TransactionId { get; set; } = null!;
        public string PaymentStatus { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }

        public string? StudentName { get; set; }
        public string? CourseName { get; set; }
        public string? Token { get; set; }
        public string? VnPayResponseCode { get; set; }

        public DateTime? PaymentDate { get; set; }= DateTime.Now;
    }
}
