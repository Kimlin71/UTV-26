# MiniProjProductListManagerSystem

## My MiniProjects in the C# Training

### Notes

This project was created during the first week of C# training.

Some files in this repository may be instructor reference examples used to explain concepts. My own project is described below.

## Product List Manager

A simple C# console application created as a beginner-level mini project.

### Description

This project allows the user to manage a list of product names through a simple console menu. The program continues running until the user chooses **Exit**.

A valid product name must:

- Contain a dash (`-`)
- Include letters only before the dash
- Include a whole number between `200` and `500` after the dash

Example of a valid product name:

```text
ABC-200
```

### Features

- Enter product names from the console
- Add and validate product names
- Reject empty or incorrectly formatted input
- Prevent duplicate products, regardless of uppercase or lowercase letters
- Store valid products in uppercase format
- View products in alphabetical order
- Search by full or partial product name or product number
- Delete a product by entering its complete name
- Display basic statistics:
  - Total number of products
  - Lowest product number
  - Highest product number
  - Average product number
- Continue using the application through a menu-based interface
- Exit by selecting option `6` or entering `exit`

### This Project Was Built to Practise

- C# basics
- Variables and data types
- Console input and output
- Loops and conditional statements
- Lists and collections
- String handling
- Input validation
- `int.TryParse()`
- Sorting data in C#
- Searching and deleting list items
- Methods and modular programming
- `switch` statements
- Basic statistics
- Defensive programming
- Clean and readable code

### Technologies

- C#
- .NET 10
- Console Application
- Visual Studio Code on macOS

## How to Install, Set Up, and Run the Project

### Prerequisites

Install the following before running the project:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio Code](https://code.visualstudio.com/)
- The **C# Dev Kit** extension in Visual Studio Code
- Git, if you want to clone the repository

Confirm that .NET is installed by opening a terminal and running:

```bash
dotnet --version
```

### 1. Get the Project

Clone the repository:

```bash
git clone <repository-url>
```

Move into the project folder:

```bash
cd MiniProjProductListManagerSystem
```

If the project is already saved on your computer, open the existing project folder instead.

### 2. Open the Project in Visual Studio Code

From the project folder, run:

```bash
code .
```

Alternatively, open Visual Studio Code, select **File > Open Folder**, and choose the project folder.

### 3. Restore Dependencies

In the Visual Studio Code terminal, run:

```bash
dotnet restore
```

### 4. Build the Project

```bash
dotnet build
```

### 5. Run the Project

```bash
dotnet run
```

The application menu will appear in the terminal.

## How to Use the Application

Choose an option by entering its number:

1. **Add Product**: Add a product using the required format, for example `ABC-200`.
2. **View Products**: Display all saved products in alphabetical order.
3. **Search Product**: Search using a full or partial product name or number.
4. **Delete Product**: Remove a product by entering its complete name.
5. **Statistics**: Display the total, lowest, highest, and average product numbers.
6. **Exit**: Close the application.

After completing an action, press **Enter** to return to the main menu.

## Project Scope and Status

This project implements the functional requirements from Levels 1–4, including validation, duplicate prevention, a menu system, search, deletion, and basic statistics.

The optional **Save to File** feature from Level 4 was not implemented. Products are stored only while the application is running and are not saved after the application closes.

The solution uses a `List<string>` and separate methods. It does not use custom classes, LINQ, Regex, serialization, file handling, or unit tests.
