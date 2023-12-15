using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.Users;

namespace Application.Carts.Get
{
    public record GetCartQuery(UserId UserId, ProductId ProductId) : ICommand<CartResponse>;

    public record CartResponse(
        Guid UserId,
        Guid ProductId,
        decimal Quantity);
}
