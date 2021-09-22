using AutoMapper;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> GetAsync()
        {
            var student = await _studentRepository.GetAsync();

            var studentResponse = student.Select(x => _mapper.Map<StudentDto>(x)).ToList();

            return studentResponse;
        }
    }
}