namespace Domain.PurchaseHistoryItems
{
    public interface IPurchaseHistoryItemRepository
    {
        Task<PurchaseHistoryItem?> GetByIdAsync(PurchaseHistoryItemId id);

        void Add(PurchaseHistoryItem product);

        void Update(PurchaseHistoryItem product);

        void Remove(PurchaseHistoryItem product);
    }
}
