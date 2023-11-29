using Application.Data;
using Application.PurchaseHistoryItems.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PurchaseHistoryItems.List
{
    internal sealed class ListPurchaseHistoryItemQueryHandler : IRequestHandler<ListPurchaseHistoryItemQuery, List<PurchaseHistoryItemResponse>>
    {
        private readonly IApplicationDbContext _context;

        public ListPurchaseHistoryItemQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseHistoryItemResponse>> Handle(ListPurchaseHistoryItemQuery request, CancellationToken cancellationToken)
        {
            var purchaseHistoryItems = await _context
                .PurchaseHistoryItems
                .Select(p => new PurchaseHistoryItemResponse(
                    p.Id.Value,
                    p.PurchaseHistoryId.Value,
                    p.ProductId.Value,
                    p.Price.Currency,
                    p.Price.Amount,
                    p.Quantity))
                .ToListAsync(cancellationToken);

            return purchaseHistoryItems;
        }
    }
}
