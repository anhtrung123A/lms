using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Models;

namespace api.Interfaces
{
    public interface ITestRepository
    {
        Task<List<TestResponseDto>> GetAllAsync();
        Task<Test> CreateAsync(Test test);
        Task<Test> FindByIdAsync(string id);
        Task<List<Test>> FindAllByClassroomIdAsync(string classroomId);
    }
}