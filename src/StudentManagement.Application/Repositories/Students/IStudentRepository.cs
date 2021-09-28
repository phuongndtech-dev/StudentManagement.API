using StudentManagement.Application.DTOs;
using StudentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Application.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAsync();
        Task<Student> CreateAsync(AddOrUpdateStudentDto dto);
        Task<Student> UpdateAsync(AddOrUpdateStudentDto dto);
        Task DeleteAsync(Guid id);
    }
}