using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries.GetAllTransactions
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<Transaction>>
    {
    }
}