using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Web.Data;
using Project.Web.Models;

namespace CategoriesApiTests
{
    public static class DbContextMocker
    {
        public static ApplicationDbContext GetApplicationDbContext(string databasename)
        {
            // Create a fresh service provider for the InMemory Database instance.
            var serviceProvider = new ServiceCollection()
                                  .AddEntityFrameworkInMemoryDatabase()
                                  .BuildServiceProvider();

            // Create a new options instance,
            // telling the context to use InMemory database and the new service provider.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databasename)
                            .UseInternalServiceProvider(serviceProvider)
                            .Options;

            // Create the instance of the DbContext (would be an InMemory database)
            // NOTE: It will use the Scema as defined in the Data and Models folders
            var dbContext = new ApplicationDbContext(options);

            // Add entities to the inmemory database
            dbContext.SeedData();

            return dbContext;
        }
        internal static readonly Category[] TestData_Categories
            = {
                new Category
                {
                    CatgoryId = 1,
                    Categories = "First Category"
                    
                },
                new Category
                {

                    CatgoryId= 2,
                    Categories = "Second Category"
                    
                },
                new Category
                {

                    CatgoryId = 3,
                    Categories = "Third Category"
                    
                },
                new Category
                {
                    CatgoryId = 4,
                    Categories = "Fourth Category"

                }
            };

        private static void SeedData(this ApplicationDbContext context)
        {
            context.Categories.AddRange(TestData_Categories);

            context.SaveChanges();
        }
    }
}