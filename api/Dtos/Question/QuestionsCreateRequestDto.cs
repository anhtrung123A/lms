using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Question
{
    public class QuestionsCreateRequestDto
    {
        public string TestId { get; set; } = string.Empty;
        public List<QuestionCreateRequestDto>? Questions { get; set; }
    }
}