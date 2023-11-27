using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Queries.GetTransactions
{
    public class GetTransactionsQuery : IRequest<List<Transaction>>
    {
        public Guid UserId { get; set; }
    }
}
