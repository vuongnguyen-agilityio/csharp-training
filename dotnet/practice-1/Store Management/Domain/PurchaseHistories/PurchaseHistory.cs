using Domain.Primitives;
using Domain.PurchaseHistoryItems;
using Domain.Users;

namespace Domain.PurchaseHistories
{
    public class PurchaseHistory : BaseEntity
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

        public ICollection<PurchaseHistoryItem> PurchaseHistoryItems { get; } = new List<PurchaseHistoryItem>();

        public void Update(UserId userId, Money amount)
        {
            UserId = userId;
            Amount = amount;
        }
    }
}
