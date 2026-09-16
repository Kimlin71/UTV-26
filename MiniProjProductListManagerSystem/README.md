# MiniProjProductListManagerSystem

## My MiniProjects in the C# Training

### Notes

This project was created during the second week of C# training.

Some files in this repository may be instructor reference examples used to explain concepts. My own project is described below.

## Product List Manager

A simple C# console application created as a beginner-level mini project.

### Description

This project allows the user to manage a list of product names through a simple console menu. The program continues running until the user chooses **Exit**.

A valid product name must:

- Contain a dash (`-`)
- Include letters before the dash
- Include a number between `200` and `500` after the dash

Example of a valid product name:

```text
ABC-200
```

### Features

- Enter product names from the console
- Add and validate product names
- Prevent empty or incorrectly formatted input
- Prevent duplicate products, regardless of uppercase or lowercase letters
- Store valid products in uppercase format
- View products in alphabetical order
- Search for full or partial product names
- Delete a product
- Display basic statistics:
  - Total number of products
  - Lowest product number
  - Highest product number
  - Average product number
- Continue using the application through a menu-based interface

### This Project Was Built to Practise

- C# basics
- User input
- Loops and conditions
- Lists
- Input validation
- String handling
- Sorting data in C#
- Methods
- `switch` statements
- Basic statistics
- Console user interface design
- Clean and readable code

### Technologies

- C#
- .NET 10
- Console Application
- Visual Studio Code on macOS

## How to Install, Set Up, and Run the Project

### Prerequisites

Before running the project, install:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio Code](https://code.visualstudio.com/)
- The **C# Dev Kit** extension in Visual Studio Code
- Git, if you want to clone the repository

Check that .NET is installed by opening a terminal and running:

```bash
dotnet --version
```

### 1. Get the Project

Clone the repository:

```bash
git clone <repository-url>
```

Then open the project folder:

```bash
cd MiniProjProductListManagerSystem
```

If the project is already stored on your computer, open its folder directly in Visual Studio Code.

### 2. Open the Project in Visual Studio Code

From the project folder, run:

```bash
code .
```

Alternatively, open Visual Studio Code and select **File > Open Folder**, then choose the project folder.

### 3. Restore the Project

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
3. **Search Product**: Search using a full or partial product name.
4. **Delete Product**: Remove a product by entering its complete name.
5. **Statistics**: Display the total, lowest, highest, and average product numbers.
6. **Exit**: Close the application.

## Project Scope and Status

This is a beginner-level training project created to practise fundamental C# programming concepts.

The project covers Levels 1–4 of the checkpoint assignment. Level 5, **Advanced Product Management System**, was not implemented.

The following optional Level 5 features are therefore outside the scope of this project:

- Automatically generated product IDs
- Editing existing products
- Deleting products by product ID
- Saving and loading products from a file
- The complete Level 5 statistics dashboard
- The complete advanced menu-based management system
