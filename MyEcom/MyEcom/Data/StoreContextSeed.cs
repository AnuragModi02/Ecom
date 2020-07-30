using Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyEcom.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("C:\\Users\\anura\\source\\repos\\Ecom\\MyEcom\\MyEcom\\Data\\SeedData\\brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var producttype = File.ReadAllText("C:\\Users\\anura\\source\\repos\\Ecom\\MyEcom\\MyEcom\\Data\\SeedData\\types.json");

                    var type = JsonSerializer.Deserialize<List<ProductType>>(producttype);

                    foreach (var item in type)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.products.Any())
                {
                    var products = File.ReadAllText("C:\\Users\\anura\\source\\repos\\Ecom\\MyEcom\\MyEcom\\Data\\SeedData\\products.json");

                    var productlist = JsonSerializer.Deserialize<List<Product>>(products);

                    foreach (var item in productlist)
                    {
                        context.products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
