using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.RemoveCurrency
{
    public class RemoveCurrencyHandler : IRequestHandler<RemoveCurrencyCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public RemoveCurrencyHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(RemoveCurrencyCommand request, CancellationToken cancellationToken)
        {
            var idStatus = Guid.TryParse(request.Id, out var currencyId);

            if (idStatus is false)
                return CommandStatus.Failed("Formtul id-ului este incorect");

            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.Id == currencyId, cancellationToken);

            if (currency is null)
                return CommandStatus.Failed($"O valuta cu id-ul {currencyId} nu a putut fi gasita.");

            context.Currencies.Remove(currency);
            await context.SaveChangesAsync(cancellationToken);

            return new CommandStatus();
        }
    }
}