using EduCore.Domain.DTOs;
﻿using EduCore.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public interface ICertificateService
    {
        public Task<IEnumerable<CertificateDTO>> GetListCertificate();

    }
}
