using Dapper;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Helpers;
using StudentManagement.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<Student> CreateAsync(AddOrUpdateStudentDto dto)
        {
            string sqlInsert = @$"INSERT INTO Student (ID, NAME, YEAR, ADDRESS, EMAIL) 
                                  VALUES('{dto.Id}', '{dto.Name}', '{dto.Year}', '{dto.Address}','{dto.Email}')";

            string sqlQuery = $"SELECT * FROM Student WHERE Id = '{dto.Id}'";

            using SqlConnection connection = new SqlConnection(FileHelper.GetConnectionString());

            var student = await connection.ExecuteAsync(sqlInsert, CommandType.Text);

            var dataResponse = await connection.QueryFirstAsync<Student>(sqlQuery, CommandType.Text);

            return dataResponse;
        }

        public async Task<List<Student>> GetAsync()
        {
            string sql = "SELECT * FROM Student";

            using SqlConnection connection = new SqlConnection(FileHelper.GetConnectionString());

            var student = await connection.QueryAsync<Student>(sql, CommandType.Text);

            return student.ToList();
        }
    }
}