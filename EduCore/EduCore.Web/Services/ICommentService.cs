using EduCore.Domain.DTOs;

namespace EduCore.Web.Services
{
    public interface ICommentService
    {
        public  Task<int> AddComment(AddedCommentDTO comment);
         public Task<CommentDTO>  GetCommentById(int? id);
    }
}
