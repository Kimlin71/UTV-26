Console.WriteLine("Conditions, Arrays, Loops and Lists");
/*
// Conditions
int number = 10;
if (number < 0)
{
    Console.WriteLine($"The number is negative: {number}"); // interpolation
}
else if (number == 0)
{
    Console.WriteLine("The number is zero.");
}
else
{
    Console.WriteLine($"The number is positive: {number}");
}

// Ternary operator
string parity = (number % 2 == 0) ? "even" : "odd";
Console.WriteLine($"The number is {parity}.");


// Switch statement

Console.WriteLine("Enter a number (1, 2, or 3): ");
Console.WriteLine("1 - Add Product");
Console.WriteLine("2 - Search Product");
Console.WriteLine("3 - Delete Product");
Console.WriteLine("0 - Exit");

string userInput = Console.ReadLine();
switch (userInput)
{
    case "1":
        Console.WriteLine("Add Product");
        Functions.AddProduct();
        break;
    case "2":
        Console.WriteLine("Search Product");
        Functions.SearchProduct();
        break;
    case "3":
        Console.WriteLine("Delete Product");
        Functions.DeleteProduct();
        break;
    default:
        Console.WriteLine("Invalid option.");
        break;
}
*/
//void AddProduct()
//{
//    Console.WriteLine("Adding product...");
//    // Add product logic here
//}

//void SearchProduct()
//{
//    Console.WriteLine("Searching product...");
//    // Search product logic here
//}

//void DeleteProduct()
//{
//    Console.WriteLine("Deleting product...");
//    // Delete product logic here
//}

/*
 * Arrays
 * An array is a collection of items stored at contiguous memory locations.
 * https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-10.0
*/

// Declaring an array 
string[] myStr;
myStr = new string[3]; // allocating memory for 3 strings
myStr[0] = "Hello";

string[] myStr2 = {"a", "b", "c", "1" }; // declaring and initializing an array
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables
var myArr = new int[] { 1, 2, 3, 4, 5 }; // declaring and initializing an array with var
int[] myArr1 = [ 1, 2, 3, 4, 5 ];

int[] numbersArray = {10, 1, 100, -4, 20, 30, 40, 50 };
Console.WriteLine("Number of elements in the array: " + numbersArray.Length);
Console.WriteLine("First element: " + numbersArray[0]);
Console.WriteLine("Last element: " + numbersArray[numbersArray.Length - 1]);

// Modifying an array element
numbersArray[2] = 35; // changing the third element from 30 to 35

for(int i = 0; i < numbersArray.Length; i++)
{
    Console.WriteLine($"Element at index {i}: {numbersArray[i]}");
}

foreach (var i in numbersArray)
{
    Console.WriteLine("Element: " + i);
}


// Array can be sorted
Console.WriteLine("Sorted array:");
Array.Sort(numbersArray);
foreach (var num in numbersArray)
{
    Console.WriteLine("Element: " + num);
}

/*
 * Lists   
 * The List<T> is a collection of strongly typed objects
   that can be accessed by index and having methods for sorting, searching, and modifying list.
 * List can contain string, int, double etc values  also can contain objects

 * It is different from the arrays.
 * A List<T> can be resized dynamically but arrays cannot.
 * In general, it’s better to use lists in C# 
   because lists are far more easily sorted, searched through, and manipulated in C# than arrays. 
 * https://www.tutorialsteacher.com/csharp/csharp-list
 * https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-10.0
 * 
*/

List<string> myList = new List<string> { "Apple", "Banana", "Cherry" };
var myList1 = new List<string> { "Dog", "Cat", "Elephant" };

var numbersList = new List<int> { 10, 20, 30, 40, 50, 1, 4 };


// Add, Insert, Remove
// Add appends an item to the end of the list
numbersList.Add(65); // adding 65 to the end of the list
Console.WriteLine("List after adding an element:");
foreach (var num in numbersList)
{
    Console.WriteLine("Element: " + num);
}

// Insert an item at a specific index
numbersList.Insert(2, 22); // inserting 22 at index 2
Console.WriteLine("List after inserting an element:");
foreach (var num in numbersList)
{
    Console.WriteLine("Element: " + num);
}

// Remove an item by value
numbersList.Remove(30); // removing 30 from the list
Console.WriteLine("List after removing an element:");
foreach (var num in numbersList)
{
    Console.WriteLine("Element: " + num);
}

// RemoveAt removes an item at a specific index
numbersList.RemoveAt(0); // removing the first element
Console.WriteLine("List after removing an element by index number:");
foreach (var num in numbersList)
{
    Console.WriteLine("Element: " + num);
}

Console.ReadLine();


