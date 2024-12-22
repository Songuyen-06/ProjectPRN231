using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public interface ICommentService
    {
        public Task AddComment(AddedCommentDTO comment);
        public Task<CommentDTO> GetCommentById(int id);
    }
}
