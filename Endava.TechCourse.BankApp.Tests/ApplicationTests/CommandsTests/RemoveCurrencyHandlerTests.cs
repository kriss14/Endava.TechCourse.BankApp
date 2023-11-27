using Endava.TechCourse.BankApp.Application.Commands.RemoveCurrency;

namespace Endava.TechCourse.BankApp.Tests.ApplicationTests.CommandsTests
{
    public class RemoveCurrencyHandlerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(RemoveCurrencyHandler).GetConstructors());
    }
}