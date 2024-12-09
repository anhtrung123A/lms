using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base (dbContextOptions)
        {   
        }
        public DbSet<Stock> Stocks {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Classroom> Classrooms {get; set;}
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions {get; set;}
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Attempt> Attempts {get; set;}
        public DbSet<AttemptDetail> AttemptDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole> {
                new IdentityRole 
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole 
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                },
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}