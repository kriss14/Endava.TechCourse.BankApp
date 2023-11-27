using Endava.TechCourse.BankApp.Application.Commands.AddCurrency;
using Endava.TechCourse.BankApp.Application.Commands.CreateWallet;
using Endava.TechCourse.BankApp.Application.Queries.GetWallets;
using Endava.TechCourse.BankApp.Infrastructure;
using Endava.TechCourse.BankApp.Server.Composition;

namespace Endava.TechCourse.BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddInfrastructure(configuration);
            builder.Services.AddJwtIdentity(configuration);
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
                config.RegisterServicesFromAssemblies(typeof(GetWalletsQuery).Assembly);
                config.RegisterServicesFromAssemblies(typeof(CreateWalletCommand).Assembly);
                config.RegisterServicesFromAssemblies(typeof(AddCurrencyCommand).Assembly);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}