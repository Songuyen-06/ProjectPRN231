using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCore.Domain.DTOs
{
    public class OpenAiResponseDTO
    {
        public int Score { get; set; }
        public string Comments { get; set; } = string.Empty;
    }
}
