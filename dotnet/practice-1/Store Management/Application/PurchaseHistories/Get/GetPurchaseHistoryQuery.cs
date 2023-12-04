﻿using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Get
{
    public record GetPurchaseHistoryQuery(UserId UserId, PurchaseHistoryId PurchaseHistoryId) : IRequest<PurchaseHistoryResponse>;

    public record PurchaseHistoryResponse(
        Guid Id,
        Guid UserId,
        string Currency,
        decimal Amount,
        List<PurchaseHistoryItem> PurchaseHistoryItems);
}
