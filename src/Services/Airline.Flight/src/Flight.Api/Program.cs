using System.Text.Encodings.Web;
using System.Text.Unicode;
using BuildingBlocks.Domain;
using BuildingBlocks.Persistence;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Flight;
using Flight.Extensions;
using Flight.Infrastructure;
using Flight.Infrastructure.Data;
using Flight.Infrastructure.Data.Seed;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

// Sample subscriber
builder.Services.AddTransient<ICapSubscribe,TestSubscriber>();

builder.Services.AddCap(x =>
{
    x.UseEntityFramework<FlightDbContext>();

    x.UseSqlServer(configuration.GetConnectionString("FlightConnection"));

    x.UseRabbitMQ(r =>
    {
        r.HostName = configuration["RabbitMq:HostName"];
        r.ExchangeName = configuration["RabbitMq:ExchangeName"];
    });

    x.FailedRetryCount = 5;
    x.FailedThresholdCallback = failed =>
    {
        Log.Error(
            $@"A message of type {failed.MessageType} failed after executing {x.FailedRetryCount} several times, 
                        requiring manual troubleshooting. Message name: {failed.Message.GetName()}");
    };
    x.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
});

builder.Services.AddScoped<IDataSeeder, FlightDataSeeder>();
builder.Services.AddTransient<IMessageBroker, MessageBroker>();
builder.Services.AddTransient<IEventMapper, EventMapper>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();

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
