using Domain.Products;

namespace Domain.PurchaseHistories
{
    public class PurchasedItem
    {
        public PurchasedItem(PurchaseHistoryItemId id, PurchaseHistoryId purchaseHistoryId, ProductId productId, Products.Money price, decimal quantity, Money amount)
        {
            Id = id;
            PurchaseHistoryId = purchaseHistoryId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            Amount = amount;
        }

        public PurchaseHistoryItemId Id { get; private set; }

        public PurchaseHistoryId PurchaseHistoryId { get; private set; }

        public ProductId ProductId { get; private set; }

        public Products.Money Price { get; private set; }

        public decimal Quantity { get; private set; }

        public Money Amount { get; private set; }
    }
}
