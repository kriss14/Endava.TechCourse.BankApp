using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries
{
    public class GetAllCurrenciesHandler : IRequestHandler<GetAllCurrenciesQuery, IEnumerable<Currency>>
    {
        private readonly ApplicationDbContext context;

        public GetAllCurrenciesHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<IEnumerable<Currency>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
            => await context.Currencies.AsNoTracking().ToListAsync(cancellationToken);
    }
}