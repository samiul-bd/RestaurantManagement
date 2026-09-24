using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.DTOs;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {

            var categories = await _db.Categories
                .Select(C => new CategoryResponseDto
                {
                    Id = C.Id,
                    Name = C.Name
                }).ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategories(CategoryCreateDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
            {
                return BadRequest("Category name cannot be empty.");
            }
            var Category = new Category
            {
                Name = categoryDto.Name
            };
            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();

            var response = new CategoryResponseDto
            {
                Id = Category.Id,
                Name = Category.Name
            };

        }

    }
}
