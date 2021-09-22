using StudentManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Application.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAsync();
    }
}