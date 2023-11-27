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
            this.context = context;
        }

        public async Task<CommandStatus> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            Currency currency = await context.Currencies.FirstOrDefaultAsync(c => c.CurrencyCode == request.CurrencyCode);
            if (currency == null)
            {
                return new CommandStatus { IsSuccessful = false, Error = "Currency does not exists" };
            }

            var wallet = new Wallet
            {
                UserId = request.UserId,
                Type = request.Type,
                Amount = request.Amount,
                Currency = new Currency
                {
                    ChangeRate = currency.ChangeRate,
                    CurrencyCode = currency.CurrencyCode,
                    Name = currency.Name
                }
            };

            await context.Wallets.AddAsync(wallet);
            context.SaveChanges();
            return new CommandStatus();
        }
    }
}