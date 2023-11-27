using Endava.TechCourse.BankApp.Server.Controllers;

namespace Endava.TechCourse.BankApp.Tests.ControllersTests
{
    public class AccountControllerTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(AccountController).GetConstructors());
    }
}