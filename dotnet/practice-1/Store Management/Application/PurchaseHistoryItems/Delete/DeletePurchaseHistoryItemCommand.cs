using Application.Abstractions.Messaging;
using Domain.PurchaseHistoryItems;

namespace Application.PurchaseHistoryItems.Delete
{
    public record DeletePurchaseHistoryItemCommand(PurchaseHistoryItemId PurchaseHistoryItemId) : ICommand;
}
