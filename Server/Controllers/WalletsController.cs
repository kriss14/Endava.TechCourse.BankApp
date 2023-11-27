using Endava.TechCourse.BankApp.Application.Commands.CreateWallet;
using Endava.TechCourse.BankApp.Application.Commands.DeleteWalletById;
using Endava.TechCourse.BankApp.Application.Commands.TransferFounds;
using Endava.TechCourse.BankApp.Application.Commands.UpdateWallet;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencyById;
using Endava.TechCourse.BankApp.Application.Queries.GetTransactions;
using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Application.Queries.GetWalletsById;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Server.Common.JwtToken;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public WalletController(ApplicationDbContext dbContext, IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(dbContext);
            ArgumentNullException.ThrowIfNull(mediator);

            _context = dbContext;
            this._mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletDto createWalletDto)
        {
            var query = new CreateWalletCommand
            {
                Type = createWalletDto.Type,
                Amount = createWalletDto.Amount,
                CurrencyCode = createWalletDto.CurrencyCode,
                UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(u => u.Type == Constants.UserIdClaimName).Value)
            };

            Debug.WriteLine("here");

            await _mediator.Send(query);
            return Ok();
        }

        [HttpGet]
        [Route("getwallets")]
        [Authorize(Roles = "User, Admin")]
        public async Task<List<GetWalletDto>> GetWallets()
        {
            List<GetWalletDto> walletsRes = new List<GetWalletDto>();
            var query = new GetWalletsQuery
            {
                UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == Constants.UserIdClaimName).Value)
            };
            var wallets = await _mediator.Send(query);

            foreach (Wallet w in wallets)
            {
                var getCurrencyForDTO = new GetCurrencyByIdQuery()
                {
                    Id = w.CurrencyId
                };
                var currency = await _mediator.Send(getCurrencyForDTO);

                walletsRes.Add(new GetWalletDto
                {
                    CurrencyId = currency.Id,
                    WalletId = w.Id,
                    Amount = w.Amount,
                    CurrencyCode = currency.CurrencyCode,
                    ChangeRate = currency.ChangeRate,
                    CurrencyName = currency.Name,
                    Type = w.Type
                });
            }
            return walletsRes;
        }

        [HttpGet("{id}")]
        [Route("getWalletById")]
        public async Task<GetWalletDto> GetWalletById(Guid id)
        {
            GetWalletByIdQuery query = new GetWalletByIdQuery
            {
                Id = id
            };
            var w = await _mediator.Send(query);

            return new GetWalletDto
            {
                WalletId = w.Id,
                Amount = w.Amount,
                Type = w.Type
            };
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> DeleteWalletById(Guid id)
        {
            DeleteWalletByIdCommand request = new DeleteWalletByIdCommand { Id = id };
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateWalletById([FromBody] UpdateWalletDto walletDto)
        {
            var currequest = new GetCurrencyByIdQuery()
            {
                Id = walletDto.CurrencyId
            };
            var resCur = await _mediator.Send(currequest);

            var request = new UpdateWalletCommand()
            {
                Amount = walletDto.Amount,
                Currency = resCur,
                Type = walletDto.Type,
                CurrencyId = walletDto.CurrencyId,
                WalletId = walletDto.WalletId
            };

            var res = await _mediator.Send(request);
            return res.IsSuccessful ? Ok() : BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        [Route("transfer")]
        public async Task<IActionResult> TranserFounds([FromBody] TransactionDto transaction)
        {
            var query = new TransferFoundsCommand()
            {
                Amount = transaction.Amount,
                DestinationWalletId = transaction.DestinationWalletId,
                Description = transaction.Description,
                SourceWalletId = transaction.SourceWalletId,
                CurrencyId = transaction.CurrencyId,
                Date = DateTime.Now
            };
            var res = await _mediator.Send(query);


            return res != null && res.IsSuccessful ? Ok() : BadRequest();
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        [Route("gettransactions")]
        public async Task<IActionResult> GetTransactions()
        {
            if (HttpContext != null)
            {
                var query = new GetTransactionsQuery()
                {
                    UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == Constants.UserIdClaimName).Value),
                };
                var res = await _mediator.Send(query);
                return Ok(res);

            }

            return BadRequest();
        }
    }
}