namespace JourneyBackEnd.Models
{
    public class ProductType
    {
        private ProductType(string value) { Value = value; }

        public string Value { get; set; }

        public static ProductType Lawnmower => new ProductType("Lawnmower");
        public static ProductType PhoneCase => new ProductType("Phone Case");
        public static ProductType TShirt => new ProductType("T-Shirt");
    }
}