using Endava.TechCourse.BankApp.Application.Commands;
using Endava.TechCourse.BankApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCource.BankApp.Application.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetails>
    {
        public string Username { get; set; }
    }
}