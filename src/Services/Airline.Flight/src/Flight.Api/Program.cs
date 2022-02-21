using System.Reflection;
using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using BuildingBlocks.Jwt;
using BuildingBlocks.Mapster;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Persistence;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using Figgle;
using Flight;
using Flight.Data;
using Flight.Data.Seed;
using Flight.Extensions;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

Console.WriteLine(FiggleFonts.Standard.Render(configuration["app"]));

builder.Services.AddDbContext<FlightDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("FlightConnection"),
        x => x.MigrationsAssembly(typeof(FlightDbContext).Assembly.FullName)));


builder.Services.AddScoped<IDataSeeder, FlightDataSeeder>();

builder.Services.AddJwt();
builder.Services.AddControllers();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(FlightRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddCustomMediatR();
builder.Services.AddValidatorsFromAssembly(typeof(FlightRoot).Assembly);
builder.Services.AddCustomProblemDetails();
builder.Services.AddCustomMapster(typeof(FlightRoot).Assembly);

builder.Services.AddTransient<IEventMapper, EventMapper>();
builder.Services.AddTransient<IMessageBroker, MessageBroker>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();

builder.Services.AddCustomMassTransit(typeof(FlightRoot).Assembly);

SnowFlakIdGenerator.Configure(1);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    app.UseCustomSwagger(provider);
}

app.UseMigrations();
app.UseProblemDetails();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", x => x.Response.WriteAsync(configuration["app"]));
app.Run();
