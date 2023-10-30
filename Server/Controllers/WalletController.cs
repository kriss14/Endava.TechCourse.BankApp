using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistance;
using Endava.TechCourse.BankApp.Shared;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetWallets()
        {
            var walletsDomain = _dbcontext.Wallets.ToList();

            var walletsDTO = new List<GetWalletDTO>(walletsDomain.Count);

            foreach (var walletDomain in walletsDomain)
            {
                var walletDTO = new GetWalletDTO
                {
                    Id = walletDomain.Id,
                    CreateDate = walletDomain.TimeStamp,
                    Type = walletDomain.Type,
                    Amount = walletDomain.Amount
                };

                walletsDTO.Add(walletDTO);
            }

            return Ok(walletsDTO);
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