// 1. Create a string array
// 2. Add string elements to the array
// 3. User can enter elements from th console until they enter "exit"
// 4. Display the elements of the array

Console.WriteLine("Enter car names (type 'exit' to finish):");
string[] myCar = new string[10]; // Create a string array with a size of 10
int index = 0; // Initialize an index to keep track of the current position in the array

while (true)
{
    Console.Write("Enter a car brand: ");
    string data = Console.ReadLine() ?? "";
    if (data.ToLower().Trim() == "exit")
    {
        break; // exit the loop if the user types "exit"
    }

    myCar[index] = data;
    index++;
}
Array.Resize(ref myCar, index);

Console.WriteLine("My Cars -unordered list");
foreach (string car in myCar)
{
    Console.WriteLine(car);
}

// Create a copy of the array and sort it
var myCar2 = new string[myCar.Length];
myCar.CopyTo(myCar2,0);
Array.Sort(myCar2);
Console.WriteLine("My Cars -ordered list");
foreach (string car in myCar2)
{
    Console.WriteLine(car);
}



Console.ReadLine(); // Wait for user input before closing the console window