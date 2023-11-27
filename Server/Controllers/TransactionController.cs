using Endava.TechCourse.BankApp.Application.Commands.TransferFounds;
using Endava.TechCourse.BankApp.Application.Queries.GetAllTransactions;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IEnumerable<TransactionDto>> GetAllTransactions()
        {
            var transactions = await mediator.Send(new GetAllTransactionsQuery());

            return Mapper.Map(transactions);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> TransferFounds([FromBody] TransactionDto dto)
        {
            var transaferFoundsCommand = new TransferFoundsCommand()
            {
                SourceWalletId = dto.SourceWalletId,
                DestinationWalletId = dto.DestinationWalletId,
                Amount = dto.Amount,
                Currency = dto.Currency
            };

            var result = await mediator.Send(transaferFoundsCommand);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }
    }
}