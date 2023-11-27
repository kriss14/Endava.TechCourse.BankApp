using Endava.TechCourse.BankApp.Application.Queries.GetUserDetails;

namespace Endava.TechCourse.BankApp.Tests.ApplicationTests.QueriesTests
{
    public class GetUserHandlerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(GetUserDetailsHandler).GetConstructors());
    }
}