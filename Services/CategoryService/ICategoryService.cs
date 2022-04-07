using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<CategoryEntity> FindOrCreateCategoryAsync(string categoryName);
        Task<ActionResult<IEnumerable<ReadCategoryModel>>> ReadCategoriesAsync();
        Task<ActionResult<ReadCategoryModel>> ReadCategoryAsync(int id);
        Task<ActionResult> UpdateCategoryAsync(int id, UpdateCategoryModel model);
        Task RemoveEmptyCategoriesAsync(string categoryName);
    }
}
