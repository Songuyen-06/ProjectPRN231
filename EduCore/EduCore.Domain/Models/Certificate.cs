using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Certificate
    {
        public Certificate()
        {
            StudentCertificates = new HashSet<StudentCertificate>();
        }

        public int CertificateId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IssuedBy { get; set; } = null!;
        public string CertificateUrl { get; set; } = null!;
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<StudentCertificate> StudentCertificates { get; set; }
    }
}
