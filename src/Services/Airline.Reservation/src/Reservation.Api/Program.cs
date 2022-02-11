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
using Reservation;
using Reservation.Data;
using Reservation.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

Console.WriteLine(FiggleFonts.Standard.Render(configuration["app"]));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(ReservationRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddCustomMediatR();
builder.Services.AddValidatorsFromAssembly(typeof(ReservationRoot).Assembly);
builder.Services.AddCustomProblemDetails();
builder.Services.AddAutoMapper(typeof(ReservationRoot).Assembly);
builder.Services.AddRefitServices();

builder.Services.AddDbContext<ReservationDbContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("ReservationConnection"));
});

builder.Services.AddTransient<IEventMapper, EventMapper>();
builder.Services.AddTransient<IMessageBroker, MessageBroker>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();

builder.Services.AddCustomMassTransit();

SnowFlakIdGenerator.Configure(1);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    app.UseCustomSwagger(provider);
}

app.UseProblemDetails();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();