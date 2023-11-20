using Domain.Users;

namespace Domain.PurchaseHistories
{
    public class PurchaseHistory
    {
        public PurchaseHistory(PurchaseHistoryId id, UserId userId, Money amount)
        {
            Id = id;
            UserId = userId;
            Amount = amount;
        }

        public PurchaseHistoryId Id { get; private set; }

        public UserId UserId { get; private set; }

        public Money Amount { get; private set; }
    }
}
