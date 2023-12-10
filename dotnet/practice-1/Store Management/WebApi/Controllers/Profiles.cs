using Microsoft.AspNetCore.Mvc;
using MediatR;

using Domain.Profiles;
using Application.Profiles.Create;
using Application.Profiles.Delete;
using Application.Profiles.Get;
using Application.Profiles.List;
using Application.Profiles.Update;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Domain.Users;

namespace Web.API.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPost]
        public async Task<IResult> Register(CreateProfileCommand command, ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpGet]
        public Task<List<ProfileResponse>> Get(ISender sender)
        {
            return sender.Send(new ListProfileQuery());
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            try
            {
                return Results.Ok(await sender.Send(new GetProfileQuery(new ProfileId(id))));
            }
            catch (ProfileNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [HttpGet("/me")]
        public async Task<IResult> GetByCurrentProfileId(ISender sender)
        {
            try
            {
                string UserId = User.FindFirstValue("id")!;
                return Results.Ok(await sender.Send(new GetProfileByUserIdQuery(new UserId(new Guid(UserId)))));
            }
            catch (ProfileNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateById(Guid id, [FromBody] UpdateProfileRequest request, ISender sender)
        {
            var command = new UpdateProfileCommand(
                new ProfileId(id),
                request.FirstName,
                request.LastName,
                request.Age);

            await sender.Send(command);

            return Results.NoContent();
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteById(Guid id, ISender sender)
        {
            try
            {
                await sender.Send(new DeleteProfileCommand(new ProfileId(id)));

                return Results.NoContent();
            }
            catch (ProfileNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }
    }
}
