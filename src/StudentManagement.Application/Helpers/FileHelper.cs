using Microsoft.Extensions.Configuration;

namespace StudentManagement.Application.Helpers
{
    public static class FileHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            return connectionString;
        }
    }
}