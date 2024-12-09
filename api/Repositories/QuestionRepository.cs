using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Question>> CreateAsync(List<Question> questions){
            await _context.Questions.AddRangeAsync(questions);
            await _context.SaveChangesAsync();
            return questions;
        }
        public async Task<List<Question>> FindAllByTestIdAsync(string testId){
            return await _context.Questions.Where(q => q.TestId == new Guid(testId)).ToListAsync();
        }
        public async Task<Question> FindByIdAsync(string id){
            return (await _context.Questions.FirstOrDefaultAsync(q => q.Id == new Guid(id)))!;
        }
    }
}