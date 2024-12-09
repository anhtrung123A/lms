using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Classroom;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Mappers
{
    public class ClassroomMappers : IClassroomMappers
    {
        private readonly IAppUserRepository _userRepo;
        public ClassroomMappers(IAppUserRepository userRepo)
        {
            _userRepo = userRepo;   
        }
        public Classroom ToClassroomFromClassroomCreateDto(ClassroomCreateDto request){
            return new Classroom {
              ClassName = request.ClassName,
            };
        }
        public ClassroomInfoResponseDto ToClassroomInfoFromClassroom(Classroom classroom){
            var teacher = _userRepo.FindByIdAsync(classroom.TeacherId).GetAwaiter().GetResult();
            return new ClassroomInfoResponseDto {
                TeacherName = teacher.UserName,
                ClassName = classroom.ClassName,
                CreatedOn = classroom.CreatedOn
            };
        }
    }
}