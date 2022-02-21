using BuildingBlocks.CAP;
using BuildingBlocks.Domain;
using BuildingBlocks.Mapster;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Persistence;
using BuildingBlocks.Swagger;
using BuildingBlocks.Web;
using Figgle;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Identity;
using Identity.Data;
using Identity.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var env = builder.Environment;

Console.WriteLine(FiggleFonts.Standard.Render(configuration["app"]));

builder.Services.AddControllers();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(IdentityRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddCustomMediatR();
builder.Services.AddValidatorsFromAssembly(typeof(IdentityRoot).Assembly);
builder.Services.AddCustomProblemDetails();
builder.Services.AddCustomMapster(typeof(IdentityRoot).Assembly);

builder.Services.AddDbContext<IdentityContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddScoped<IDataSeeder, IdentityDataSeeder>();
builder.Services.AddTransient<IEventMapper, EventMapper>();
builder.Services.AddTransient<IMessageBroker, MessageBroker>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();

builder.Services.AddCustomMassTransit(typeof(IdentityRoot).Assembly);

builder.Services.AddIdentityServer(env);

var app = builder.Build();

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
app.MapGet("/", x=> x.Response.WriteAsync(configuration["app"]));

app.Run();
