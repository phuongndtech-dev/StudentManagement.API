using StudentManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAsync();
        Task<StudentDto> CreateAsync(AddOrUpdateStudentDto dto);
        Task<StudentDto> UpdateAsync(AddOrUpdateStudentDto dto, Guid id);
        Task DeleteAsync(Guid id);
    }
}