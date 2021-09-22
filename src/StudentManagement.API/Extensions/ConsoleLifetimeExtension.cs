using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StudentManagement.Infrastructure.Persistence.Migrations;

namespace StudentManagement.API.Extensions
{
    public static class ConsoleLifetimeExtension
    {
        public static void AddConsoleLifetime(this IApplicationBuilder app,
         IWebHostEnvironment env)
        {
            var hostApplicationLifetime = app
                .ApplicationServices
                .GetService(typeof(IHostApplicationLifetime)) as IHostApplicationLifetime;

            var configuration = app
                .ApplicationServices
                .GetService(typeof(IConfiguration)) as IConfiguration;

            hostApplicationLifetime.ApplicationStarted.Register(() =>
            {

                if (!env.EnvironmentName.Equals("Test"))
                {
                    MigrationFactory.Migrate(configuration);
                }
            });
        }
    }
}