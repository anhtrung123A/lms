using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.StudentAnswer;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly ApplicationDBContext _context;
        public TestResultRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public int GetScore(List<StudentAnswerDto> answerSheet){
            int count = 0;
            foreach(StudentAnswerDto s in answerSheet){
                var correctAnswer = _context.Answers.FirstOrDefaultAsync(a => a.QuestionId == new Guid(s.QuestionId!) && a.IsCorrect).GetAwaiter().GetResult();
                if (correctAnswer!.Id.ToString() == s.AnswerId){
                    count+= 10;
                }
            }
            return count;
        }
    }
}