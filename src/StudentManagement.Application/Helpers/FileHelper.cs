namespace StudentManagement.Application.Helpers
{
    public static class FileHelper
    {
        public static string GetConnectionString()
        {
            var connectionString = @"Server=PHUONGND_TECH\SQLEXPRESS;Database=StudentManagement;Trusted_Connection=True;";

            return connectionString;
        }
    }
}