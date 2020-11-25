using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                await AddBrands(storeContext);
                await AddTypes(storeContext);
                await AddProducts(storeContext);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e.Message);
            }   

        }

        private static async Task AddBrands(StoreContext storeContext)
        {
            if (!storeContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                foreach (var item in brands)
                {
                    storeContext.ProductBrands.Add(item);
                }

                await storeContext.SaveChangesAsync();
            }
        }

        private static async Task AddTypes(StoreContext storeContext)
        {
            if (!storeContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                foreach (var item in types)
                {
                    storeContext.ProductTypes.Add(item);
                }

                await storeContext.SaveChangesAsync();
            }
        }
        private static async Task AddProducts(StoreContext storeContext)
        {
            if (!storeContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                foreach (var item in products)
                {
                    storeContext.Products.Add(item);
                }

                await storeContext.SaveChangesAsync();
            }
        }
    }
}