using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace StudentManagement.Infrastructure.Persistence.Migrations
{
    public class MigrationFactory
    {
        public static void Migrate(IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("No Connection string should not empty.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>().UseSqlServer(connectionString);

            var context = new StudentDbContext(optionsBuilder.Options);

            context.Database.Migrate();
        }
    }
}
