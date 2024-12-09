using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;

namespace api.Dtos.Attempt
{
    public class AttemptResponseDto
    {
        public StudentInfoDto? Student { get; set; }
        public DateTime DoneAt { get; set; } = DateTime.UtcNow;
        public float Mark { get; set; }
    }
}