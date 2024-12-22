using AutoMapper;
<<<<<<< HEAD:EduCore/EduCore.Services/CertificateService.cs
using EduCore.Domain;
using EduCore.Domain.DTOs;
=======
using CourseDomain;
using CourseDomain.DTOs;
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseService/CertificateService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:EduCore/EduCore.Services/CertificateService.cs
namespace EduCore.Services
=======
namespace CourseServices
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseService/CertificateService.cs
{
    public class CertificateService : ICertificateService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        private readonly IMapper _mapper;


        public CertificateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CertificateDTO>> GetListCertificate()
        {
            return _mapper.Map<IEnumerable<CertificateDTO>>(await _unitOfWork.CertificateRepositoty.GetAll());
        }
    }
}
