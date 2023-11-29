using Domain.PurchaseHistories;
using MediatR;

namespace Application.PurchaseHistories.Delete
{
    public record DeletePurchaseHistoryCommand(PurchaseHistoryId PurchaseHistoryId) : IRequest;
}
