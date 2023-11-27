using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.SaveCurrency
{
    public class SavecurrencyHandler : IRequestHandler<SaveCurrencyCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public SavecurrencyHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(SaveCurrencyCommand request, CancellationToken cancellationToken)
        {
            if (await context.Currencies.AnyAsync(x => x.Name == request.Name, default))
                return CommandStatus.Failed("O valuta cu aceasta denumire deja exista.");

            if (await context.Currencies.AnyAsync(x => x.CurrencyCode == request.CurrencyCode, default))
                return CommandStatus.Failed("O valuta cu acest cod deja exista.");

            var newCurrency = new Currency()
            {
                Name = request.Name,
                CurrencyCode = request.CurrencyCode,
                ChangeRate = request.ChangeRate
            };

            if (!await context.Currencies.AnyAsync(cancellationToken))
                newCurrency.CanBeRemoved = false;

            await context.Currencies.AddAsync(newCurrency, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CommandStatus();
        }
    }
}