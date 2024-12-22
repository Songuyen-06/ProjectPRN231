using System;
using System.Collections.Generic;

namespace EduCore.Domain.Models
{
    public partial class Comment
    {
        public Comment()
        {
            InverseReply = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CommentOn { get; set; }
        public int? LectureId { get; set; }
        public int? ReplyId { get; set; }
        public int NumberOfLikes { get; set; }

        public virtual Lecture? Lecture { get; set; }
        public virtual Comment? Reply { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> InverseReply { get; set; }
    }
}
