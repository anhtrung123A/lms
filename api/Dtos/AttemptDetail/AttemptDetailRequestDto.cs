using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.AttemptDetail
{
    public class AttemptDetailRequestDto
    {
        public string? QuestionId { get; set; }
        public string? AnswerId { get; set; }
    }
}