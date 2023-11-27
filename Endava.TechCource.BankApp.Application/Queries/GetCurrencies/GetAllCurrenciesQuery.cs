using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries.GetCurrencies
{
    public class GetAllCurrenciesQuery : IRequest<IEnumerable<Currency>>
    {
    }
}