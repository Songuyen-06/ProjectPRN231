using EduCore.Domain.DTOs;
using System.Collections;

namespace EduCore.Web.Services
{
    public interface ILectureService
    {
        public Task<LectureDetailDTO> GetLectureDetailById(int id);
       
    }
}
