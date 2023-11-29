using Domain.PurchaseHistoryItems;
using MediatR;

namespace Application.PurchaseHistoryItems.Delete
{
    public record DeletePurchaseHistoryItemCommand(PurchaseHistoryItemId PurchaseHistoryItemId) : IRequest;
}
