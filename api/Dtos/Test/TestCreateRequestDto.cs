using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Test
{
    public class TestCreateRequestDto
    {
        public string ClassroomId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int TimeLimit { get; set; }
    }
}