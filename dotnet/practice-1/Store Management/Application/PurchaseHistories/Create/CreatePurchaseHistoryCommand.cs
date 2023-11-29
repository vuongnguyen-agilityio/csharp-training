using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Create
{
    public record CreatePurchaseHistoryCommand(
        UserId UserId,
        string Currency,
        decimal Amount) : IRequest;
}
