using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using MyEcom.Data;

namespace MyEcom.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            IReadOnlyList<Product> products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = await _repo.GetProductAsync(id);
            return Ok(product);
        }
    }
}
