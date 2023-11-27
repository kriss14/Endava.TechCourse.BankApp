using Endava.TechCourse.BankApp.Application.Queries.GetAllTransactions;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;

namespace Endava.TechCourse.BankApp.Tests.ApplicationTests.QueriesTests
{
    public class GetAllTransactionsHandlerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(GetAllTransactionsHandler).GetConstructors());

        [Test, ApplicationData]
        public async Task ShouldGetAllTransactions(
            [Frozen] ApplicationDbContext context,
            GetAllTransactionsQuery query,
            GetAllTransactionsHandler handler,
            Transaction transaction)
        {
            context.Add(transaction);
            context.SaveChanges();

            var result = await handler.Handle(query, default);

            using (new AssertionScope())
            {
                result.Count().Should().Be(1);
                result.Should().ContainEquivalentOf(transaction);
            }
        }
    }
}