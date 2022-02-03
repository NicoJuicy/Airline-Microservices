using BuildingBlocks.Domain;
using BuildingBlocks.Persistence;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using Flight;
using Flight.Extensions;
using Flight.Infrastructure;
using Flight.Infrastructure.Data;
using Flight.Infrastructure.Data.Seed;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(FlightRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddMediatR();

builder.Services.AddValidatorsFromAssembly(typeof(FlightRoot).Assembly);
builder.Services.AddCustomProblemDetails();
builder.Services.AddAutoMapper(typeof(FlightRoot).Assembly);


builder.Services.AddDbContext<FlightDbContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("FlightConnection"));
});

builder.Services.AddCustomCap();

builder.Services.AddScoped<IDataSeeder, FlightDataSeeder>();
builder.Services.AddScoped<IMessageBroker, MessageBroker>();
builder.Services.AddScoped<IEventMapper, EventMapper>();
builder.Services.AddScoped<IEventProcessor, EventProcessor>();

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
app.MapControllers();

app.Run();