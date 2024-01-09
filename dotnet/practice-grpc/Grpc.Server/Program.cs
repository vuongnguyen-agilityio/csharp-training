using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Grpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

// Add Authentication
SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
  {
    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    policy.RequireClaim(ClaimTypes.Name);
  });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters =
      new TokenValidationParameters
      {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateActor = false,
        ValidateLifetime = true,
        IssuerSigningKey = securityKey
      };
  });

var app = builder.Build();

app.UseRouting();

// Add Authentication
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Not Available! Communication with gRPC endpoints must be made through a gRPC client.");

app.MapGet("/generateJwtToken", context =>
{
  return context.Response.WriteAsync(AuthenticationService.GenerateJwtToken(context.Request.Query["name"]!));
});

app.Run();
