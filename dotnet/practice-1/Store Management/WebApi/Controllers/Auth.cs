using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Domain.Users;
using Application.Authentication.Login;
using Application.Authentication.Register;
using Domain.Authentications;

namespace WebApi.Controllers
{
    // FIXME: Move logical into Application Layer
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Authentication> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<Authentication> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IResult> Register([FromBody] RegisterCommand model)
        {
            var userExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                return Results.Problem(new ProblemDetails { Detail = "User already exists!", Status = StatusCodes.Status409Conflict });
            }

            Authentication user = new Authentication()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                Results.StatusCode(StatusCodes.Status500InternalServerError);
                return Results.Problem(new ProblemDetails{ Detail = "User creation failed! Please check user details and try again.", Status = StatusCodes.Status500InternalServerError });
            }

            return Results.Ok();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IResult> RegisterAdmin([FromBody] RegisterCommand model)
        {
            var userExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                return Results.Problem(new ProblemDetails { Detail = "User already exists!", Status = StatusCodes.Status409Conflict });
            }


            Authentication user = new Authentication()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return Results.Problem(new ProblemDetails { Detail = "User creation failed! Please check user details and try again.", Status = StatusCodes.Status500InternalServerError });
            }

            if (!await roleManager.RoleExistsAsync(UserRole.Admin.ToString()))
                await roleManager.CreateAsync(new IdentityRole(UserRole.Admin.ToString()));
            if (!await roleManager.RoleExistsAsync(UserRole.User.ToString()))
                await roleManager.CreateAsync(new IdentityRole(UserRole.User.ToString()));

            if (await roleManager.RoleExistsAsync(UserRole.Admin.ToString()))
            {
                await userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
            }

            return Results.Ok();
        }
    }
}