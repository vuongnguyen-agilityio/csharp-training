using Application.Carts.Get;
using Domain.Users;
using MediatR;

namespace Application.Carts.List
{
    public record ListCartQuery(UserId UserId) : IRequest<List<CartResponse>>;
}
