using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Classroom;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/classroom")]
    [ApiController]
    [Authorize]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IClassroomMappers _classroomMappers;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserRepository _userRepo;
        public ClassroomController(IClassroomRepository classroomRepository,  IClassroomMappers classroomMappers, UserManager<AppUser> userManager, IAppUserRepository userRepo)
        {
            _classroomMappers = classroomMappers;
            _classroomRepository = classroomRepository;
            _userManager = userManager;
            _userRepo = userRepo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id){
            var classroom = await _classroomRepository.FindByIdAsync(id);
            if (classroom == null){
                return NotFound();
            }
            return Ok(_classroomMappers.ToClassroomInfoFromClassroom(classroom));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ClassroomCreateDto request){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var role = await _userRepo.GetRoleAsync(user!);
            if (role == "Teacher"){
                var classroom = _classroomMappers.ToClassroomFromClassroomCreateDto(request);
                classroom.Teacher = user!;
                await _classroomRepository.CreateAsync(classroom);
                return CreatedAtAction(nameof(GetById), new {id = classroom.Id}, _classroomMappers.ToClassroomInfoFromClassroom(classroom));
            }
            return Unauthorized();
        }
    }
}