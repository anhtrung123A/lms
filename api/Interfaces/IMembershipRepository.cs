using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IMembershipRepository
    {
        Task<List<Membership>> GetAllAsync();
        Task<Membership> CreateAsync(Membership membership);
        Task<Membership> AcceptRequestAsync(Membership membership);
        Task<Membership> FindByIdAsync(string id);
        Task<Membership> FindByClassroomIdAndStudentIdAsync(string classroomId, string studentId);
        Task<List<Membership>> FindAllByClassroomIdAsync(string classroomId);
    }
}