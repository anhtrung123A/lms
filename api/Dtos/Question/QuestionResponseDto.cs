using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;

namespace api.Dtos.Question
{
    public class QuestionResponseDto
    {
        public string Id {get; set;} = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<AnswerResponseDto>? Answers { get; set; }
    }
}