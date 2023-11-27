using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Commands.TransferFounds
{
    public class TransferFoundsHandler : IRequestHandler<TransferFoundsCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public TransferFoundsHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<CommandStatus> Handle(TransferFoundsCommand request, CancellationToken cancellationToken)
        {
            var sourceIdStatus = Guid.TryParse(request.SourceWalletId, out var sourceWalletId);

            if (sourceIdStatus is false)
                return CommandStatus.Failed("Id ul portofelului sursa este incorect.");

            var sourceWallet = await context.Wallets.FirstOrDefaultAsync(x => x.Id == sourceWalletId, cancellationToken);

            if (sourceWallet is null)
                return CommandStatus.Failed("Portofelul sursa nu exista.");

            var destinationIdStatus = Guid.TryParse(request.DestinationWalletId, out var destinationWalletId);

            if (destinationIdStatus is false)
                return CommandStatus.Failed("Id ul portofelului destinatie este incorect");

            var destinationWallet = await context.Wallets.FirstOrDefaultAsync(x => x.Id == destinationWalletId, cancellationToken);

            if (destinationWallet is null)
                return CommandStatus.Failed("Portofelul destinatie nu exista.");

            var currency = await context.Currencies.FirstOrDefaultAsync(x => x.CurrencyCode == request.Currency, cancellationToken);

            if (currency is null || sourceWallet.Currency != currency.CurrencyCode)
                return CommandStatus.Failed("Valuta tranzactiei nu este valida");

            sourceWallet.Amount -= request.Amount;
            destinationWallet.Amount += request.Amount * sourceWallet.ChangeRate / destinationWallet.ChangeRate;

            var newTransaction = new Transaction()
            {
                SourceWalletId = sourceWallet.Id,
                DestinationWalletId = destinationWallet.Id,
                Amount = request.Amount,
                Currency = currency.CurrencyCode,
                TransactionTime = DateTime.Now
            };

            await context.Transactions.AddAsync(newTransaction, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CommandStatus();
        }
    }
}