#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.ProductService.Services;
using Examination_WebApi.Models.Products;
using Microsoft.AspNetCore.Authorization;

namespace Examination_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadProductModel>>> GetProducts()
        {
            return await _productService.ReadProductsAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProductModel>> GetProductEntity(int id)
        {
            return await _productService.ReadProductAsync(id);
        }

        // PUT: api/Products/5
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutProductEntity(int id, UpdateProductModel model)
        {
            return await _productService.UpdateProductAsync(id, model);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ReadProductModel>> PostProductEntity(CreateProductModel productEntity)
        {
            return await _productService.CreateProductAsync(productEntity);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            return await _productService.DeleteProductAsync(id);
        }

        //private bool ProductEntityExists(int id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}
    }
}
