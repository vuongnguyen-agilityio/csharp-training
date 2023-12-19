using Application.Abstractions.Messaging;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.Users;

namespace Application.PurchaseHistoryItems.Create
{
    public record CreatePurchaseHistoryItemRequest(
        ProductId ProductId,
        decimal ProductAmount,
        decimal Quantity,
        string ProductCurrency) : ICommand;

    public record CreatePurchaseHistoryItemCommand(
        PurchaseHistoryId PurchaseHistoryId,
        UserId UserId,
        ProductId ProductId,
        decimal ProductAmount,
        decimal Quantity,
        string ProductCurrency) : ICommand;
}
