using Application.Data;
using Domain.PurchaseHistories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PurchaseHistories.Get
{
    internal sealed class ListPurchaseHistoryQueryHandler : IRequestHandler<GetPurchaseHistoryQuery, PurchaseHistoryResponse>
    {
        private readonly IApplicationDbContext _context;

        public ListPurchaseHistoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseHistoryResponse> Handle(GetPurchaseHistoryQuery request, CancellationToken cancellationToken)
        {
            var purchaseHistory = await _context
                .PurchaseHistories
                .Where(p => p.Id == request.PurchaseHistoryId)
                .Select(p => new PurchaseHistoryResponse(
                    p.Id.Value,
                    p.UserId.Value,
                    p.Amount.Currency,
                    p.Amount.Amount))
                .FirstOrDefaultAsync(cancellationToken);

            if (purchaseHistory is null)
            {
                throw new PurchaseHistoryNotFoundException(request.PurchaseHistoryId);
            }

            return purchaseHistory;
        }
    }
}
