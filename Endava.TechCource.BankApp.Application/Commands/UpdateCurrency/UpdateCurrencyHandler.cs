using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
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
            var currency = await context.Currencies.FindAsync(request.CurrencyId, cancellationToken);

            if (currency == null)
            {
                return new CommandStatus() { IsSuccessful = false, Error = "This Currency does not exists" };
            }

            currency.CurrencyCode = request.CurrencyCode;
            currency.ChangeRate = request.ChangeRate;
            currency.Name = request.Name;

            context.Currencies.Update(currency);
            context.SaveChanges();

            return new CommandStatus() { IsSuccessful = true };
        }
    }
}