using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.SaveCurrency
{
    public class SaveCurrencyCommand : IRequest<CommandStatus>
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ChangeRate { get; set; }
    }
}