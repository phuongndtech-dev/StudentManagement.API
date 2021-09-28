using Dapper;
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

        public StudentRepository()
        {
            connection = new SqlConnection(FileHelper.GetConnectionString());
        }

        public async Task<Student> CreateAsync(AddOrUpdateStudentDto dto)
        {
            string sqlInsert = @$"INSERT INTO Student (ID, NAME, YEAR, ADDRESS, EMAIL) 
                                  VALUES('{dto.Id}', '{dto.Name}', '{dto.Year}', '{dto.Address}','{dto.Email}')";

            await connection.ExecuteAsync(sqlInsert, CommandType.Text);

            var dataResponse = await GetStudentByIdAsync(dto.Id);

            return dataResponse;
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

            DynamicParameters parameterDynamic = new DynamicParameters();

            parameterDynamic.Add("@id", dto.Id);
            parameterDynamic.Add("@name", dto.Name);
            parameterDynamic.Add("@year", dto.Year);
            parameterDynamic.Add("@address", dto.Address);
            parameterDynamic.Add("@email", dto.Email);

            await connection.ExecuteAsync(storeProc, parameterDynamic, commandType: CommandType.StoredProcedure);

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