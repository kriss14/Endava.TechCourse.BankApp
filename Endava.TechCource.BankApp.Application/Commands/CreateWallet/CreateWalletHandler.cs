using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.CreateWallet
{
    public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public CreateWalletHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == request.Currency, cancellationToken);

            if (currency is null)
                return CommandStatus.Failed("Valuta pentru acest portofel nu exista");

            var newWallet = new Wallet()
            {
                Currency = request.Currency,
                ChangeRate = currency.ChangeRate
            };

            await context.Wallets.AddAsync(newWallet, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CommandStatus();
        }
    }
}