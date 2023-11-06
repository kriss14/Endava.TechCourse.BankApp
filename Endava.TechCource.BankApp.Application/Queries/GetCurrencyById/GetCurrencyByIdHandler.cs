using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries.GetCurrencyById
{
    public class GetCurrencyByIdHandler : IRequestHandler<GetCurrencyByIdQuery, Currency>
    {
        private readonly ApplicationDbContext context;

        public GetCurrencyByIdHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Currency> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.FindAsync<Currency>(request.Id);
        }
    }
}