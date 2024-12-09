using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;

namespace api.Dtos.Membership
{
    public class MembershipResponseDto
    {
        public string? Id { get; set; }
        public StudentInfoDto? StudentInfo {get; set;}
        public bool IsApproved { get; set; }
        public DateTime SendAt {get; set;}
    }
}