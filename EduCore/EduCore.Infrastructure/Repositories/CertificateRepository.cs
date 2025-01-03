using EduCore.Domain.Contracts;
using EduCore.Domain.Models;

namespace EduCore.Infrastructure.Repositories

{
    internal class CertificateRepository : GenericRepository<Certificate>, ICertificateRepositoty
    {
        public CertificateRepository(CoursesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Certificate>> GetListCertificate()
        {
            throw new NotImplementedException();
        }
    }
}
