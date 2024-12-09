using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<AppUser> _manager;
        public AppUserRepository(UserManager<AppUser> manager)
        {
            _manager = manager;
        }
        public async Task<AppUser> FindByIdAsync(string id){
            return (await _manager.FindByIdAsync(id))!;
        }
        public async Task<string> GetRoleAsync(AppUser user){
            var roles = await _manager.GetRolesAsync(user);
            return roles.FirstOrDefault()!;
        }
    }
}