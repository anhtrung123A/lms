using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> CreateAsync(List<Question> questions);
        Task<List<Question>> FindAllByTestIdAsync(string testId);
        Task<Question> FindByIdAsync(string id);
    }
}