using Endava.TechCourse.BankApp.Application.Commands;
using Endava.TechCourse.BankApp.Application.Commands.SaveCurrency;
using Endava.TechCourse.BankApp.Server.Controllers;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using NSubstitute;

namespace Endava.TechCourse.BankApp.Tests.ControllersTests
{
    public class CurrencyControllerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(CurrencyController).GetConstructors());

        [Test, ApplicationData]
        public async Task ShouldSaveCurrency(
            [Frozen] IMediator mediator,
            [Greedy] CurrencyController controller,
            CurrencyDto dto)
        {
            mediator.Send(Arg.Any<SaveCurrencyCommand>()).Returns(new CommandStatus());

            await controller.SaveCurrency(dto);

            await mediator.Received(1).Send(Arg.Is<SaveCurrencyCommand>(x
                => x.Name == dto.Name
                && x.ChangeRate == dto.ChangeRate
                && x.CurrencyCode == dto.CurrencyCode));
        }
    }
}