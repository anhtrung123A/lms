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
    public class AttemptDetailRepository : IAttemptDetailRepository
    {
        private readonly ApplicationDBContext _context;
        public AttemptDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<AttemptDetail>> FindAllByAttemptIdAsync(string id){
            return await _context.AttemptDetails.Where(a => a.AttemptId == new Guid(id)).ToListAsync();
        }
    }
}