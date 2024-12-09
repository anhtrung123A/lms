using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;
using api.Models;

namespace api.Interfaces
{
    public interface IAnswerMappers
    {
        Answer ToAnswerFromAnswerCreateRequestDto(AnswerCreateRequestDto request);
        AnswerResponseDto ToAnswerResponseDtoFromAnswer(Answer answer);
        AnswerResponseWithStateDto ToAnswerResponseWithStateDtoFromAnswer(Answer answer);
    }
}