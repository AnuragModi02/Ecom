using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(int id);

        Task<IReadOnlyList<Product>> GetProductsAsync(int page);

        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}
