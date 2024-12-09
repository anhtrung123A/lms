using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;

namespace api.Dtos.Question
{
    public class QuestionCreateRequestDto
    {
        public string Content { get; set; } = string.Empty;
        public List<AnswerCreateRequestDto>? Answers { get; set; }
    }
}