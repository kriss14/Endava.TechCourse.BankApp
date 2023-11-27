using Endava.TechCourse.BankApp.Application.Commands;
using Endava.TechCourse.BankApp.Application.Commands.CreateWallet;
using Endava.TechCourse.BankApp.Server.Controllers;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using NSubstitute;

namespace Endava.TechCourse.BankApp.Tests.ControllersTests
{
    public class WalletControllerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(WalletController).GetConstructors());

        [Test, ApplicationData]
        public async Task ShouldSendCreateWalletCommand(
            [Frozen] IMediator mediator,
            [Greedy] WalletController controller,
            WalletDto walletDto)
        {
            mediator.Send(Arg.Any<CreateWalletCommand>(), default).Returns(new CommandStatus());

            await controller.CreateWallet(walletDto);

            await mediator.Received(1).Send(Arg.Any<CreateWalletCommand>(), default);
        }
    }
}