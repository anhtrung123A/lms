using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.StudentAnswer;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/result")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ITestResultRepository _testResultRepo;
        public ResultController(ITestResultRepository testResultRepo)
        {
            _testResultRepo = testResultRepo;   
        }
        [HttpPost]
        public IActionResult GetStudentResult([FromBody] List<StudentAnswerDto> answerSheet){
            var score = _testResultRepo.GetScore(answerSheet);
            return Ok(score);
        }
    }
}