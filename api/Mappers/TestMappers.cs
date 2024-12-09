using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Interfaces;
using api.Models;

namespace api.Mappers
{
    public class TestMappers : ITestMappers
    {
        private readonly IClassroomRepository _classroomRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly IQuestionMappers _questionMappers;
        public TestMappers(IClassroomRepository classroomRepo, IQuestionRepository questionRepo, IQuestionMappers questionMappers)
        {
            _classroomRepo = classroomRepo;   
            _questionMappers = questionMappers;
            _questionRepo = questionRepo;
        }
        public Test ToTestFromTestCreateRequestDto(TestCreateRequestDto request){
            var classroom = _classroomRepo.FindByIdAsync(request.ClassroomId).GetAwaiter().GetResult();
            return new Test {
                Classroom = classroom!,
                Name = request.Name,
                TimeLimit = request.TimeLimit
            };
        }
        public List<TestResponseDto> ToTestResponseDtosFromTests(List<Test> tests){
            List<TestResponseDto> testResponseDtos = [];
            foreach(Test t in tests){
                testResponseDtos.Add(new TestResponseDto{
                    Id = t.Id,
                    Name = t.Name,
                    CreatedOn = t.CreatedOn,
                    TimeLimit = t.TimeLimit
                });
            }
            return testResponseDtos;
        }
        public TestResponseDtoWithQuestion ToTestResponseDtoWithQuestionFromTest(Test test){
            var questions = _questionRepo.FindAllByTestIdAsync(test.Id.ToString()).GetAwaiter().GetResult();
            var questions_ = _questionMappers.ToQuestionResponseDtosFromQuestions(questions);
            return new TestResponseDtoWithQuestion {
                Id = test.Id,
                Name = test.Name,
                CreatedOn = test.CreatedOn,
                TimeLimit = test.TimeLimit,
                Questions = questions_
            };
        } 
    }
}