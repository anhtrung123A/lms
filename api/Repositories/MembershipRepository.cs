using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly ApplicationDBContext _context;
        public MembershipRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Membership>> GetAllAsync(){
            return await _context.Memberships.ToListAsync();
        }
        public async Task<Membership> CreateAsync(Membership membership){
            await _context.Memberships.AddAsync(membership);
            await _context.SaveChangesAsync();
            return membership;
        }
        public async Task<Membership> AcceptRequestAsync(Membership membership){
            var _membership = await _context.Memberships.FirstOrDefaultAsync(x => x.Id == membership.Id);
            if (_membership == null){
                return null!;
            }
            _membership.IsApproved = true;
            await _context.SaveChangesAsync();
            return _membership;
        }
        public async Task<Membership?> FindByIdAsync(string id){
            Guid guid = Guid.Parse(id);
            return (await _context.Memberships.FindAsync(guid))!;
        }
        public async Task<Membership> FindByClassroomIdAndStudentIdAsync(string classroomId, string studentId){
            Guid cGuid = Guid.Parse(classroomId);
            return (await _context.Memberships.FirstOrDefaultAsync(m => m.ClassroomId == cGuid && m.StudentId == studentId))!;
        }
        public async Task<List<Membership>> FindAllByClassroomIdAsync(string classroomId){
            Guid cGuid = Guid.Parse(classroomId);
            return await _context.Memberships.Where(m => m.ClassroomId == cGuid).ToListAsync();
        }

    }
}