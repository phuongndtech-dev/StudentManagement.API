using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Repositories;
using StudentManagement.Application.Services;
using System.Reflection;

namespace StudentManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
            services.AddLibraries();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
         
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }

        public static IServiceCollection AddLibraries(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation();
            services.AddTransient<IValidator<AddOrUpdateStudentDto>, AddOrUpdateStudentValidator>();

            return services;
        }
    }
}