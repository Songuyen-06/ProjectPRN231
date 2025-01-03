using AutoMapper;
using EduCore.Domain;
using EduCore.Domain.DTOs;

namespace EduCore.Services
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
