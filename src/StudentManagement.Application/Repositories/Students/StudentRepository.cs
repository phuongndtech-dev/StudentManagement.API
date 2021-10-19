using Dapper;
using Microsoft.Extensions.Configuration;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Helpers;
using StudentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SqlConnection connection;

        private readonly IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            connection = new SqlConnection(FileHelper.GetConnectionString(_configuration));
        }

        public async Task<Student> CreateAsync(AddOrUpdateStudentDto dto)
        {
            string sqlInsert = @$"INSERT INTO Student (ID, NAME, YEAR, ADDRESS, EMAIL) 
                                  VALUES('{dto.Id}', '{dto.Name}', '{dto.Year}', '{dto.Address}','{dto.Email}')";

            await connection.ExecuteAsync(sqlInsert, CommandType.Text);

            var dataResponse = await GetStudentByIdAsync(dto.Id);

            return dataResponse;
        }

        public async Task DeleteAsync(Guid id)
        {
            var storeProc = "sp_DeleteStudent";

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await connection.ExecuteAsync(storeProc, dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Student>> GetAsync()
        {
            string sql = "SELECT * FROM Student";

            var student = await connection.QueryAsync<Student>(sql, CommandType.Text);

            return student.ToList();
        }

        public async Task<Student> UpdateAsync(AddOrUpdateStudentDto dto)
        {
            var storeProc = "sp_UpdateStudent";

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", dto.Id);
            dynamicParameters.Add("@name", dto.Name);
            dynamicParameters.Add("@year", dto.Year);
            dynamicParameters.Add("@address", dto.Address);
            dynamicParameters.Add("@email", dto.Email);

            await connection.ExecuteAsync(storeProc, dynamicParameters, commandType: CommandType.StoredProcedure);

            var dataResponse = await GetStudentByIdAsync(dto.Id);

            return dataResponse;
        }

        private async Task<Student> GetStudentByIdAsync(Guid id)
        {
            string sqlQuery = $"SELECT * FROM Student WHERE Id = '{id}'";

            var student = await connection.QueryFirstAsync<Student>(sqlQuery, CommandType.Text);

            return student;
        }
    }
}