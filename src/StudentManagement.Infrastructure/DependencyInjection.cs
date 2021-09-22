using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Interfaces;
using StudentManagement.Infrastructure.Persistence;
using System;

namespace StudentManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentDbContext>(options =>
                      options.UseSqlServer(
                          configuration.GetConnectionString("DefaultConnection"),
                          b => b.MigrationsAssembly(typeof(StudentDbContext).Assembly.FullName)));

            services.AddScoped<IStudentDbContext>(provider => provider.GetService<StudentDbContext>());

            return services;
        }
    }
}