using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ZeroSum.App.Extensions;

var builder = WebApplication.CreateBuilder(args).Inject();
builder.Services.AddEndpointsApiExplorer();

var app  = builder.Build();
app.Run();