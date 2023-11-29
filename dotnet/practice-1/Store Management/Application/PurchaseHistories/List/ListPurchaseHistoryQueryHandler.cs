using Application.Data;
using Application.PurchaseHistories.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PurchaseHistories.List
{
    internal sealed class ListPurchaseHistoryQueryHandler : IRequestHandler<ListPurchaseHistoryQuery, List<PurchaseHistoryResponse>>
    {
        private readonly IApplicationDbContext _context;

        public ListPurchaseHistoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseHistoryResponse>> Handle(ListPurchaseHistoryQuery request, CancellationToken cancellationToken)
        {
            var PurchaseHistories = await _context
                .PurchaseHistories
                .Select(p => new PurchaseHistoryResponse(
                    p.Id.Value,
                    p.UserId.Value,
                    p.Amount.Currency,
                    p.Amount.Amount))
                .ToListAsync(cancellationToken);

            return PurchaseHistories;
        }
    }
}
