using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;

namespace Application.PurchaseHistoryItems.Update
{
    public record UpdatePurchaseHistoryItemCommand(
        PurchaseHistoryItemId PurchaseHistoryItemId,
        PurchaseHistoryId PurchaseHistoryId,
        ProductId ProductId,
        string ProductCurrency,
        decimal ProductAmount,
        decimal Quantity) : ICommand;

    public record UpdatePurchaseHistoryItemRequest(
        PurchaseHistoryId PurchaseHistoryId,
        ProductId ProductId,
        string ProductCurrency,
        decimal ProductAmount,
        decimal Quantity);
}
