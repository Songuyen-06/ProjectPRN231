﻿using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.Contracts
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<List<Comment>> GetListRepliedCommentByLectureId(int lectureId);
        Task AddComment(Comment comment);
        Task<Comment> GetCommentById(int commentId);
    }
}
