using Endava.TechCourse.BankApp.Domain.Models;
using MediatR;

namespace Endava.TechCourse.BankApp.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public string UserId { get; set; }
    }
}