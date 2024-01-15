using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Grpc.Server.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

//builder.Services.AddRazorPages();
builder.Services.AddMvc()
            .AddNewtonsoftJson();

builder.Services.AddSingleton<ServerGrpcSubscribers>();

// Add Authentication
SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!));
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
app.MapGrpcService<DuplexService>();

app.MapGet("/generateJwtToken", context =>
{
    return context.Response.WriteAsync(AuthenticationService.GenerateJwtToken(context.Request.Query["name"]!, securityKey));
});

app.UseStaticFiles();
app.MapRazorPages();

app.Run();
