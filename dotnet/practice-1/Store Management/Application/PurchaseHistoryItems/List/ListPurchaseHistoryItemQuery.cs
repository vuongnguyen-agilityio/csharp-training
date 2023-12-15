using Application.Abstractions.Messaging;
using Application.PurchaseHistoryItems.Get;

namespace Application.PurchaseHistoryItems.List
{
    public record ListPurchaseHistoryItemQuery() : ICommand<List<PurchaseHistoryItemResponse>>;
}
