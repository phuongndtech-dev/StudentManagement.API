using Dapper;
using StudentManagement.Application.Helpers;
using StudentManagement.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<List<Student>> GetAsync()
        {
            string sqlStudents = "SELECT * FROM Student";

            using SqlConnection connection = new SqlConnection(FileHelper.GetConnectionString());

            var student = await connection.QueryAsync<Student>(sqlStudents);

            return student.ToList();
        }
    }
}