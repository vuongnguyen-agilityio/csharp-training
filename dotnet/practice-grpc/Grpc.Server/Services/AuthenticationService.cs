using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Grpc.Server.Services;

public class AuthenticationService() {

  public static string GenerateJwtToken(string name, SymmetricSecurityKey securityKey)
  {
    JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

    if (string.IsNullOrEmpty(name))
    {
      throw new InvalidOperationException("Name is not specified.");
    }

    var claims = new[] { new Claim(ClaimTypes.Name, name) };
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
      "ExampleServer",
      "ExampleClients",
      claims,
      expires: DateTime.Now.AddSeconds(60),
      signingCredentials: credentials
    );
    return jwtTokenHandler.WriteToken(token);
  }
}