using MediatR;

namespace Endava.TechCourse.BankApp.Application.Commands.RemoveCurrency
{
    public class RemoveCurrencyCommand : IRequest<CommandStatus>
    {
        public string Id { get; set; }
    }
}