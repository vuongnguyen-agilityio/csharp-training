using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.Users;

namespace Application.Carts.Create
{
    public record CreateCartRequest(
        ProductId ProductId,
        decimal Quantity
        ) : ICommand;

    public record CreateCartCommand(
        UserId UserId,
        ProductId ProductId,
        decimal Quantity
        ) : ICommand;
}
