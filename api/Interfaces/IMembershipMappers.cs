using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Membership;
using api.Models;

namespace api.Interfaces
{
    public interface IMembershipMappers
    {
        Membership ToMembershipFromMembershipRequestDto(MembershipRequestDto request);
        List<MembershipResponseDto> ToMembershipResponseDtosFromMemberships(List<Membership> memberships);
    }
}