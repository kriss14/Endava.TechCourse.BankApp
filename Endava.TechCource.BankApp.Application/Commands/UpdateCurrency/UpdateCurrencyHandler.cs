using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.UpdateCurrency
{
    public class UpdateCurrencyHandler : IRequestHandler<UpdateCurrencyCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public UpdateCurrencyHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CommandStatus> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
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