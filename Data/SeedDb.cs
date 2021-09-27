using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PostService.Models;

namespace PostService.Data {
    public static class SeedDb {
        public static void Seed (IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.CreateScope ()) {
                SeedData (serviceScope.ServiceProvider.GetService<AppDbContext> ());
            }
        }

        private static void SeedData (AppDbContext context) {
            if (!context.Posts.Any ()) {
                System.Console.WriteLine(" ===> Seeding Database ...");
                    context.Posts.AddRange(
                         new Post(){Title = "Title 1", Content = "Content 1", PublishedDate = DateTime.Now },  
                          new Post(){Title = "Title 2", Content = "Content 2", PublishedDate = DateTime.Now.AddHours(-5) },  
                           new Post(){Title = "Title 3", Content = "Content 3", PublishedDate = DateTime.Now.AddHours(-2) }  
                    );
                    context.SaveChanges();
            }else{
                 System.Console.WriteLine(" ===> We already have data.");
            }

        }

    }
}