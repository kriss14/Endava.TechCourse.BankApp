using Endava.TechCourse.BankApp.Infrastructure;
using Endava.TechCourse.BankApp.Server.Composition;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add custom services.
builder.Services.AddInfrastructure(configuration);
builder.Services.AddJwtIdentity(configuration);
builder.Services.AddPresentation();

//
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
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