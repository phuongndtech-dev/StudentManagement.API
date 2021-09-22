using StudentManagement.Application.Mappings;
using StudentManagement.Domain.Entities;
using System;

namespace StudentManagement.Application.DTOs
{
    public class StudentDto: IMapFrom<Student>
    {
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}