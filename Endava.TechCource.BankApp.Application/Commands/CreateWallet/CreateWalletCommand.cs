using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.CreateWallet
{
    public class CreateWalletCommand : IRequest<CommandStatus>
    {
        public string Currency { get; set; }
    }
}