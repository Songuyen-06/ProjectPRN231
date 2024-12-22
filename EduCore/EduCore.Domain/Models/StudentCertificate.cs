using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class StudentCertificate
    {
        public int UserId { get; set; }
        public int CertificateId { get; set; }
        public DateTime CompletionDate { get; set; }
        public TimeSpan CompletionTime { get; set; }

        public virtual Certificate Certificate { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
