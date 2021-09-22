using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentManagement.Infrastructure.Persistence.Migrations
{
    public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
    {
        public StudentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>().UseSqlServer("DefaultConnection");

            return new StudentDbContext(optionsBuilder.Options);
        }
    }
}