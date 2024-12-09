using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Answer;
using api.Dtos.Question;
using api.Interfaces;
using api.Models;

namespace api.Mappers
{
    public class QuestionMappers : IQuestionMappers
    {
        private readonly IAnswerMappers _answerMapper;
        private readonly IAnswerRepository _answerRepo;
        public QuestionMappers(IAnswerMappers answerMapper, IAnswerRepository answerRepo)
        {
            _answerMapper = answerMapper;
            _answerRepo = answerRepo;
        }
        public Question ToQuestionFromQuestionCreateRequestDto(QuestionCreateRequestDto request){
            ICollection<Answer> answers = [];
            foreach (AnswerCreateRequestDto answer in request.Answers!)
            {
                answers.Add(_answerMapper.ToAnswerFromAnswerCreateRequestDto(answer));
            };
            return new Question {
                Content = request.Content,
                Answers = answers
            };
        }
        public List<QuestionResponseDto> ToQuestionResponseDtosFromQuestions(List<Question> questions){
            List<QuestionResponseDto> _questions = [];
            foreach(Question q in questions){
                var answers = _answerRepo.FindAllAnswerByQuestionId(q.Id.ToString()).GetAwaiter().GetResult();
                List<AnswerResponseDto> _answers = [];
                foreach(Answer a in answers){
                    _answers.Add(_answerMapper.ToAnswerResponseDtoFromAnswer(a));
                }
                _questions.Add(new QuestionResponseDto {
                    Id = q.Id.ToString(),
                    Content = q.Content,
                    Answers = _answers
                });
            }
            return _questions;
        }
        public List<QuestionResponseDto> ToQuestionResponseDtosWithCorrectAnswerFromQuestions(List<Question> questions){
            List<QuestionResponseDto> _questions = [];
            foreach(Question q in questions){
                var answers = _answerRepo.FindAllAnswerByQuestionId(q.Id.ToString()).GetAwaiter().GetResult();
                List<AnswerResponseDto> _answers = [];
                foreach(Answer a in answers){
                    if (a.IsCorrect){
                        _answers.Add(_answerMapper.ToAnswerResponseDtoFromAnswer(a));
                    }
                }
                _questions.Add(new QuestionResponseDto {
                    Id = q.Id.ToString(),
                    Content = q.Content,
                    Answers = _answers
                });
            }
            return _questions;
        }
        public List<QuestionResponseWithStateDto> ToQuestionResponseDtosWithAllAnswerFromQuestions(List<Question> questions){
            List<QuestionResponseWithStateDto> _questions = [];
            foreach(Question q in questions){
                var answers = _answerRepo.FindAllAnswerByQuestionId(q.Id.ToString()).GetAwaiter().GetResult();
                List<AnswerResponseWithStateDto> _answers = [];
                foreach(Answer a in answers){
                    _answers.Add(_answerMapper.ToAnswerResponseWithStateDtoFromAnswer(a));
                }
                _questions.Add(new QuestionResponseWithStateDto {
                    Id = q.Id.ToString(),
                    Content = q.Content,
                    Answers = _answers
                });
            }
            return _questions;
        }
    }
}