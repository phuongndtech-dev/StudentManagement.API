using System;
using FluentValidation;

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

    public class AddOrUpdateStudentValidator: AbstractValidator<AddOrUpdateStudentDto>
    {
        public AddOrUpdateStudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Year is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid");
        }
    }
}