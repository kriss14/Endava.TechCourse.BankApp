using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetAllWallets
{
    public class GetAllWalletsHandler : IRequestHandler<GetAllWalletsQuery, IEnumerable<Wallet>>
    {
        private readonly ApplicationDbContext context;

        public GetAllWalletsHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<IEnumerable<Wallet>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
            => await context.Wallets.AsNoTracking().ToListAsync(cancellationToken);
    }
}