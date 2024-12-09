using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllAsync();
        Task<Classroom?> FindByIdAsync(string id);
        Task<Classroom> CreateAsync(Classroom classroom);
    }
}