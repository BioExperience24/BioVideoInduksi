using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Web.Extensions;
using Microsoft.Extensions.FileProviders;
using CleanArchitecture.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); ;
        });
});

var configuration = builder.Configuration.Get<AppSettings>()
    ?? throw ProgramException.AppsettingNotSetException();

builder.Services.AddSingleton(configuration);
builder.Services.AddValidationService();

var app = await builder.ConfigureServices(configuration).ConfigurePipelineAsync(configuration);


if (args.Length > 0 && args[0] == "seed")
{
    new SeedDatabaseCommand(app.Services);
    return;
}

await app.RunAsync();

// this line for integration test
public partial class Program { }
