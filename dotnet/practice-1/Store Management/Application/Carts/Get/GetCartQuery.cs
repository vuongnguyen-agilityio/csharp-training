using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Get
{
    public record GetCartQuery(UserId UserId, ProductId ProductId) : IRequest<CartResponse>;

    public record CartResponse(
        Guid UserId,
        Guid ProductId,
        decimal Quantity);
}
