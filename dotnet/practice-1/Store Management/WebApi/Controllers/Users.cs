using Microsoft.AspNetCore.Mvc;
using MediatR;

using Domain.Users;
using Application.Users.Create;
using Application.Users.Delete;
using Application.Users.Get;
using Application.Users.List;
using Application.Users.Update;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Web.API.Endpoints
{
    // FIXME: This should be the Profile Management API.
    // Because the User is managed by .Net Identity.
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPost(Name = "Register")]
        public async Task<IResult> Register(CreateUserCommand command, ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpGet(Name = "GetUser")]
        public Task<List<UserResponse>> Get(ISender sender)
        {
            return sender.Send(new ListUserQuery());
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            try
            {
                return Results.Ok(await sender.Send(new GetUserQuery(new UserId(id))));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [HttpGet("/me")]
        public async Task<IResult> GetByCurrentUserId(ISender sender)
        {
            try
            {
                string UserId = User.FindFirstValue("id")!;
                return Results.Ok(await sender.Send(new GetUserQuery(new UserId(new Guid(UserId)))));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateById(Guid id, [FromBody] UpdateUserRequest request, ISender sender)
        {
            var command = new UpdateUserCommand(
                new UserId(id),
                request.Name,
                request.Password);

            await sender.Send(command);

            return Results.NoContent();
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteById(Guid id, ISender sender)
        {
            try
            {
                await sender.Send(new DeleteUserCommand(new UserId(id)));

                return Results.NoContent();
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }
    }
}
