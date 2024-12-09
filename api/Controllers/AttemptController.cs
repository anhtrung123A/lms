using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Attempt;
using api.Dtos.AttemptDetail;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/attempt")]
    [ApiController]
    [Authorize]
    public class AttemptController : ControllerBase
    {
        private readonly IAttemptMappers _attemptMappers;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAttemptRepository _attemptRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly IQuestionMappers _questionMappers;
        private readonly ITestRepository _testRepo;
        private readonly IMembershipRepository _membershipRepo;
        private readonly IAttemptDetailRepository _attemptDetailRepo;
        private readonly IClassroomRepository _classroomRepo;
        public AttemptController(IAttemptMappers attemptMappers, UserManager<AppUser> userManager, IAttemptRepository attemptRepo, IQuestionRepository questionRepo, IQuestionMappers questionMappers, ITestRepository testRepo, IMembershipRepository membershipRepo, IAttemptDetailRepository attemptDetailRepo, IClassroomRepository classroomRepo)
        {
            _attemptMappers = attemptMappers;
            _userManager = userManager;
            _attemptRepo = attemptRepo;
            _questionMappers = questionMappers;
            _questionRepo = questionRepo;
            _testRepo = testRepo;
            _membershipRepo = membershipRepo;
            _attemptDetailRepo = attemptDetailRepo;
            _classroomRepo = classroomRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateNewAttempt([FromBody] AttemptRequestDto request){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var test = await _testRepo.FindByIdAsync(request.TestId!);
            var membership = await _membershipRepo.FindByClassroomIdAndStudentIdAsync(test.ClassroomId.ToString(), user!.Id);
            if (membership == null || !membership.IsApproved){
                return Unauthorized();
            }
            var existedAttempt = await _attemptRepo.FindByStudentIdAndTestId(user.Id, request.TestId!);
            if (existedAttempt == null){
                float count = 0;
                var attempt = _attemptMappers.ToAttemptFromAttemptRequestDto(request);
                attempt.Student = user;
                var question = await _questionRepo.FindAllByTestIdAsync(request.TestId!);
                var key = _questionMappers.ToQuestionResponseDtosWithCorrectAnswerFromQuestions(question);
                foreach (AttemptDetailRequestDto attemptDetailRequestDto in request.AttemptDetails!){
                    var correctAnswer = key.FirstOrDefault(q => q.Id == attemptDetailRequestDto.QuestionId)?.Answers?[0].AnswerId;
                    if (attemptDetailRequestDto.AnswerId == correctAnswer){
                        count ++;
                    }
                }
                attempt.Mark = 10/(float)question.Count()*count;
                await _attemptRepo.CreateAsync(attempt);
                return Ok();
            }
            return Forbid();
        }
        [HttpGet("view-result")]
        public async Task<IActionResult> GetAttempt(string attemptId){
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var attempt = await _attemptRepo.FindByIdAsync(attemptId);
            var test = await _testRepo.FindByIdAsync(attempt.TestId.ToString());
            var classroom = await _classroomRepo.FindByIdAsync(test.ClassroomId.ToString());
            if (user!.Id == attempt.StudentId || user.Id == classroom!.TeacherId){
                var attempDetails = await _attemptDetailRepo.FindAllByAttemptIdAsync(attemptId);
                var questions = await _questionRepo.FindAllByTestIdAsync(attempt.TestId.ToString());
                var _questions = _questionMappers.ToQuestionResponseDtosWithAllAnswerFromQuestions(questions);
                //var key = _questionMappers.ToQuestionResponseDtosWithCorrectAnswerFromQuestions(question);
                var _qAndR = _attemptMappers.ToResultResponseDtoFromAttemptAndAttemptDetail(attempt, attempDetails, _questions);
                return Ok(_qAndR);
            }
            return Unauthorized();
        }
        [HttpGet("view-all-results")]
        public async Task<IActionResult> GetAllAttemptByTestId([FromQuery] string testId){
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var test = await _testRepo.FindByIdAsync(testId);
            var classroom = await _classroomRepo.FindByIdAsync(test.ClassroomId.ToString());
            if (user!.Id == classroom!.TeacherId){
                var attempts = await _attemptRepo.FindAllByTestIdAsync(testId);
                var _attempts = _attemptMappers.ToAttemptResponseDtosFromAttempts(attempts);
                return Ok(_attempts);
            }
            return Unauthorized();
        }
    }
}