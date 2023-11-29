namespace Domain.PurchaseHistoryItems
{
    public sealed class PurchaseHistoryItemNotFoundException : Exception
    {
        public PurchaseHistoryItemNotFoundException(PurchaseHistoryItemId id)
            : base($"The purchased item with the ID = {id.Value} was not found")
        {
        }
    }
}
