using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Repositories;
using StudentManagement.Application.Services;
using System.Reflection;

namespace StudentManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}