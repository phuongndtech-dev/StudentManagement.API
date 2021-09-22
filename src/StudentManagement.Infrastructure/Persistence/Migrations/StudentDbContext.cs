using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Persistence
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
    }
}