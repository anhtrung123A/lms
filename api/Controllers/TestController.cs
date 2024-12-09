using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/test")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepo;
        private readonly ITestMappers _testMapper;
        private readonly IClassroomRepository _classroomRepo;
        private readonly UserManager<AppUser> _userManager;
        public TestController(ITestRepository testRepo, ITestMappers testMapper, IClassroomRepository classroomRepo, UserManager<AppUser> userManager)
        {
            _testRepo = testRepo;
            _testMapper = testMapper;
            _classroomRepo = classroomRepo;
            _userManager = userManager;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateTest([FromBody] TestCreateRequestDto request){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var test = _testMapper.ToTestFromTestCreateRequestDto(request);
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var classroom = await _classroomRepo.FindByIdAsync(request.ClassroomId);
            if (user!.Id == classroom!.TeacherId){
                await _testRepo.CreateAsync(test);
                return Ok();
            }
            return Unauthorized();
        }
        // [HttpGet]
        // public async Task<IActionResult> GetTestById(string id){
        //     var test = await _testRepo.FindByIdAsync(id);
        //     return Ok(test);
        // }
        [HttpGet]
        public async Task<IActionResult> GetAllByClassroomId(string classroomId){
            var tests = await _testRepo.FindAllByClassroomIdAsync(classroomId);
            return Ok(_testMapper.ToTestResponseDtosFromTests(tests));
        }
        [HttpGet("get-test")]
        public async Task<IActionResult> GetById(string testId){
            var test = await _testRepo.FindByIdAsync(testId);
            if (test == null){
                return NotFound();
            }
            return Ok(_testMapper.ToTestResponseDtoWithQuestionFromTest(test));
        }
    }
}