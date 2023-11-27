using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.TransferFounds
{
    public class TransferFoundsCommand : IRequest<CommandStatus>
    {
        public string SourceWalletId { get; set; }
        public string DestinationWalletId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}