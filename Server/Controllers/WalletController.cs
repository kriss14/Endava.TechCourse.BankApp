using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistance;
using Endava.TechCourse.BankApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public WalletController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateWallet([FromBody] CreateWalletDTO createWalletDTO)
        {
            var wallet = new Wallet
            {
                Type = createWalletDTO.Type,
                Amount = createWalletDTO.Amount,
                Currency = new Currency
                {
                    Name = "Euro",
                    CurrencyCode = "EUR",
                    ChangeRate = 20
                }
            };
            _dbcontext.Wallets.Add(wallet);
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("getwallets")]
        public async Task<List<WalletDTO>> GetWallets()
        {
            var wallets = await _dbcontext.Wallets.Include(x => x.Currency).ToListAsync();

            var dtos = new List<WalletDTO>();

            foreach (var wallet in wallets)
            {
                var dto = new WalletDTO()
                {
                    Id = wallet.Id,
                    Currency = wallet.Currency,
                    Type = wallet.Type,
                    Amount = wallet.Amount,
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        [HttpGet("{type}")]
        public ActionResult GetWallet(string type)
        {
            var walletsDomain = _dbcontext.Wallets.ToList();
            var wallet = _dbcontext.Wallets.FirstOrDefault(item => item.Type == type);

            return Ok(wallet);
        }
    }
}