using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.AttemptDetail;
using api.Interfaces;
using api.Models;

namespace api.Mappers
{
    public class AttemptDetailMappers : IAttemptDetailMappers
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IAnswerRepository _answerRepo;
        public AttemptDetailMappers(IQuestionRepository questionRepo, IAnswerRepository answerRepo)
        {
            _questionRepo = questionRepo;
            _answerRepo = answerRepo;
        }
        public AttemptDetail ToAttemptDetailFromAttemptDetailRequestDto(AttemptDetailRequestDto request){
            var question = _questionRepo.FindByIdAsync(request.QuestionId!).GetAwaiter().GetResult();
            var answer = _answerRepo.FindByIdAsync(request.AnswerId!).GetAwaiter().GetResult();
            return new AttemptDetail {
                Answer = answer,
                Question = question
            };
        }
    }
}