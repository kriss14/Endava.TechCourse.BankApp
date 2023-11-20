using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.UpdateWallet
{
    public class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;

        public UpdateWalletHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CommandStatus> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            Wallet wallet = await context.Wallets.FindAsync(request.WalletId);
            if (wallet == null)
            {
                return new CommandStatus() { IsSuccessful = false, Error = "There is no wallet with this " };
            }

            wallet.Amount = request.Amount;
            wallet.Currency = request.Currency;
            wallet.CurrencyId = request.CurrencyId;
            wallet.Type = request.Type;

            var res = context.Wallets.Update(wallet);
            context.SaveChanges();

            return new CommandStatus();
        }
    }
}