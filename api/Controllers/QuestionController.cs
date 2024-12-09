using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Question;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/question")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly IQuestionMappers _questionMappers;
        private readonly UserManager<AppUser> _userManager;
        private readonly IClassroomRepository _classroomRepo;
        private readonly ITestRepository _testRepo;
        private readonly IAnswerRepository _answerRepo;
        public QuestionController(IQuestionRepository questionRepo, IQuestionMappers questionMappers, UserManager<AppUser> userManager, IClassroomRepository classroomRepo, ITestRepository testRepo, IAnswerRepository answerRepo)
        {
            _questionRepo = questionRepo;
            _questionMappers = questionMappers;
            _userManager = userManager;
            _classroomRepo = classroomRepo;
            _testRepo = testRepo;
            _answerRepo = answerRepo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionsCreateRequestDto request){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var test = await _testRepo.FindByIdAsync(request.TestId);
            var classroom = await _classroomRepo.FindByIdAsync(test.ClassroomId.ToString());
            List<Question> questions = [];
            foreach (QuestionCreateRequestDto questionCreateRequestDto in request.Questions!){
                var question = _questionMappers.ToQuestionFromQuestionCreateRequestDto(questionCreateRequestDto);
                question.Test = test;
                questions.Add(question);
            }
            if (user!.Id == classroom!.TeacherId){
                var question = await _questionRepo.CreateAsync(questions);
                return Ok();
            }
            return Unauthorized();
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestionByTestId(string testId){
            var questions = await _questionRepo.FindAllByTestIdAsync(testId);
            var _questions = _questionMappers.ToQuestionResponseDtosFromQuestions(questions);
            return Ok(_questions);
        }
        [HttpGet("check")]
        public async Task<IActionResult> GetQuestionWithCorrectAnswerByTestId(string testId){
            var questions = await _questionRepo.FindAllByTestIdAsync(testId);
            var _questions = _questionMappers.ToQuestionResponseDtosWithCorrectAnswerFromQuestions(questions);
            return Ok(_questions);
        }
    }
}