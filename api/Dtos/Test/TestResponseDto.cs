using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Test
{
    public class TestResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TimeLimit { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}