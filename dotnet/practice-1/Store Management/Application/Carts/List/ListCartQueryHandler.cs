using Application.Data;
using Application.Carts.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Carts.List
{
    internal sealed class ListCartQueryHandler : IRequestHandler<ListCartQuery, List<CartResponse>>
    {
        private readonly IApplicationDbContext _context;

        public ListCartQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartResponse>> Handle(ListCartQuery request, CancellationToken cancellationToken)
        {
            var carts = await _context
                .Carts
                .Where(c => c.UserId == request.UserId)
                .Select(c => new CartResponse(
                    c.UserId.Value,
                    c.ProductId.Value,
                    c.Quantity))
                .ToListAsync(cancellationToken);

            return carts;
        }
    }
}
