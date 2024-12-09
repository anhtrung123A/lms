using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Attempt;
using api.Dtos.Question;
using api.Dtos.Result;
using api.Models;

namespace api.Interfaces
{
    public interface IAttemptMappers
    {
        Attempt ToAttemptFromAttemptRequestDto(AttemptRequestDto request);
        ResultResponseDto ToResultResponseDtoFromAttemptAndAttemptDetail(Attempt attempt, List<AttemptDetail> attemptDetails, List<QuestionResponseWithStateDto> questions);
        List<AttemptResponseDto> ToAttemptResponseDtosFromAttempts(List<Attempt> attempts);
    }
}