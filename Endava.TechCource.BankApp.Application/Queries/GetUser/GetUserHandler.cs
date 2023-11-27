using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Endava.TechCourse.BankApp.Application.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly ApplicationDbContext context;

        public GetUserHandler(ApplicationDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            this.context = context;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var guid = Guid.Parse(request.UserId);

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == guid, cancellationToken);

            if (user is null)
                return new();
            else
                return user;
        }
    }
}