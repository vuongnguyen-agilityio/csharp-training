using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

using Application.Authentication.Login;
using Application.Authentication.Register;
using Application.Authentication.RegisterAdmin;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IResult> Login([FromBody] LoginCommand command, ISender sender)
        {   
            try
            {
                JwtSecurityToken token = await sender.Send(command);

                return Results.Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch
            {
                return Results.Unauthorized();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IResult> Register([FromBody] RegisterCommand command, ISender sender)
        {
            try
            {
                await sender.Send(command);
                return Results.Ok();
            }
            catch(Exception ex)
            {
                return Results.Problem(new ProblemDetails { Detail = ex.Message ?? "Unknown", Status = StatusCodes.Status403Forbidden });
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IResult> RegisterAdmin([FromBody] RegisterAdminCommand command, ISender sender)
        {
            try
            {
                await sender.Send(command);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(new ProblemDetails { Detail = ex.Message ?? "Unknown", Status = StatusCodes.Status403Forbidden });
            }
        }
    }
}