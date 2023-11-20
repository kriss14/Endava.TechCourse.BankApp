using Endava.TechCourse.BankApp.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCource.BankApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<CommandStatus>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}