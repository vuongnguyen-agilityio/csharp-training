using Domain.PurchaseHistories;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Delete
{
    public record DeletePurchaseHistoryCommand(UserId UserId, PurchaseHistoryId PurchaseHistoryId) : IRequest;
}
