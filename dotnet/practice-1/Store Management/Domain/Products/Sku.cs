namespace Domain.Products
{
    // This is a generated of 8 integer value
    public record Sku
    {
        private const int DefaultLength = 8;

        private Sku(string value) => Value = value.Trim();

        public string Value { get; init; }

        public static Sku? Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            
            if (value.Length != DefaultLength) return null;

            return new Sku(value);
        }
    }
}
