using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public  class DocumentDTO
    {
        public int DocumentId { get; set; }
        public string Title { get; set; } = null!;
        public string? Url { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
