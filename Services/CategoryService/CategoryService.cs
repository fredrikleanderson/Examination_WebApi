using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<CategoryEntity> FindOrCreateCategoryAsync(string categoryName)
        {
            CategoryEntity? category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);

            if (category != null)
            {
                return category;
            }

            category = new CategoryEntity
            {
                Name = categoryName
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }



        public async Task<ActionResult<IEnumerable<ReadCategoryModel>>> ReadCategoriesAsync()
        {
            List<ReadCategoryModel> result = new();

            foreach (CategoryEntity category in await _context.Categories.ToListAsync())
            {
                result.Add(new ReadCategoryModel
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return result;
        }

        public async Task<ActionResult<ReadCategoryModel>> ReadCategoryAsync(int id)
        {
            CategoryEntity? category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return new BadRequestResult();
            }

            return new ReadCategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task RemoveEmptyCategoriesAsync(string categoryName)
        {
            CategoryEntity? category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);

            if (category == null)
            {
                return;
            }

            List<ProductEntity> products = await _context.Products.Include(x => x.Category)
                .Where(x => x.Category.Name == categoryName).ToListAsync();

            if (!products.Any())
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult> UpdateCategoryAsync(int id, UpdateCategoryModel model)
        {
            CategoryEntity? category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return new BadRequestResult();
            }

            category.Name = model.Name;
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
