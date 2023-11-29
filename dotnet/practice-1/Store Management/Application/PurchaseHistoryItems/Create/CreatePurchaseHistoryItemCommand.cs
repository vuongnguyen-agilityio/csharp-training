using Domain.Products;
using Domain.PurchaseHistories;
using MediatR;

namespace Application.PurchaseHistoryItems.Create
{
    public record CreatePurchaseHistoryItemCommand(
        PurchaseHistoryId PurchaseHistoryId,
        ProductId ProductId,
        decimal ProductAmount,
        decimal Quantity,
        string ProductCurrency) : IRequest;
}
