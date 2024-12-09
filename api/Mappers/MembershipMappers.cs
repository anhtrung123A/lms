using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Membership;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Mappers
{
    public class MembershipMappers : IMembershipMappers
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClassroomRepository _classroomRepo;
        public MembershipMappers(UserManager<AppUser> userManager, IClassroomRepository classroomRepo)
        {
            _userManager = userManager;
            _classroomRepo = classroomRepo;
        }
        public Membership ToMembershipFromMembershipRequestDto(MembershipRequestDto request){
            var classroom = _classroomRepo.FindByIdAsync(request.ClassroomId).GetAwaiter().GetResult();
            return new Membership{
                Classroom = classroom!,
                IsApproved = false
            };
        }
        public List<MembershipResponseDto> ToMembershipResponseDtosFromMemberships(List<Membership> memberships){
            List<MembershipResponseDto> membershipResponseDtos = [];
            foreach(Membership m in memberships){
                var student = _userManager.FindByIdAsync(m.StudentId).GetAwaiter().GetResult();
                membershipResponseDtos.Add(new MembershipResponseDto{
                    Id = m.Id.ToString(),
                    StudentInfo = new Dtos.Account.StudentInfoDto {
                        Id = student!.Id,
                        UserName = student.UserName
                    },
                    SendAt = m.SendAt,
                    IsApproved = m.IsApproved
                });
            }
            return membershipResponseDtos;
        }

    }
}