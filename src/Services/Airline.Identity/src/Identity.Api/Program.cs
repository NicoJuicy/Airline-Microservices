using BuildingBlocks.Domain;
using BuildingBlocks.Persistence;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Identity;
using Identity.Extensions;
using Identity.Infrastructure;
using Identity.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var env = builder.Environment;

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(IdentityRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddMediatR();

builder.Services.AddValidatorsFromAssembly(typeof(IdentityRoot).Assembly);
builder.Services.AddCustomProblemDetails();

builder.Services.AddDbContext<IdentityContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddScoped<IDataSeeder, IdentityDataSeeder>();
builder.Services.AddScoped<IMessageBroker, MessageBroker>();
builder.Services.AddScoped<IEventMapper, EventMapper>();
builder.Services.AddScoped<IEventProcessor, EventProcessor>();

builder.Services.AddIdentityServer(env);

builder.Services.AddCustomCap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    app.UseCustomSwagger(provider);
}

app.UseMigrations();
app.UseProblemDetails();
app.UseHttpsRedirection();
app.UseIdentityServer();
app.MapControllers();

app.Run();