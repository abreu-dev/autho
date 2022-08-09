using Autho.Api.Scope;
using Autho.Api.Scope.Extensions;
using Autho.Api.Scope.Middlewares;
using Autho.Infra.Data.Seed;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddAuthoAuthentication(builder.Configuration);
builder.Services.AddAuthoControllers();
builder.Services.AddAuthoSwagger();
builder.Services.AddAuthoDbContext(builder.Configuration);

ApiBootstrapper.Load(builder.Services);

// ConfigureApp
var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();

app.UseAuthoAuthentication();
app.UseAuthoSwagger();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<GlobalizationMiddleware>();

app.Services.SeedData();

app.Run();
