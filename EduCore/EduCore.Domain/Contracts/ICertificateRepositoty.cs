using EduCore.Domain;
using EduCore.Domain.Models;
﻿using System;

namespace EduCore.Domain.Contracts
{
    public  interface ICertificateRepositoty:IGenericRepository<Certificate>
    {
        public Task<IEnumerable<Certificate>> GetListCertificate();
    }
}
