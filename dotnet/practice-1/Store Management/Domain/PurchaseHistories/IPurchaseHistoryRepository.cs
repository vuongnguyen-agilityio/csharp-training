namespace Domain.PurchaseHistories
{
    public interface IPurchaseHistoryRepository
    {
        Task<PurchaseHistory?> GetByIdAsync(PurchaseHistoryId id);

        void Add(PurchaseHistory product);

        void Update(PurchaseHistory product);

        void Remove(PurchaseHistory product);
    }
}
