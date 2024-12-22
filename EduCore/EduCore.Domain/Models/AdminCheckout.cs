using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class AdminCheckout
    {
        public AdminCheckout()
        {
            Courses = new HashSet<Course>();
        }

        public int CheckoutId { get; set; }
        public int AdminId { get; set; }
        public int InstructorId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PlatformFee { get; set; }
        public decimal? InstructorRevenue { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentMethod { get; set; }

        public virtual User Admin { get; set; } = null!;
        public virtual User Instructor { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
