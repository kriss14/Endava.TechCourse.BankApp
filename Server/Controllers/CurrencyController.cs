using Endava.TechCource.BankApp.Application.Commands.DeleteCurrencyById;
using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Application.Commands.UpdateCurrency;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencies;
using Endava.TechCourse.BankApp.Application.Queries.GetCurrencyById;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Server.Common;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,User")]
        public async Task<IEnumerable<CurrencyDto>> GetAllCurrencies()
        {
            var currencies = await mediator.Send(new GetAllCurrenciesQuery());

            return Mapper.Map(currencies);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveCurrency([FromBody] CurrencyDto dto)
        {
            var saveCurrencyCommand = new UpdateCurrencyCommand()
            {
                Name = dto.Name,
                CurrencyCode = dto.CurrencyCode,
                ChangeRate = dto.ChangeRate
            };

            var result = await mediator.Send(saveCurrencyCommand);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }

        [HttpPost]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveCurrency([FromBody] Guid id)
        {
            var removeCurrencyCommnd = new DeleteCurrencyByIdCommand()
            {
                Id = id
            };

            var result = await mediator.Send(removeCurrencyCommnd);

            return result.IsSuccessful ? Ok() : BadRequest(result.Error);
        }
    }
}