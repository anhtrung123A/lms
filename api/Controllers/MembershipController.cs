using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dtos.Membership;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/membership")]
    [ApiController]
    [Authorize]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipRepository _membershipRepo;
        private readonly IMembershipMappers _membershipMappers;
        private readonly UserManager<AppUser> _userManager;
        private readonly IClassroomRepository _classroomRepo;
        public MembershipController(IMembershipRepository membershipRepo, IMembershipMappers membershipMappers, UserManager<AppUser> userManager, IClassroomRepository classroomRepo)
        {
            _membershipMappers = membershipMappers;
            _membershipRepo = membershipRepo;
            _userManager = userManager;
            _classroomRepo = classroomRepo;
        }
        [HttpPost("request")]
        public async Task<IActionResult> CreateMembershipRequest(string classroomId){
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var membership = _membershipMappers.ToMembershipFromMembershipRequestDto(new MembershipRequestDto{ClassroomId = classroomId});
            membership.Student = user!;
            await _membershipRepo.CreateAsync(membership);
            return Ok();
        }
        [HttpPut("accept")]
        public async Task<IActionResult> AcceptRequest(string membershipId){
            var membership = await _membershipRepo.FindByIdAsync(membershipId);
            if (membership == null){
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var classroom = await _classroomRepo.FindByIdAsync(membership.ClassroomId.ToString()!);
            if (user!.Id == classroom!.TeacherId){
                await _membershipRepo.AcceptRequestAsync(membership);
                return Ok();
            }
            return Unauthorized();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByClassroomId(string classroomId){
            var user = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var classroom = await _classroomRepo.FindByIdAsync(classroomId);
            if (user!.Id == classroom!.TeacherId){
                var membership = await _membershipRepo.FindAllByClassroomIdAsync(classroomId);
                return Ok(_membershipMappers.ToMembershipResponseDtosFromMemberships(membership));
            }
            return Unauthorized();
        }
    }
}