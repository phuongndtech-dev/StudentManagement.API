using StudentManagement.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAsync();
        Task<StudentDto> CreateAsync(AddOrUpdateStudentDto dto);
    }
}