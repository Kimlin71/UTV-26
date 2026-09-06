// This list stores all products entered by the user.
List<string> products = new List<string>();

// This variable controls when the program should stop.
// It stays true while the program is running.
bool isRunning = true;

// The menu is shown again after every action until the user chooses Exit.
while (isRunning)
{
    // Clear the old menu so that the new menu is easier to read.
    ClearConsole();

    // Show the choices that the user can select.
    ShowMenu();

    // Read the user's choice and remove unnecessary spaces.
    // ToLower makes text choices such as "EXIT" work like "exit".
    string choice = (Console.ReadLine() ?? "").Trim().ToLower();

    // Run the method that belongs to the selected menu choice.
    switch (choice)
    {
        case "1":
            AddProduct(products);
            break;
        case "2":
            ViewProducts(products);
            break;
        case "3":
            SearchProduct(products);
            break;
        case "4":
            DeleteProduct(products);
            break;
        case "5":
            ShowStatistics(products);
            break;
        case "6":
        case "exit":
            // Changing this to false ends the while loop.
            isRunning = false;
            Console.WriteLine("Appication closed.");
            break;
        default:
            Console.WriteLine("Invalid choice. Please choose 1-6.");
            break;
    }

    if (isRunning)
    {
        // Wait for the user before showing the menu again.
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}

// Clears the terminal before the next menu is displayed.
static void ClearConsole()
{
    Console.Clear();
}

// Displays the available actions.
static void ShowMenu()
{
    Console.WriteLine("========================================");
    Console.WriteLine("       PRODUCT INVENTORY SYSTEM");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Search Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.Write("Select option: ");
}

// Reads a product name and adds it if the product is valid and does not exist.
static void AddProduct(List<string> products)
{
    Console.WriteLine();
    Console.Write("Enter product: ");

    // Read the product name and remove spaces at the beginning and end.
    string productName = (Console.ReadLine() ?? "").Trim();

    // Do not allow the user to add an empty product name.
    if (string.IsNullOrWhiteSpace(productName))
    {
        Console.WriteLine("ERROR: Input cannot be empty.");
        return;
    }

    if (!IsValidProduct(productName))
    {
        return;
    }

    // Start by assuming that the product is not already in the list.
    bool productAlreadyExists = false;

    // Check every product that has already been added.
    foreach (string product in products)
    {
        // Compare lower-case text so ABC-200 and abc-200 count as the same product.
        if (product.ToLower() == productName.ToLower())
        {
            productAlreadyExists = true;
        }
    }

    if (productAlreadyExists)
    {
        // Stop here so the duplicate product is not added to the list.
        Console.WriteLine("WARNING: Product already exists.");
        return;
    }

    // Add the product in upper-case so all products have the same format.
    products.Add(productName.ToUpper());
    Console.WriteLine();
    Console.WriteLine("Product added successfully.");
}

// Checks that a product has letters before the dash and a number from 200 to 500.
static bool IsValidProduct(string product)
{
    // Split the product into a name part and a number part using the dash.
    string[] parts = product.Split('-');

    // A valid product must have exactly two parts.
    if (parts.Length != 2)
    {
        Console.WriteLine("ERROR: Product must contain a dash (-).");
        return false;
    }

    if (string.IsNullOrWhiteSpace(parts[0]))
    {
        Console.WriteLine("ERROR: The left side must contain letters only.");
        return false;
    }

    // Check each character in the name part.
    foreach (char letter in parts[0])
    {
        if (!char.IsLetter(letter))
        {
            Console.WriteLine("ERROR: The left side must contain letters only.");
            return false;
        }
    }

    // TryParse checks that the number part contains a valid whole number.
    if (!int.TryParse(parts[1], out int productNumber))
    {
        Console.WriteLine("ERROR: The right side must contain numbers only.");
        return false;
    }

    if (productNumber < 200 || productNumber > 500)
    {
        Console.WriteLine("ERROR: The numeric part must be between 200 and 500.");
        return false;
    }

    // All product rules were passed.
    return true;
}

// Shows all products in alphabetical order.
static void ViewProducts(List<string> products)
{
    // There is nothing to display when the list has no products.
    if (products.Count == 0)
    {
        Console.WriteLine("The product list is empty.");
        return;
    }

    // Sort the list before displaying it.
    products.Sort();
    Console.WriteLine();
    Console.WriteLine("Products:");

    foreach (string product in products)
    {
        // Display one product on each line.
        Console.WriteLine("- " + product);
    }
}

// Searches for products that contain the text entered by the user.
static void SearchProduct(List<string> products)
{
    Console.WriteLine();
    Console.Write("Search product: ");
    // Read the text that should be searched for.
    string searchText = (Console.ReadLine() ?? "").Trim();
    bool productFound = false;

    Console.WriteLine();
    Console.WriteLine("Results:");

    foreach (string product in products)
    {
        // Contains also finds products when the search text is only part of the name.
        if (product.ToLower().Contains(searchText.ToLower()))
        {
            Console.WriteLine("- " + product);
            productFound = true;
        }
    }

    if (!productFound)
    {
        Console.WriteLine("No matching products found.");
    }
}

// Deletes the first product that matches the entered name.
static void DeleteProduct(List<string> products)
{
    Console.WriteLine();
    Console.Write("Enter product to delete: ");
    // Read the name of the product that should be removed.
    string productName = (Console.ReadLine() ?? "").Trim();

    // Use the position in the list because RemoveAt removes an item by its position.
    for (int i = 0; i < products.Count; i++)
    {
        if (products[i].ToLower() == productName.ToLower())
        {
            // Remove the matching product and stop searching.
            products.RemoveAt(i);
            Console.WriteLine();
            Console.WriteLine("Product removed successfully.");
            return;
        }
    }

    Console.WriteLine("Product not found.");
}

// Displays simple information about the current list.
static void ShowStatistics(List<string> products)
{
    Console.WriteLine();
    Console.WriteLine("Statistics:");

    if (products.Count == 0)
    {
        Console.WriteLine("There are no products yet.");
        return;
    }

    // These variables will be used to calculate information about the products.
    int lowestNumber = 0;
    int highestNumber = 0;
    int totalNumber = 0;
    int productNumberCount = 0;

    foreach (string product in products)
    {
        // Get the number part from the product, for example 200 from ABC-200.
        string[] parts = product.Split('-');
        int.TryParse(parts[1], out int productNumber);

        // The first product becomes the starting lowest and highest number.
        if (productNumberCount == 0 || productNumber < lowestNumber)
        {
            lowestNumber = productNumber;
        }

        if (productNumberCount == 0 || productNumber > highestNumber)
        {
            highestNumber = productNumber;
        }

        totalNumber += productNumber;
        productNumberCount++;
    }

    // Convert the total to double so the average can include decimals.
    double averageNumber = (double)totalNumber / productNumberCount;

    Console.WriteLine("- Total Products: " + products.Count);
    Console.WriteLine("- Lowest Number: " + lowestNumber);
    Console.WriteLine("- Highest Number: " + highestNumber);
    Console.WriteLine("- Average Number: " + averageNumber.ToString("0"));
}

