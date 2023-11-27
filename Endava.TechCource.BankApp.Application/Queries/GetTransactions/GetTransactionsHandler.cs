using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endava.TechCourse.BankApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetTransactions
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, List<Transaction>>
    {
        private readonly ApplicationDbContext context;
        public GetTransactionsHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = new List<Transaction>();
            
            var wals = context.Wallets.Where(w => w.UserId == request.UserId).AsNoTracking().ToList();
            

            foreach (var w in wals)
            {
                var transactionsforwallet = await context.transactions.Where(t => t.SourceWalletId == w.Id || t.DestinationWalletId == w.Id).ToListAsync();
                transactions.AddRange(transactionsforwallet);
            }
            
            return transactions;
        }
    }
}
