using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Question;
using api.Models;

namespace api.Interfaces
{
    public interface IQuestionMappers
    {
        Question ToQuestionFromQuestionCreateRequestDto(QuestionCreateRequestDto request);
        List<QuestionResponseDto> ToQuestionResponseDtosFromQuestions(List<Question> questions);
        List<QuestionResponseWithStateDto> ToQuestionResponseDtosWithAllAnswerFromQuestions(List<Question> questions);
        List<QuestionResponseDto> ToQuestionResponseDtosWithCorrectAnswerFromQuestions(List<Question> questions);
    }
}