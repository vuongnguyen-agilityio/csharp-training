using Domain.Products;
using Domain.PurchaseHistories;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistoryItems.Create
{
    public record CreatePurchaseHistoryItemRequest(
        ProductId ProductId,
        decimal ProductAmount,
        decimal Quantity,
        string ProductCurrency) : IRequest;

    public record CreatePurchaseHistoryItemCommand(
        PurchaseHistoryId PurchaseHistoryId,
        UserId UserId,
        ProductId ProductId,
        decimal ProductAmount,
        decimal Quantity,
        string ProductCurrency) : IRequest;
}
