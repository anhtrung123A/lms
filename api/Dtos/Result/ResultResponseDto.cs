using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Result
{
    public class ResultResponseDto
    {
        public DateTime DoneAt { get; set; }
        public float Mark { get; set; }
        public List<QuestionAndResultDto>? Result { get; set; }
    }
}