using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly DataContext _context;

        public InventoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<InventoryEntity> CreateProductInventoryAsync(int quantity)
        {
            InventoryEntity entity = new InventoryEntity
            {
                Quantity = quantity
            };

            await _context.Inventories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteProductInventoryAsync(int id)
        {
            InventoryEntity? inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return;
            }

            _context.Remove(inventory);
            await _context.SaveChangesAsync();
        }

        public Task<ActionResult> UpdateProductInventoryAsync(int productId)
        {
            //Använd eventuellt senare när ordrar är ordnat
            throw new NotImplementedException();
        }
    }
}
