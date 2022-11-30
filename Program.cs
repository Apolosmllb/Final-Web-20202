using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu201920124.API.Loyalty.Domain.Repositories;
using si730ebu201920124.API.Loyalty.Domain.services;
using si730ebu201920124.API.Loyalty.Persistence.Repository;
using si730ebu201920124.API.Loyalty.Services;
using si730ebu201920124.API.Shared.Domain.Repositories;
using si730ebu201920124.API.Shared.Persistence.Contexts;
using si730ebu201920124.API.Shared.Persistence.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure the HTTP request pipeline.
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EcoDrive.inc API",
        Description = "EcoDrive.inc RESTful API",
    });
    options.EnableAnnotations();
});

// Add Database Connection

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Lowercase URLs configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Bounded Context Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Loyalty Bounded Context Injection Configuration
builder.Services.AddScoped<IRewardRepository, RewardRespository>();
builder.Services.AddScoped<IRewardService, RewardService>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(si730ebu201920124.API.Loyalty.Mapping.ModelToResourceProfile),
    typeof(si730ebu201920124.API.Loyalty.Mapping.ResourceToModelProfile),
    typeof(si730ebu201920124.API.Loyalty.Mapping.ModelToResourceProfile),
    typeof(si730ebu201920124.API.Loyalty.Mapping.ResourceToModelProfile));
// AppSettings Configuration
builder.Services.Configure<AppSettingsSection>(builder.Configuration.GetSection("AppSettings"));

// Application built
var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

// CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
