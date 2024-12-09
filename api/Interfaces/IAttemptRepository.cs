using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAttemptRepository
    {
        Task<Attempt> CreateAsync(Attempt attempt);
        Task<Attempt> FindByIdAsync(string id);
        Task<List<Attempt>> FindAllByTestIdAsync(string id);
        Task<Attempt> FindByStudentIdAndTestId(string studentId, string testId);
    }
}