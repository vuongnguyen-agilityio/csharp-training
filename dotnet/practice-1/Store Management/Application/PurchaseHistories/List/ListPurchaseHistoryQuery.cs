using Application.PurchaseHistories.Get;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.List
{
    public record ListPurchaseHistoryQuery(UserId UserId) : IRequest<List<PurchaseHistoryResponse>>;
}
