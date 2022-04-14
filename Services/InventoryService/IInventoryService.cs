using Examination_WebApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.InventoryService
{
    public interface IInventoryService
    {
        Task<ActionResult> DecrementProductInventoryAsync(int productId, int quantity);
        Task<InventoryEntity> CreateProductInventoryAsync(int quantity);
        Task DeleteProductInventoryAsync(int id);
    }
}
