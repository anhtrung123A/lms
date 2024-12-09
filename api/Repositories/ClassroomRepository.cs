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
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly ApplicationDBContext _context;
        public ClassroomRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Classroom> CreateAsync(Classroom classroom){
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
            return classroom;
        }
        public async Task<List<Classroom>> GetAllAsync(){
            return await _context.Classrooms.ToListAsync();
        }
        public async Task<Classroom?> FindByIdAsync(string id){
            Guid guid = Guid.Parse(id);
            return await _context.Classrooms.FindAsync(guid);
        }
    }
}