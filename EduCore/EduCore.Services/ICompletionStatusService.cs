using EduCore.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Services
{
    public interface ICompletionStatusService
    {
        Task<List<CompletionStatusDTO>> GetAllCompletionStatus();
    }
}
