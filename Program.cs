using introapp.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo{ Title = "ASP.NET and React tutorial", Version = "v1"});
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET & React intro";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web api service");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.MapGet("/get-all-posts", async() => PostsRepository.GetPostsAsync())
    .WithTags("Posts Endpoints");

app.Run();
