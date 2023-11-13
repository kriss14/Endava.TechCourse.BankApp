using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.UpdateWallet
{
    public class UpdateWalletCommand : IRequest<CommandStatus>
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public string Type { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid WalletId { get; set; }
    }
}