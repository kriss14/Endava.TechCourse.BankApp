using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public WalletsController(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        [HttpGet]
        public async Task<List<WalletDto>> GetWallets()
        {
            var wallets = await context.Wallets.Include(x => x.Currency).AsNoTracking().ToListAsync();
            var dtos = Mapper.Map(wallets).ToList();

            return dtos;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromBody] WalletDto walletDto)
        {
            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == walletDto.Currency);

            if (currency is null)
                return BadRequest("Valuta pentru acest portofel nu exista");

            var newWallet = new Wallet()
            {
                Type = walletDto.Type,
                Amount = new Random().Next(50, 300),
                Currency = currency
            };

            await context.Wallets.AddAsync(newWallet);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}