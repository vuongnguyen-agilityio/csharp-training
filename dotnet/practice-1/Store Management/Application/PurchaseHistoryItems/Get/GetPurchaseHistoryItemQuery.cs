using Application.Abstractions.Messaging;
using Domain.PurchaseHistoryItems;

namespace Application.PurchaseHistoryItems.Get
{
    public record GetPurchaseHistoryItemQuery(PurchaseHistoryItemId PurchaseHistoryItemId) : ICommand<PurchaseHistoryItemResponse>;

    public record PurchaseHistoryItemResponse(
        Guid Id,
        Guid PurchaseHistoryId,
        Guid ProductId,
        string ProductCurrency,
        decimal ProductAmount,
        decimal Quantity
        );
}
