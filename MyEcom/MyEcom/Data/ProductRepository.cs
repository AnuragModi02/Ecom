using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEcom.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var ProductBrand = await _context.ProductBrands.ToListAsync();
            return ProductBrand;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            var ProductType = await _context.ProductTypes.ToListAsync();
            return ProductType;
        }
    }
}
