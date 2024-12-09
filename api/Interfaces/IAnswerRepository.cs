using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> FindAllAnswerByQuestionId(string questionId);
        Task<Answer> FindByIdAsync(string id);
    }
}