using AutoMapper;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Repositories;
using System;
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

        public async Task<StudentDto> CreateAsync(AddOrUpdateStudentDto dto)
        {
            dto.Id = Guid.NewGuid();

            var data = await _studentRepository.CreateAsync(dto);

            var response = _mapper.Map<StudentDto>(data);

            return response;
        }

        public async Task<List<StudentDto>> GetAsync()
        {
            var datas = await _studentRepository.GetAsync();

            var response = datas.Select(x => _mapper.Map<StudentDto>(x)).ToList();

            return response;
        }
    }
}