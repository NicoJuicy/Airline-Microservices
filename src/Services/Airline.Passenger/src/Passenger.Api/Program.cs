using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using Figgle;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Passenger;
using Passenger.Data;
using Passenger.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

Console.WriteLine(FiggleFonts.Standard.Render(configuration["app"]));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(PassengerRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddCustomMediatR();
builder.Services.AddValidatorsFromAssembly(typeof(PassengerRoot).Assembly);
builder.Services.AddCustomProblemDetails();
builder.Services.AddAutoMapper(typeof(PassengerRoot).Assembly);


builder.Services.AddDbContext<PassengerDbContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("PassengerConnection"));
});

builder.Services.AddTransient<IEventMapper, EventMapper>();
builder.Services.AddTransient<IMessageBroker, MessageBroker>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();

builder.Services.AddCustomMassTransit(typeof(PassengerRoot).Assembly);

SnowFlakIdGenerator.Configure(2);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    app.UseCustomSwagger(provider);
}

app.UseProblemDetails();
app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/", x=> x.Response.WriteAsync(configuration["app"]));

app.Run();