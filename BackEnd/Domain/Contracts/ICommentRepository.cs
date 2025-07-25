﻿using EduCore.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.BackEnd.Domain.Contracts
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<List<Comment>> GetListRepliedCommentByLectureId(int lectureId);
        Task AddComment(Comment comment);
        Task<Comment> GetCommentById(int commentId);
    }
}
