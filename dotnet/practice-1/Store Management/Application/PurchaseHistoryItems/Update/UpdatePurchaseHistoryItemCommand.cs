using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using MediatR;

namespace Application.PurchaseHistoryItems.Update
{
    public record UpdatePurchaseHistoryItemCommand(
        PurchaseHistoryItemId PurchaseHistoryItemId,
        PurchaseHistoryId PurchaseHistoryId,
        ProductId ProductId,
        string ProductCurrency,
        decimal ProductAmount,
        decimal Quantity) : IRequest;

    public record UpdatePurchaseHistoryItemRequest(
        PurchaseHistoryId PurchaseHistoryId,
        ProductId ProductId,
        string ProductCurrency,
        decimal ProductAmount,
        decimal Quantity);
}
