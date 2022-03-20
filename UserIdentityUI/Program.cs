
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using UserIdentityUI.DependencyResolvers.AutofacBusinessModule;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutoFacBusinessModule(config));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
