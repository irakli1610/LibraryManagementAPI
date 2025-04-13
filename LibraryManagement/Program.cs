using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagement.API.Infrastructure.Extensions;
using LibraryManagement.API.Infrastructure.Middlewares;
using LibraryManagement.API.Models.Examples.Books;
using LibraryManagement.Persistance.Connection;
using LibraryManagement.Persistance.Context;
using LibraryManagement.Persistance.Seed;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenExtension();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateBootstrapLogger();

builder.Host.UseSerilog();


builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddDbContext<LibraryManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

var applicationAssembly = Assembly.Load("LibraryManagement.Application");
builder.Services.AddValidatorsFromAssembly(applicationAssembly);
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddVersioningExtension();

builder.Services.AddServicesExtension();

builder.Services.AddSwaggerExamplesFromAssemblyOf<BooksResponseModelExample>();

var app = builder.Build();


app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Library Management API v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

try
{

    LibraryManagementSeed.Initialize(app.Services);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start.");   
}
finally
{
    await Log.CloseAndFlushAsync();
}



