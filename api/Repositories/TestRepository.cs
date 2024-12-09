using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Test;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDBContext _context;
        public TestRepository(ApplicationDBContext context)
        {
            _context = context;
        }   
        public async Task<List<TestResponseDto>> GetAllAsync(){
            return null!;
        }
        public async Task<Test> CreateAsync(Test test){
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }
        public async Task<Test> FindByIdAsync(string id){
            Guid guid = Guid.Parse(id);
            return (await _context.Tests.FindAsync(guid))!;
        }
        public async Task<List<Test>> FindAllByClassroomIdAsync(string classroomId){
            Guid cGuid = Guid.Parse(classroomId);
            var tests = await _context.Tests.Where(t => t.ClassroomId == cGuid).ToListAsync();
            return tests;
        }

    }
}