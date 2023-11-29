using Application.PurchaseHistories.Get;
using MediatR;

namespace Application.PurchaseHistories.List
{
    public record ListPurchaseHistoryQuery() : IRequest<List<PurchaseHistoryResponse>>;
}
