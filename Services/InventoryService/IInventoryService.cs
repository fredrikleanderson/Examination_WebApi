using Examination_WebApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.InventoryService
{
    public interface IInventoryService
    {
        Task<ActionResult> UpdateProductInventoryAsync(int productId);
        Task<InventoryEntity> CreateProductInventoryAsync(int quantity);
        Task DeleteProductInventoryAsync(int id);
    }
}
