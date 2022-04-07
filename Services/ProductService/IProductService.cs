using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.ProductService.Services
{
    public interface IProductService
    {
        Task<ActionResult<ReadProductModel>> CreateProductAsync(CreateProductModel model);
        Task<ActionResult<IEnumerable<ReadProductModel>>> ReadProductsAsync();
        Task<ActionResult<ReadProductModel>> ReadProductAsync(int id);
        Task<ActionResult> UpdateProductAsync(int id, UpdateProductModel model);
        Task<ActionResult> DeleteProductAsync(int id);
    }
}
