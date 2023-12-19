using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.Users;

namespace Application.Carts.Delete
{
    public record DeleteCartRequest(ProductId ProductId) : ICommand;

    public record DeleteCartCommand(UserId UserId, ProductId ProductId) : ICommand;
}
