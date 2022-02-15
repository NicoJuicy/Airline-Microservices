using BuildingBlocks.Jwt;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddJwt();
builder.Services.AddControllers();

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("Yarp"));


var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapReverseProxy(proxyPipeline =>
    {
        proxyPipeline.Use(async (context, next) =>
        {
            var token = await context.GetTokenAsync("access_token");
            context.Request.Headers["Authorization"] = $"Bearer {token}";

            await next().ConfigureAwait(false);
        });
    });
});

app.MapGet("/", x=> x.Response.WriteAsync(configuration["app"]));

app.Run();