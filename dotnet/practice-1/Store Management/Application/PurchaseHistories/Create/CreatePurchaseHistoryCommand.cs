using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Create
{
    public record CreatePurchaseHistoryRequest(
        string Currency,
        decimal Amount) : IRequest;

    public record CreatePurchaseHistoryCommand(
        UserId UserId,
        string Currency,
        decimal Amount) : IRequest;
}
