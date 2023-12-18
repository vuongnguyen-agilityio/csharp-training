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
        private RegisterCommandValidator _validator;
        private RegisterAdminCommandValidator _registerAdminCommandValidator;

        public AuthController(RegisterCommandValidator validator, RegisterAdminCommandValidator registerAdminCommandValidator)
        {
            _validator = validator;
            _registerAdminCommandValidator = registerAdminCommandValidator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IResult> Login([FromBody] LoginCommand command, ISender sender)
        {   
            JwtSecurityToken token = await sender.Send(command);

            return Results.Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IResult> Register([FromBody] RegisterCommand command, ISender sender)
        {
            await sender.Send(command);
            return Results.Ok();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IResult> RegisterAdmin([FromBody] RegisterAdminCommand command, ISender sender)
        {
            await sender.Send(command);
            return Results.Ok();
        }
    }
}