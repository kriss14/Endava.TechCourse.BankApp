using Endava.TechCourse.BankApp.Application.Commands;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.TransferFounds
{
    public class TransferFoundsHandler : IRequestHandler<TransferFoundsCommand, CommandStatus>
    {
        private readonly ApplicationDbContext context;
        public TransferFoundsHandler(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public async Task<CommandStatus> Handle(TransferFoundsCommand request, CancellationToken cancellationToken)
        {
            if(request.Amount < 0) 
            {
                return new CommandStatus(){ IsSuccessful = false, Error = "Amount is invalid" };
            }
            if(request == null) 
            {
                return new CommandStatus() { IsSuccessful = false };
            }

            Wallet sender = await context.Wallets.FirstOrDefaultAsync(w => w.Id == request.SourceWalletId);
            Wallet accepter = await context.Wallets.FirstOrDefaultAsync(w => w.Id == request.DestinationWalletId);

            Currency senderCurrency = await context.Currencies.FirstOrDefaultAsync(c => c.Id == sender.CurrencyId);
            Currency accepterCurrency = await context.Currencies.FirstOrDefaultAsync(c => c.Id == accepter.CurrencyId);
            

            var transferCurrency = await context.Currencies.FirstOrDefaultAsync(c => c.Id == request.CurrencyId);

            if (senderCurrency == transferCurrency)
            {
                sender.Amount -= request.Amount;
            }
            else
            {
                sender.Amount = sender.Amount - (request.Amount * transferCurrency.ChangeRate);
            }

            if(accepterCurrency == transferCurrency) 
            {
                accepter.Amount -= request.Amount;
            }
            else
            {
                accepter.Amount = accepter.Amount - (request.Amount * transferCurrency.ChangeRate);
            }
                        
            context.Wallets.Update(sender);
            context.Wallets.Update(accepter);
            
            var transaction = new Transaction()
            {
                Currency = transferCurrency,
                Amount = request.Amount,
                ChangeRate = transferCurrency.ChangeRate,
                Description = request.Description, 
                TransactionTime = DateTime.Now,
                SourceWalletId = sender.Id,
                DestinationWalletId = accepter.Id,
            };
            
            context.transactions.Add(transaction);
            context.SaveChanges();

            return new CommandStatus() { IsSuccessful = true};
        }
    }
}
