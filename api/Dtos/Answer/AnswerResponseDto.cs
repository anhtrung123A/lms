using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Answer
{
    public class AnswerResponseDto
    {
        public string? AnswerId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}