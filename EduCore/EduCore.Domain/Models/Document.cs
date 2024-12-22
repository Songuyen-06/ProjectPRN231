using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int? CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string? Url { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Course? Course { get; set; }
    }
}
