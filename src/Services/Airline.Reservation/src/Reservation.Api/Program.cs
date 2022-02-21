using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;
using BuildingBlocks.Jwt;
using BuildingBlocks.Mapster;
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

builder.Services.AddJwt();
builder.Services.AddControllers();
builder.Services.AddCustomSwagger(builder.Configuration, typeof(ReservationRoot).Assembly);
builder.Services.AddCustomVersioning();
builder.Services.AddCustomMediatR();
builder.Services.AddValidatorsFromAssembly(typeof(ReservationRoot).Assembly);
builder.Services.AddCustomProblemDetails();
builder.Services.AddCustomMapster(typeof(ReservationRoot).Assembly);
builder.Services.AddRefitServices();

builder.Services.AddDbContext<ReservationDbContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("ReservationConnection"));
});

builder.Services.AddTransient<IEventMapper, EventMapper>();
builder.Services.AddTransient<IMessageBroker, MessageBroker>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();

builder.Services.AddCustomMassTransit(typeof(ReservationRoot).Assembly);

SnowFlakIdGenerator.Configure(3);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();
    app.UseCustomSwagger(provider);
}

app.UseProblemDetails();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", x => x.Response.WriteAsync(configuration["app"]));

app.Run();
