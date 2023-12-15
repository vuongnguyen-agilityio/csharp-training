using Application.Abstractions.Messaging;
using Domain.PurchaseHistories;
using Domain.Users;

namespace Application.PurchaseHistories.Delete
{
    public record DeletePurchaseHistoryCommand(UserId UserId, PurchaseHistoryId PurchaseHistoryId) : ICommand;
}
