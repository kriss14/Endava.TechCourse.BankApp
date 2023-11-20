using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencies;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencyById;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CurrencyController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CurrencyDto>> GetCurrencyes()
        {
            var currencyesRes = new List<CurrencyDto>();

            var query = new GetCurrenciesQuery();
            var result = await mediator.Send(query);
            foreach (var c in result)
            {
                currencyesRes.Add(new CurrencyDto
                {
                    CurrencyCode = c.CurrencyCode,
                    ChangeRate = c.ChangeRate,
                    Name = c.Name,
                    Id = c.Id.ToString(),
                    CanBeRemoved = true
                }
                );
            }
            return currencyesRes;
        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] CurrencyDto currencyDTO)
        {
            var command = new AddWalletCommand
            {
                Name = currencyDTO.Name,
                CurrencyCode = currencyDTO.CurrencyCode,
                ChangeRate = currencyDTO.ChangeRate
            };
            var result = await mediator.Send(command);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Currency> GetCurrencyById(Guid id)
        {
            GetCurrencyByIdQuery request = new GetCurrencyByIdQuery
            {
                Id = id
            };
            return await mediator.Send(request);
        }
    }
}