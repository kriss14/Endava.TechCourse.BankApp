using Endava.TechCourse.BankApp.Application.Commands.CreateWallet;
using Endava.TechCourse.BankApp.Domain.Models;
using Endava.TechCourse.BankApp.Infrastructure.Persistence;

namespace Endava.TechCourse.BankApp.Tests.ApplicationTests.CommandsTests
{
    public class CreateWalletTests
    {
        [Test, ApplicationData]
        public void CanCreateInstance(GuardClauseAssertion assertion)
            => assertion.Verify(typeof(CreateWalletHandler).GetConstructors());

        [Test, ApplicationData]
        public async Task ShouldReturnRequestFailedIfCurrencyIsNull(
            CreateWalletCommand command,
            CreateWalletHandler handler)
        {
            var result = await handler.Handle(command, default);

            using (new AssertionScope())
            {
                result.IsSuccessful = false;
                result.Error = "Valuta pentru acest portofel nu exista";
            }
        }

        [Test, ApplicationData]
        public async Task ShouldCreateWallet(
            [Frozen] ApplicationDbContext context,
            CreateWalletCommand command,
            CreateWalletHandler handler,
            Currency currency)
        {
            currency.CurrencyCode = command.Currency;

            context.Add(currency);
            context.SaveChanges();

            var result = await handler.Handle(command, default);

            using (new AssertionScope())
            {
                context.Wallets.Should().ContainSingle();
                result.IsSuccessful.Should().BeTrue();
            }
        }
    }
}