using Application;
using Carter;
//using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Serilog;
using Web.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication();
    //.AddInfrastructure()

builder.Services.AddCarter();

// Add API versioning
// E.g: URL based Versioning
// [ApiController]  
// [ApiVersion("1.0")]
// [Route("api/{v:apiVersion}/employee")]
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapCarter();

app.Run();
