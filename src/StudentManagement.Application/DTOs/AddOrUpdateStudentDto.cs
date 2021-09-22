using System;

namespace StudentManagement.Application.DTOs
{
    public class AddOrUpdateStudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}