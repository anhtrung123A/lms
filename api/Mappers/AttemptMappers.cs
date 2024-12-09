using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.Attempt;
using api.Dtos.AttemptDetail;
using api.Dtos.Question;
using api.Dtos.Result;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Mappers
{
    public class AttemptMappers : IAttemptMappers
    {
        private readonly IAttemptDetailMappers _attemptDetailMappers;
        private readonly ITestRepository _testRepo;
        private readonly UserManager<AppUser> _userManager;
        public AttemptMappers(IAttemptDetailMappers attemptDetailMappers, ITestRepository testRepo, UserManager<AppUser> userManager)
        {
            _attemptDetailMappers = attemptDetailMappers;
            _testRepo = testRepo;
            _userManager = userManager;
        }
        public Attempt ToAttemptFromAttemptRequestDto(AttemptRequestDto request){
            ICollection<AttemptDetail> attemptDetails = [];
            foreach(AttemptDetailRequestDto a in request.AttemptDetails!){
                attemptDetails.Add(_attemptDetailMappers.ToAttemptDetailFromAttemptDetailRequestDto(a));
            }
            var test = _testRepo.FindByIdAsync(request.TestId!).GetAwaiter().GetResult();
            return new Attempt {
                Test = test,
                AttemptDetail = attemptDetails
            };
        }
        public ResultResponseDto ToResultResponseDtoFromAttemptAndAttemptDetail(Attempt attempt, List<AttemptDetail> attemptDetails, List<QuestionResponseWithStateDto> questions){
            List<QuestionAndResultDto> questionAndResultDtos = [];
            foreach(QuestionResponseWithStateDto qRWS in questions){
                var aD = attemptDetails.Find(a => a.QuestionId.ToString() == qRWS.Id);
                questionAndResultDtos.Add(new QuestionAndResultDto{
                    Question = qRWS,
                    StudentChoiceId = aD!.AnswerId.ToString()
                });
            }
            return new ResultResponseDto {
                DoneAt = attempt.DoneAt,
                Mark = attempt.Mark,
                Result = questionAndResultDtos
            };
        }
        public List<AttemptResponseDto> ToAttemptResponseDtosFromAttempts(List<Attempt> attempts){
            List<AttemptResponseDto> attemptResponseDtos = [];
            foreach(Attempt a in attempts){
                var student = _userManager.FindByIdAsync(a.StudentId!).GetAwaiter().GetResult();
                attemptResponseDtos.Add(new AttemptResponseDto{
                    DoneAt = a.DoneAt,
                    Mark = a.Mark,
                    Student = new StudentInfoDto{
                        Id = student!.Id,
                        UserName = student.UserName
                    }
                });
            }
            return attemptResponseDtos;
        }
    }
}