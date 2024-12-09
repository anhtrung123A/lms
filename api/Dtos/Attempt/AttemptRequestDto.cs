using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.AttemptDetail;

namespace api.Dtos.Attempt
{
    public class AttemptRequestDto
    {
        public string? TestId { get; set; }
        public List<AttemptDetailRequestDto>? AttemptDetails { get; set; }
    }
}