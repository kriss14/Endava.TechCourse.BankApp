using Endava.TechCourse.BankApp.Application.Queries;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;

namespace Endava.TechCourse.BankApp.Tests.ApplicationTests.QueriesTests
{
    public class GetAllCurrenciesHandlerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(GetAllCurrenciesHandler).GetConstructors());

        [Test, ApplicationData]
        public async Task ShouldGetAllCurrencies(
            [Frozen] ApplicationDbContext context,
            GetAllCurrenciesQuery query,
            GetAllCurrenciesHandler handler,
            Currency currency)
        {
            context.Add(currency);
            context.SaveChanges();

            var result = await handler.Handle(query, default);

            using (new AssertionScope())
            {
                result.Count().Should().Be(1);
                result.Should().ContainEquivalentOf(currency);
            }
        }
    }
}