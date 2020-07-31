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
        int pagesize = 5;

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

        public async Task<IReadOnlyList<Product>> GetProductsAsync(int page)
        {
            return await _context.products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductType)
                .OrderBy(x => x.Id)
                .Skip(page*pagesize).Take(pagesize)
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
