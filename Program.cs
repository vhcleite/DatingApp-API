using System;
using DatingApp.API.Data;
using DatingApp.API.vscode.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var dataContext = scope.ServiceProvider.GetService<DataContext>();

                    dataContext.Database.Migrate();
                    Seed.SeedUsers(dataContext);
                }
                catch (Exception e)
                {
                    var logger = host.Services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occured during migration");
                }

            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
