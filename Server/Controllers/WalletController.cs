using Endava.TechCourse.BankApp.Application.Commands.CreateWallet;
using Endava.TechCourse.BankApp.Application.Queries.GetAllWallets;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator mediator;

        public WalletController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "User")]
        public async Task<IEnumerable<WalletDto>> GetAllWallets()
        {
            var wallets = await mediator.Send(new GetAllWalletsQuery());

            return Mapper.Map(wallets);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IEnumerable<WalletDto>> GetAllWalletsForUser()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == Constants.UserIdClaimName);

            if (userIdClaim is null)
                return new List<WalletDto>();

            var userId = userIdClaim.Value;

            var wallets = await mediator.Send(new GetAllWalletsQuery());

            return Mapper.Map(wallets);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateWallet([FromBody] WalletDto dto)
        {
            var createWalletCommand = new CreateWalletCommand()
            {
                Currency = dto.Currency
            };

            var result = await mediator.Send(createWalletCommand);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }
    }
}