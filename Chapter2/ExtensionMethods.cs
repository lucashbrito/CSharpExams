
namespace Chapter2
{
    public static class ExtensionMethods
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * .9M;
        }
    }

    public class Product
    {
        public decimal Price { get; set; }
    }

    public class Calculator
    {
        public decimal CalculateDiscount(Product product)
        {
            return product.Discount();
        }
    }
}
