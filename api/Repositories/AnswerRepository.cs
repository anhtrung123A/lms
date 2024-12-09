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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDBContext _context;
        public AnswerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Answer>> FindAllAnswerByQuestionId(string questionId){
            return await _context.Answers.Where(a => a.QuestionId == new Guid(questionId)).ToListAsync();
        }
        public async Task<Answer> FindByIdAsync(string id){
            return (await _context.Answers.FirstOrDefaultAsync(a => a.Id == new Guid(id)))!;
        }

    }
}