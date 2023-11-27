using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries
{
    public class GetAllCurrenciesQuery : IRequest<IEnumerable<Currency>>
    {
    }
}