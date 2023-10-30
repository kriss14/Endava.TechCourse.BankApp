using AutoFixture.NUnit3;

namespace Endava.TestCourse.BankApp.Tests.Common
{
    public class ApplicationDataAttribute : InlineAutoDataAttribute
    {
        public ApplicationDataAttribute(params object[] arguments)
            : base(() => new Fixture()
                .Customize(new CompositeCustomization(
                    new AutoNSubstituteCustomization(),
                    new SqliteCustomization
                    {
                        AutoOpenConnection = true,
                        OmitDbSets = true,
                        OnCreate = OnCreateAction.EnsureCreated
                    })),
                    arguments)
        {
        }
    }
}