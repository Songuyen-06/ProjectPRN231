using EduCore.Domain.Contracts;
using EduCore.Domain.DTOs;
using EduCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Infrastructure.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddComment(Comment comment)
        {
            this.Add(comment);
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            return await GetCommentListByInclude().FirstOrDefaultAsync(c=>c.CommentId== commentId);
        }

        public IQueryable<Comment> GetCommentListByInclude()
        {
            return _entitySet.Include(co => co.User).Include(co => co.Lecture)
                .Include(co => co.InverseReply);
        }

        public async Task<List<Comment>> GetListRepliedCommentByLectureId(int lectureId)
        {

            var replidComments = GetCommentListByInclude() .Where(co => co.LectureId == lectureId  && co.ReplyId == null) .ToList();


            return replidComments;
        }


    }
}
