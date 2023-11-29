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

        private PurchaseHistory() { }

        public PurchaseHistoryId Id { get; private set; }

        public UserId UserId { get; private set; }

        public Money Amount { get; private set; }

        public void Update(UserId userId, Money amount)
        {
            UserId = userId;
            Amount = amount;
        }
    }
}
