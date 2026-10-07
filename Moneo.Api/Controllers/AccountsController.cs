using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moneo.Api.Data;
using Moneo.Api.Dtos.Accounts;
using Moneo.Api.Models;

namespace Moneo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MoneoDbContext _context;

        public AccountsController(MoneoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {

            var accounts = await _context.Accounts
                .Select(a => new AccountDto(
                    a.Id,
                    a.Name,
                    a.Type,
                    a.InitialBalance,
                    a.CreatedAt,
                    a.InitialBalance + a.Operations.Sum(o => o.Amount)))
                .ToListAsync();

            return Ok(accounts);
        }


        [HttpGet("{id:guid}")] 
        public async Task<ActionResult<AccountDto>> GetAccount(Guid id)
        {
            var account = await _context.Accounts
                .Where(a => a.Id == id)
                .Select(a => new AccountDto(
                    a.Id,
                    a.Name,
                    a.Type,
                    a.InitialBalance,
                    a.CreatedAt,
                    a.InitialBalance + a.Operations.Sum(o => o.Amount)))
                .FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccount(CreateAccountDto createAccountDto)
        {
            var account = new Account
            {
                Name = createAccountDto.Name,
                Type = createAccountDto.Type,
                InitialBalance = createAccountDto.InitialBalance
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            var accountDto = new AccountDto(
                account.Id,
                account.Name,
                account.Type,
                account.InitialBalance,
                account.CreatedAt,
                account.InitialBalance
            );

            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, accountDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAccount(Guid id, UpdateAccountDto updateAccountDto)
        {
            var account = await _context.Accounts
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound();
            }

            account.Name = updateAccountDto.Name;
            account.Type = updateAccountDto.Type;
            account.InitialBalance = updateAccountDto.InitialBalance;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var account = await _context.Accounts
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
