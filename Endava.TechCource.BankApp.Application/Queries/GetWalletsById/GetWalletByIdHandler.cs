using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWalletsById
{
    public class GetWalletByIdHandler : IRequestHandler<GetWalletByIdQuery, Wallet>
    {
        private readonly ApplicationDbContext context;

        public GetWalletByIdHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Wallet> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var wallet = await context.Wallets.Include(c => c.Currency).FirstOrDefaultAsync(w => w.Id == request.Id);
            return wallet;
        }
    }
}