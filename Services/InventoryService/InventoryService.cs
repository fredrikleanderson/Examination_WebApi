using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task DecrementProductInventoryAsync(int productId, int quantity)
        {
            InventoryEntity? inventory = await _context.Inventories.Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Product.Id == productId);

            if(inventory == null)
            {
                return;
            }

            inventory.Quantity -= quantity;
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return;
        }

        public async Task IncrementProductInventoryAsync(int productId, int quantity)
        {
            InventoryEntity? inventory = await _context.Inventories.Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Product.Id == productId);

            if (inventory == null)
            {
                return;
            }

            inventory.Quantity += quantity;
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return;
        }
    }
}
