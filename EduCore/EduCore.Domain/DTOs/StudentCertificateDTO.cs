namespace EduCore.Domain.DTOs
{
    public  class StudentCertificateDTO
    {
        public  int StudentId {  get; set; }

        public string StudentName { get; set; }

        public List<CertificateDetailDTO> CertificateDetails { get; set; }
    }
}
