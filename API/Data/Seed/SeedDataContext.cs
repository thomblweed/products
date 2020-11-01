using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.Extensions.Logging;

namespace API.Data.Seed
{
    public class SeedDataContext
    {
        public static async Task SeedAsync(DataStoreContext context, ILoggerFactory loggerFactory)
        {
            ILogger<SeedDataContext> logger = loggerFactory.CreateLogger<SeedDataContext>();

            try
            {
                if (context.Products.Any())
                {
                    context.Products.RemoveRange(context.Products);
                }

                List<Product> products = GenerateInitialProductData();

                foreach (Product product in products)
                {
                    context.Products.Add(product);
                }

                await context.SaveChangesAsync();
                logger.LogInformation("Data seeded successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        private static List<Product> GenerateInitialProductData()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Lavender heart",
                    Price = 9.25M
                },
                new Product
                {
                    Id = 2,
                    Name = "Personalised cufflinks",
                    Price = 45.00M
                },
                new Product
                {
                    Id = 3,
                    Name = "Kids T-shirt",
                    Price = 19.95M
                }
            };
        }
    }
}