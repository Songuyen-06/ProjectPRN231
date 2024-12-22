using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public  class CommentDTO
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }

        public DateTime CommentOn { get; set; }
        public int NumberOfLikes { get; set; }

        public List<CommentDTO> Replies { get; set; }


    }
}
