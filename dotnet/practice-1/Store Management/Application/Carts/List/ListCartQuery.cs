using Application.Abstractions.Messaging;
using Application.Carts.Get;
using Domain.Users;

namespace Application.Carts.List
{
    public record ListCartQuery(UserId UserId) : ICommand<List<CartResponse>>;
}
