using Application.Abstractions.Messaging;
using Application.PurchaseHistories.Get;
using Domain.Users;

namespace Application.PurchaseHistories.List
{
    public record ListPurchaseHistoryQuery(UserId UserId) : ICommand<List<PurchaseHistoryResponse>>;
}
