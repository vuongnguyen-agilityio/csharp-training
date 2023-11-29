using Application.Data;
using Domain.PurchaseHistoryItems;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PurchaseHistoryItems.Get
{
    internal sealed class ListPurchaseHistoryItemQueryHandler : IRequestHandler<GetPurchaseHistoryItemQuery, PurchaseHistoryItemResponse>
    {
        private readonly IApplicationDbContext _context;

        public ListPurchaseHistoryItemQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseHistoryItemResponse> Handle(GetPurchaseHistoryItemQuery request, CancellationToken cancellationToken)
        {
            var product = await _context
                .PurchaseHistoryItems
                .Where(p => p.Id == request.PurchaseHistoryItemId)
                .Select(p => new PurchaseHistoryItemResponse(
                    p.Id.Value,
                    p.PurchaseHistoryId.Value,
                    p.ProductId.Value,
                    p.Price.Currency,
                    p.Price.Amount,
                    p.Quantity))
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null)
            {
                throw new PurchaseHistoryItemNotFoundException(request.PurchaseHistoryItemId);
            }

            return product;
        }
    }
}
