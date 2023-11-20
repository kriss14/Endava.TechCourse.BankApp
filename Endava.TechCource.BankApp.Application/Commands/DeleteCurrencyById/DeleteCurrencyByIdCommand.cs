using Endava.TechCourse.BankApp.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCource.BankApp.Application.Commands.DeleteCurrencyById
{
    public class DeleteCurrencyByIdCommand : IRequest<CommandStatus>
    {
        public Guid Id { get; set; }
    }
}