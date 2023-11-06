﻿using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetCurrencies
{
    public class GetCurrenciesHandler : IRequestHandler<GetCurrenciesQuery, List<Currency>>
    {
        private readonly ApplicationDbContext context;

        public GetCurrenciesHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Currency>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var currencyes = await context.Currencies.AsNoTracking().ToListAsync(cancellationToken);

            return currencyes;
        }
    }
}