namespace Domain.Products
{
    public class Product
    {
        public Product(ProductId id, string name, Money price, Sku sku)
        {
            Id = id;
            Name = name;
            Price = price;
            Sku = sku;
        }

        private Product() {}

        public ProductId Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        // The format price is a record: { Currency, Amount }
        public Money Price { get; private set; }

        // This is a generated of 8 integer value
        public Sku Sku { get; private set; }

        public void Update(string name, Money price, Sku sku)
        {
            Name = name;
            Price = price;
            Sku = sku;
        }
    }
}
