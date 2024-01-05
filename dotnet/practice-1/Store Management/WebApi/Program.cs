using Serilog;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

//using Infrastructure;
using Application;
using Domain.Authentications;
using Persistence;
using WebApi.Extensions;
using WebApi.Exceptions;

using GraphQL;
using WebApi.GraphQLs.Schemas;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Store Management API",
        Description = "An ASP.NET Core Web API for managing store",
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// For Identity
builder.Services.AddIdentity<BaseAuthentication, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication using JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"], // <-- Protect Secrets in Development
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication();
//.AddInfrastructure()

builder.Services.AddControllers();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

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

//builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddGraphQL(b => b
    .AddSchema<ProductSchema>()  // schema
    .AddSystemTextJson()   // serializer
    .AddGraphTypes(typeof(ProductSchema).Assembly)
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)); // Expose error details
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

//app.UseSerilogRequestLogging();
app.UseExceptionHandler();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseGraphQL("/graphql");
app.UseGraphQLPlayground(
    "/",
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

// url to host GraphQL endpoint https://localhost:7202/ui/altair
app.UseGraphQLAltair();


app.Run();

// Public Program for Integration Testing
public partial class Program { }