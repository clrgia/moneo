using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneo.Api.Data;
using Moneo.Api.Dtos.Categories;
using Moneo.Api.Models;

namespace Moneo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MoneoDbContext _context;

        public CategoriesController(MoneoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {

            var categories = await _context.Categories
                .Select(c => new CategoryDto(
                    c.Id,
                    c.Label
                    ))
                .ToListAsync();

            return Ok(categories);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto(
                    c.Id,
                    c.Label))
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var category = new Category
            {
                Label = createCategoryDto.Label
            };

            var categoryLabel = await _context.Categories
                .Where(c => c.Label == category.Label)
                .AnyAsync();

            if (categoryLabel)
            {
                return Conflict("A category with the same name already exists");
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryDto = new CategoryDto(
                category.Id,
                category.Label
            );

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, categoryDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            category.Label = updateCategoryDto.Label;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
