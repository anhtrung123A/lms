using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Answer
{
    public class AnswerCreateRequestDto
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}