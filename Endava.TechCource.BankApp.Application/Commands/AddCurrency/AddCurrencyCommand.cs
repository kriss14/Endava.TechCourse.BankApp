using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.AddCurrency
{
    public class AddWalletCommand : IRequest<CommandStatus>
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ChangeRate { get; set; }
    }
}