using Endava.TechCourse.BankApp.Application.Commands.CreateWallet;

namespace Endava.TechCourse.BankApp.Server.Composition
{
    public static class PresentationModule
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Program).Assembly);
                config.RegisterServicesFromAssembly(typeof(CreateWalletCommand).Assembly);
            });

            return services;
        }
    }
}