using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public class StudentService : IStudentService

    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper _mapper { get; set; }
        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task <List<StudentDTO>> GetListStudent()
        {
            return _mapper.Map<List<StudentDTO>>(await _unitOfWork.StudentRepository.GetListStudent().ToListAsync());
        }
    }
}
