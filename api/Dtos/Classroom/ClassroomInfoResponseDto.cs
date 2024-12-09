using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Classroom
{
    public class ClassroomInfoResponseDto
    {
        public string ClassName { get; set; } = string.Empty;
        public string? TeacherName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}