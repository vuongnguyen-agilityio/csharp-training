using Domain.PurchaseHistories;
using MediatR;

namespace Application.PurchaseHistories.Get
{
    public record GetPurchaseHistoryQuery(PurchaseHistoryId PurchaseHistoryId) : IRequest<PurchaseHistoryResponse>;

    public record PurchaseHistoryResponse(
        Guid Id,
        Guid UserId,
        string Currency,
        decimal Amount);
}
