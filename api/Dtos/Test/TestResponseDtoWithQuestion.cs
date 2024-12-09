using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Question;

namespace api.Dtos.Test
{
    public class TestResponseDtoWithQuestion
    {
        public Guid Id {get; set;}
        public string? Name {get; set;}
        public int TimeLimit {get; set;}
        public DateTime CreatedOn {get; set;}
        public List<QuestionResponseDto>? Questions {get; set;}
    }
}