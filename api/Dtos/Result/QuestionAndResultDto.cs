using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;
using api.Dtos.Question;

namespace api.Dtos.Result
{
    public class QuestionAndResultDto
    {
        public QuestionResponseWithStateDto? Question { get; set; }
        public string? StudentChoiceId {get; set;}
    }
}