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
using Examination_WebApi.Services.CategoryService;
using Examination_WebApi.Models.Products;
using Microsoft.AspNetCore.Authorization;

namespace Examination_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCategoryModel>>> GetCategories()
        {
            return await _categoryService.ReadCategoriesAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCategoryModel>> GetCategory(int id)
        {
            return await _categoryService.ReadCategoryAsync(id);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> PutCategoryEntity(int id, UpdateCategoryModel model)
        {
            return await _categoryService.UpdateCategoryAsync(id, model);
        }




    }
}
