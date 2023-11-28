using Application.Data;
using Domain.Carts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Carts.Get
{
    internal sealed class ListCartQueryHandler : IRequestHandler<GetCartQuery, CartResponse>
    {
        private readonly IApplicationDbContext _context;

        public ListCartQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CartResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _context
                .Carts
                .Where(c => c.UserId == request.UserId && c.ProductId == request.ProductId)
                .Select(c => new CartResponse(
                    c.UserId.Value,
                    c.ProductId.Value,
                    c.Quantity))
                .FirstOrDefaultAsync(cancellationToken);

            if (cart is null)
            {
                throw new CartNotFoundException(request.ProductId);
            }

            return cart;
        }
    }
}
