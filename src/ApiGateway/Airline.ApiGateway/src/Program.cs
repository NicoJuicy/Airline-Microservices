using BuildingBlocks.Jwt;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwt();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("Yarp"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

app.Run();