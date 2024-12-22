using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class StudentCheckout
    {
        public int CheckoutId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
        public string? PaymentMethod { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? Student { get; set; }
    }
}
