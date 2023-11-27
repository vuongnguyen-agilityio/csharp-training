using Application.Users.Create;
using Application.Users.Delete;
using Application.Users.Get;
using Application.Users.List;
using Application.Users.Update;
using Carter;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("register", async (CreateUserCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("users", async (ISender sender) =>
        {
            return Results.Ok(await sender.Send(new ListUserQuery()));
        });

        // Admin Role
        app.MapGet("users/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetUserQuery(new UserId(id))));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        // Admin Role
        app.MapPut("users/{id:guid}", async (Guid id, [FromBody] UpdateUserRequest request, ISender sender) =>
        {
            var command = new UpdateUserCommand(
                new UserId(id),
                request.Name,
                request.Password);

            await sender.Send(command);

            return Results.NoContent();
        });

        // Admin Role
        app.MapDelete("users/{id:guid}", async (Guid id, ISender sender) =>
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
        });
    }
}
