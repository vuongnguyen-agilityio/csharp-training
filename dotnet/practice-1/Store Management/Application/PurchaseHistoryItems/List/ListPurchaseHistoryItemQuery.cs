using Application.PurchaseHistoryItems.Get;
using MediatR;

namespace Application.PurchaseHistoryItems.List
{
    public record ListPurchaseHistoryItemQuery() : IRequest<List<PurchaseHistoryItemResponse>>;
}
