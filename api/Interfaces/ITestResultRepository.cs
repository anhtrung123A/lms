using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.StudentAnswer;
using api.Models;

namespace api.Interfaces
{
    public interface ITestResultRepository
    {
        int GetScore(List<StudentAnswerDto> answerSheet);   
    }
}