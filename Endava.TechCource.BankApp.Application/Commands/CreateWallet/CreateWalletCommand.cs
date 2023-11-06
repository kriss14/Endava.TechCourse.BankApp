using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.CreateWallet
{
    public class CreateWalletCommand : IRequest<CommandStatus>
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Type { get; set; }
    }
}