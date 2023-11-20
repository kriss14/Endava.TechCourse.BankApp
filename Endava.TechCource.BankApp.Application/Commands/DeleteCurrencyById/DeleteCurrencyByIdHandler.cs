using Endava.TechCource.BankApp.Application.Commands.DeleteCurrencyById;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Application.Commands.DeleteCurrencyById
{
    public class DeleteCurrencyByIdHandler : IRequestHandler<DeleteCurrencyByIdCommand, CommandStatus>
    {
        protected readonly ApplicationDbContext context;

        public DeleteCurrencyByIdHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CommandStatus> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
        {
            var currency = context.Currencies.FirstOrDefault(t => t.Id == request.Id);
            if (currency == null)
            {
                return new CommandStatus() { IsSuccessful = false, Error = "There is no currency with this Id" };
            }

            context.Currencies.Remove(currency);
            context.SaveChanges();

            return new CommandStatus { IsSuccessful = true };
        }
    }
}