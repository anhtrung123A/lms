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
    public class AttemptRepository : IAttemptRepository
    {
        private readonly ApplicationDBContext _context;
        public AttemptRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Attempt> CreateAsync(Attempt attempt){
            var _attempt = await _context.Attempts.AddAsync(attempt);
            await _context.SaveChangesAsync();
            return attempt;
        }
        public async Task<Attempt> FindByIdAsync(string id){
            return (await _context.Attempts.FindAsync(new Guid(id)))!;
        }
        public async Task<List<Attempt>> FindAllByTestIdAsync(string id){
            return (await _context.Attempts.Where(a => a.TestId.ToString() == id).ToListAsync())!;
        }
        public async Task<Attempt> FindByStudentIdAndTestId(string studentId, string testId){
            return (await _context.Attempts.FirstOrDefaultAsync(a => a.StudentId == studentId && a.TestId == new Guid(testId)))!;
        }
    }
}