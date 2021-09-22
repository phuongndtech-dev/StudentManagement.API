using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Entities;
using System;

namespace StudentManagement.Application.Interfaces
{
    public interface IStudentDbContext: IDisposable
    {
        DbSet<Student> Student { get; set; }
    }
}