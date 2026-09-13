// Contains the user interface and the program flow for the console application.
namespace MiniProjProductListManagerSystem
{
    // Signals that the user typed q and wants to return to the main menu.
    public class BackToMenuException : Exception { }

    public class Program
    {
        // A single ProductManager is shared by all menu operations.
        private static readonly ProductManager productManager = new();

        // The entry point of the application.
        public static void Main()
        {
            ShowMainMenu();
        }
        // Displays the main menu until the user chooses to quit.
        private static void ShowMainMenu()
        {
            while (true)
            {
                // Display the available menu choices.
                Console.WriteLine("Enter a Number");
                Console.WriteLine("1-Add a Product");
                Console.WriteLine("2-Search a Product");
                Console.WriteLine("3-List Products");
                Console.WriteLine("0-Quit");
                Console.Write("Enter a Number: ");

                // Read the user's menu choice as text first.
                string? userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out int menuChoice))
                {
                    // If conversion fails, show an error and display the menu again.
                    Console.WriteLine("Invalid selection. Enter a number between 0 and 3.");
                    continue;
                }

                // Run the operation that matches the selected menu number.
                try
                {
                    switch (menuChoice)
                    {
                        case 1:
                            // Ask for the values of a new product and store it.
                            AddProduct();
                            break;
                        case 2:
                            // Search for products by name or category.
                            SearchProduct();
                            break;
                        case 3:
                            // Display all stored products.
                            ListProducts();
                            break;
                        case 0:
                            // Exit the menu method and end the application.
                            Console.WriteLine("Thank you for using this application");
                            return;
                        default:
                            // Handle numbers outside the supported menu choices.
                            Console.WriteLine("Invalid selection. Enter a number between 0 and 3.");
                            break;
                    }
                }
                catch (BackToMenuException)
                {
                    // If the user typed q, do nothing and let the loop show the menu again.
                }
            }
        }

        // Reads all required product values and adds a new product.
        private static void AddProduct()
        {
            Console.WriteLine("Type q and press Enter at any prompt to return to the menu.");

            string category = ReadRequiredText("Enter a Category: ", "Category cannot be empty.");
            string name = ReadRequiredText("Enter a Product Name: ", "Product name cannot be empty.");
            decimal price = ReadPrice();

            // Create a Product object and pass it to the manager for storage.
            productManager.AddProduct(new Product(category, name, price));
            Console.WriteLine("The product was successfully added!");
        }

        // Reads a search term and displays matching products highlighted in green.
        private static void SearchProduct()
        {
            Console.WriteLine("Type q and press Enter at any prompt to return to the menu.");

            // Let the user choose whether to search by name or category.
            Console.WriteLine("Search by:");
            Console.WriteLine("1-Product Name");
            Console.WriteLine("2-Category");
            string searchChoice = ReadRequiredText("Enter a Number: ", "Please enter 1 or 2.");

            string prompt = searchChoice == "2"
                ? "Enter a Category: "
                : "Enter a Product Name: ";

            string searchText = ReadRequiredText(prompt, "Search text cannot be empty.");

            // Ask the manager to find products matching the search term.
            List<Product> products = productManager.SearchProduct(searchText);

            // Display the table header before displaying the search results.
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Category".PadRight(15) + "Product".PadRight(15) + "Price");
            Console.WriteLine("------------------------------------------");

            // Check whether the search returned any products.
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

                // Display each matching product as one highlighted row in the table.
                foreach (Product product in products)
                {
                    Console.WriteLine(product.Category.PadRight(15) + product.Name.PadRight(15) + product.Price);
                }

                // Restore the default console color after printing results.
                Console.ResetColor();
            }

            Console.WriteLine("------------------------------------------");
        }

        // Reads text that must contain at least one non-whitespace character.
        private static string ReadRequiredText(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string? value = Console.ReadLine();

                // If the user types q, stop the current operation and go back to the menu.
                if (value?.Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true)
                {
                    throw new BackToMenuException();
                }

                // Reject null, empty, and whitespace-only input.
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value.Trim();
                }

                Console.WriteLine(errorMessage);
            }
        }

        // Reads and validates a product price from the console.
        private static decimal ReadPrice()
        {
            while (true)
            {
                Console.Write("Enter a Price: ");
                string? priceInput = Console.ReadLine();

                // If the user types q, stop the current operation and go back to the menu.
                if (priceInput?.Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true)
                {
                    throw new BackToMenuException();
                }

                // Accept both a period and a comma as the decimal separator.
                priceInput = priceInput?.Replace('.', ',');

                // Try to convert the normalized text into a decimal number.
                if (decimal.TryParse(priceInput, out decimal price))
                {
                    if (price >= 0)
                    {
                        // Return the validated price to AddProduct.
                        return price;
                    }

                    // Handle a correctly formatted but negative number.
                    Console.WriteLine("Price cannot be negative.");
                    continue;
                }

                // Handle input that cannot be converted into a decimal number.
                Console.WriteLine("Invalid price. Enter a number greater than or equal to 0.");
            }
        }
    

        // Displays all products and the total value of the product list.
        private static void ListProducts()
        {
            List<Product> products = productManager.GetProducts();

            // Display the table header.
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Category".PadRight(15) + "Product".PadRight(15) + "Price");
            Console.WriteLine("------------------------------------------");

            // Check whether there are any products to display.
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                // Display each product as one row in the table.
                foreach (Product product in products)
                {
                    Console.WriteLine(product.Category.PadRight(15) + product.Name.PadRight(15) + product.Price);
                }
            }

            // Display the total price of all products after the table.
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Total amount: {productManager.CalculateTotalAmount()}");
        }
    }
}