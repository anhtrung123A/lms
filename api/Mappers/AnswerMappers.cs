using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;
using api.Interfaces;
using api.Models;

namespace api.Mappers
{
    public class AnswerMappers : IAnswerMappers
    {
        public Answer ToAnswerFromAnswerCreateRequestDto(AnswerCreateRequestDto request){
            return new Answer {
                Content = request.Content,
                IsCorrect = request.IsCorrect
            };
        }
        public AnswerResponseDto ToAnswerResponseDtoFromAnswer(Answer answer){
            return new AnswerResponseDto {
                AnswerId = answer.Id.ToString(),
                Content = answer.Content
            };
        }
        public AnswerResponseWithStateDto ToAnswerResponseWithStateDtoFromAnswer(Answer answer){
            return new AnswerResponseWithStateDto {
                AnswerId = answer.Id.ToString(),
                Content = answer.Content,
                IsCorrect = answer.IsCorrect
            };
        }
    }
}