using Domain.PurchaseHistoryItems;
using MediatR;

namespace Application.PurchaseHistoryItems.Get
{
    public record GetPurchaseHistoryItemQuery(PurchaseHistoryItemId PurchaseHistoryItemId) : IRequest<PurchaseHistoryItemResponse>;

    public record PurchaseHistoryItemResponse(
        Guid Id,
        Guid PurchaseHistoryId,
        Guid ProductId,
        string ProductCurrency,
        decimal ProductAmount,
        decimal Quantity
        );
}
