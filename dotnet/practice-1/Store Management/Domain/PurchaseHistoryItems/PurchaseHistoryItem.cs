﻿using Domain.Primitives;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.Users;

namespace Domain.PurchaseHistoryItems
{
    public class PurchaseHistoryItem : BaseEntity
    {
        public PurchaseHistoryItem(PurchaseHistoryItemId id, PurchaseHistoryId purchaseHistoryId, UserId userId, ProductId productId, Products.Money price, decimal quantity)
        {
            Id = id;
            PurchaseHistoryId = purchaseHistoryId;
            UserId = userId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        private PurchaseHistoryItem() { }

        public PurchaseHistoryItemId Id { get; private set; }

        public PurchaseHistoryId PurchaseHistoryId { get; private set; }

        public UserId UserId { get; private set; }

        public ProductId ProductId { get; private set; }

        public Products.Money Price { get; private set; }

        public decimal Quantity { get; private set; }

        public void Update(PurchaseHistoryId purchaseHistoryId, ProductId productId, Products.Money price, decimal quantity)
        {
            PurchaseHistoryId = purchaseHistoryId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
    }
}
