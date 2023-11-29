namespace Domain.PurchaseHistories;

public sealed class PurchaseHistoryNotFoundException : Exception
{
    public PurchaseHistoryNotFoundException(PurchaseHistoryId id)
        : base($"The purchased with the ID = {id.Value} was not found")
    {
    }
}
