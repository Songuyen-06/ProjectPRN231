<<<<<<< HEAD:EduCore/EduCore.Infrastructure/Repositories/CertificateRepository.cs
﻿using EduCore.Domain;
using EduCore.Domain.Contracts;
using EduCore.Domain.Models;
=======
﻿using CourseDomain;
using CourseDomain.Contracts;
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseInfrastructures/Repositories/CertificateRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:EduCore/EduCore.Infrastructure/Repositories/CertificateRepository.cs
namespace EduCore.Infrastructure.Repositories
=======
namespace CourseInfrastructure.Repositories
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseInfrastructures/Repositories/CertificateRepository.cs
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
