using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        public static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundatin", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}