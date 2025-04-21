using Scalar.AspNetCore;
using Zura.Application;
using Zura.Infrastructure.Persistence;
using Zura.Presentation.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
{

    builder.Services.RegisterApplicationServices()
        .RegisterPersistenceServices(builder.Configuration)
        .RegisterPresentationServices();
}
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Title = "API Documentation";
            options.Theme = ScalarTheme.Mars;
        });

    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
