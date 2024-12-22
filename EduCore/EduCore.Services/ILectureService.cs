using EduCore.Domain.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public interface ILectureService
    {
        public  Task<LectureDetailDTO> GetLectureDetailById(int id);

    }
}
