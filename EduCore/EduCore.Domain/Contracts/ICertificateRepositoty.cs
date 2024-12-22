<<<<<<< HEAD:EduCore/EduCore.Domain/Contracts/ICertificateRepositoty.cs
﻿using EduCore.Domain.Models;
using System;
=======
﻿using System;
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/Contracts/ICertificateRepositoty.cs
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:EduCore/EduCore.Domain/Contracts/ICertificateRepositoty.cs
namespace EduCore.Domain.Contracts
=======
namespace CourseDomain.Contracts
>>>>>>> 80594de4f4698a608476586b56b3613c30cc2064:CourseWebProject/CourseDomain/Contracts/ICertificateRepositoty.cs
{
    public  interface ICertificateRepositoty:IGenericRepository<Certificate>
    {
        public Task<IEnumerable<Certificate>> GetListCertificate();
    }
}
