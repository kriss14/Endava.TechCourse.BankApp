﻿using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetWallets
{
    public class GetWalletsHandler : IRequestHandler<GetWalletsQuery, List<Wallet>>
    {
        private readonly ApplicationDbContext context;

        public GetWalletsHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Wallet>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
        {
            var wallets = await context.Wallets.AsNoTracking()
                .Where(w => w.UserId == request.UserId).ToListAsync();

            return wallets;
        }
    }
}