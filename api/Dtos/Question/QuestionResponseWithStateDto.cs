using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;

namespace api.Dtos.Question
{
    public class QuestionResponseWithStateDto
    {
        public string Id {get; set;} = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<AnswerResponseWithStateDto>? Answers { get; set; }
    }
}