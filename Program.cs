// Display instructions to the user
Console.WriteLine("Enter product names.");
Console.WriteLine("Type 'exit' to finish.\n");

// bool running = true;
// while (running)
// {
//     // Switch Statement to display the menu options to the user
//     Console.WriteLine("1. Add Product");
//     Console.WriteLine("2. View Product");
//     Console.WriteLine("3. Search Product");
//     Console.WriteLine("4. Delete Product");
//     Console.WriteLine("5. Statistics");
//     Console.WriteLine("6. Exit");

//     // Read the user's choice
//     string choice = Console.ReadLine();

//     // Handle the user's choice using a Switch Statement
//     switch (choice)
//     {
//         case "1":
//             Functions.AddProduct(myList);
//             break;
//         case "2":
//             Functions.ViewProduct(myList);
//             break;
//         case "3":
//             Functions.SearchProduct(myList);
//             break;
//         case "4":
//             Functions.DeleteProduct(myList);
//             break;
//         case "5":
//             Functions.Statistics(myList);
//             break;
//         case "6":
//             running = false;  // Exit the loop and end the program
//             break;
//         default:
//             Console.WriteLine("Invalid option.");
//             break;
//     }
// }


// Create a list to store product names
List<string> myList = new List<string>();

// Loop to continuously ask for product input until user types 'exit'
while (true)
{
    // Prompt user to enter a product name
    Console.Write("Product: ");
    // Read user input and provide empty string as default if null
    string data = Console.ReadLine() ?? "";

    // Check if user wants to exit
    if (data.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        // Break out of the loop if 'exit' is typed
        break;
    }

    // Validate product using IsValidProduct method
    // Only add the product to the list if it passes validation
    if (IsValidProduct(data))
    {
        // Add the valid product to the list
        myList.Add(data);
    }
    //Add an empty raw after the error message to make it more readable
     else Console.WriteLine(); 
 }     
// Sort the product list alphabetically
myList.Sort();
// Display the sorted product list header
Console.WriteLine("\nSorted valid products:\n");

// Iterate through each product in the list and display it
foreach (string product in myList)
{
    Console.WriteLine("- " + product);
}

// Static method to validate product codes
// Returns true if the product code is valid, false otherwise
static bool IsValidProduct(string input)
{
    // Check if input is null, empty, or only whitespace
    if (string.IsNullOrWhiteSpace(input))
    {
        // Display error message
        Console.WriteLine("ERROR: Input cannot be empty.");
        return false;
    }

    // Split the input by dash to get two parts
    string[] parts = input.Split('-');
    // Verify that exactly two parts exist
    if (parts.Length != 2)
    {
        // Display error message
        Console.WriteLine("ERROR: Product must contain a dash (-).");
        return false;
    }

    // Check if the first part contains only letters using regex
    if (!System.Text.RegularExpressions.Regex.IsMatch(parts[0], @"^[a-zA-Z]+$"))
    {
        // Display error message
        Console.WriteLine("ERROR: The left side must contain letters only.");
        return false;
    }

    // Try to parse the second part as an integer
    if (!int.TryParse(parts[1], out int numericPart))
    {
        // Display error message
        Console.WriteLine("ERROR: The right side must contain numbers only.");
        return false;
    }

    // Check if the numeric part is within the valid range (200-500)
    if (numericPart < 200 || numericPart > 500)
    {
        // Display error message
        Console.WriteLine("ERROR: The numeric part must be between 200 and 500.");
        return false;
    }

    // If all validations pass, return true
    return true;
}

// Wait for the user to press any keyboard key before closing the console window.
Console.WriteLine("\nPress any key to continue...");
Console.ReadKey(true);
