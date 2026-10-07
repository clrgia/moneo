using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneo.Api.Data;
using Moneo.Api.Dtos.Operations;
using Moneo.Api.Models;

namespace Moneo.Api.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly MoneoDbContext _context;

        public OperationsController(MoneoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDto>>> GetOperations(Guid accountId)
        {
            if (await _context.Accounts.AnyAsync(x => x.Id == accountId) == false)
            {
                return NotFound();
            }

            var operations = await _context.Operations
                .Where(x => x.AccountId == accountId)
                .OrderByDescending(o => o.Date)
                .Select(o => new OperationDto(
                    o.Id,
                    o.Label,
                    o.Amount,
                    o.Date,
                    o.AccountId,
                    o.CategoryId,
                    o.Category != null ? o.Category.Label : null))
                .ToListAsync();

            return Ok(operations);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OperationDto>> GetOperation(Guid accountId, Guid id)
        {
            var operation = await _context.Operations
                .Where(x => x.AccountId == accountId && x.Id == id)
                .Select(o => new OperationDto(
                    o.Id,
                    o.Label,
                    o.Amount,
                    o.Date,
                    o.AccountId,
                    o.CategoryId,
                    o.Category != null ? o.Category.Label : null))
                .FirstOrDefaultAsync();

            return operation == null ? NotFound() : Ok(operation);
        }

        [HttpPost]
        public async Task<ActionResult<OperationDto>> CreateOperation(Guid accountId, CreateOperationDto createOperationDto)
        {
            if (!await _context.Accounts.AnyAsync(a => a.Id == accountId))
            {
                return NotFound();
            }

            Category? category = null;

            if (createOperationDto.CategoryId.HasValue)
            {
                category = await _context.Categories.FindAsync(createOperationDto.CategoryId.Value);

                if (category == null)
                {
                    return BadRequest("La catégorie indiquée n'existe pas.");
                }
            }

            var operation = new Operation
            {
                Label = createOperationDto.Label,
                Amount = createOperationDto.Amount.Value,
                Date = createOperationDto.Date.Value,
                AccountId = accountId,
                CategoryId = category?.Id
            };

            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();

            var operationDto = new OperationDto(
                operation.Id,
                operation.Label,
                operation.Amount,
                operation.Date,
                operation.AccountId,
                operation.CategoryId,
                category?.Label);

            return CreatedAtAction(
                nameof(GetOperation),
                new { accountId, id = operation.Id },
                operationDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateOperation(Guid accountId, Guid id, UpdateOperationDto updateOperationDto)
        {

            var operation = await _context.Operations
                .Where(x => x.AccountId == accountId && x.Id == id)
                .FirstOrDefaultAsync();

            if (operation == null)
            {
                return NotFound();
            }

            Category? category = null;

            if (updateOperationDto.CategoryId.HasValue)
            {
                category = await _context.Categories.FindAsync(updateOperationDto.CategoryId.Value);

                if (category == null)
                {
                    return BadRequest("La catégorie indiquée n'existe pas.");
                }
            }

            operation.Label = updateOperationDto.Label;
            operation.Amount = updateOperationDto.Amount.Value;
            operation.Date = updateOperationDto.Date.Value;
            operation.CategoryId = category?.Id;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOperation(Guid accountId, Guid id)
        {
            var operation = await _context.Operations
                .Where(x => x.AccountId == accountId && x.Id == id)
                .FirstOrDefaultAsync();

            if (operation == null)
            {
                return NotFound();
            }

            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
