using System.Linq;

// Defines the namespace used by the product management classes.
namespace MiniProjProductListManagerSystem
{
    // Manages the collection of products and performs operations on that collection.
    public class ProductManager
    {
        // Keeps all products that have been added during the current program run.
        private readonly List<Product> products = [];

        // Adds a product to the internal product list.
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Returns all products sorted from the lowest price to the highest price.
        public List<Product> GetProducts()
        {
            // OrderBy sorts products by their Price property.
            // ToList creates a new list containing the sorted products.
            return products
                .OrderBy(p => p.Price)
                .ToList();
        }

        // Calculates the total price of all products in the internal list.
        public decimal CalculateTotalAmount()
        {
            // Sum adds the Price value from every product.
            return products.Sum(p => p.Price);
        }

        // Finds products whose name or category contains the search text.
        public List<Product> SearchProduct(string searchText)
        {
            // The comparison ignores differences between uppercase and lowercase letters.
            // ToList converts the matching results into a list.
            return products
                .Where(p =>
                    p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    || p.Category.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}