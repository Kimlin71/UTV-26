// Represents one product stored in the product list.
namespace MiniProjProductListManagerSystem
{
    public class Product
    {
        // Stores the product category, such as Food or Clothing.
        public string Category { get; set; }

        // Stores the product name, such as Apple or Pear.
        public string Name { get; set; }
        // Stores the product price as a decimal value.
        public decimal Price { get; set; }

        // Creates a product and initializes all of its values.
        public Product(string category, string name, decimal price)
        {
            Category = category;
            Name = name;
            Price = price;
        }
    }
}