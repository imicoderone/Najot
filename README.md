# Najot

Najot is a .NET library for different UIs like Console etc.

## Installation

Use the package manager [nuget](https://www.nuget.org/) to install Najot.

```bash
nuget install Najot
```

## Usage

```csharp
using Najot.Console;

ConsoleApplication application = new ConsoleApplication();

// Application setup
application.Setup(() =>
{
    // Creating a menu that is the entry point to the application
    Menu mainMenu = new Menu();
    mainMenu.Title = "Main menu";

    // Creating a menu that has a parent menu as mainMenu
    Menu productsMenu = new Menu(mainMenu);
    productsMenu.Title = "Products";
    
    // Add command that opens another menu
    mainMenu.AddCommand("Products", productsMenu);

    // Add command that executes some action
    productsMenu.AddCommand("Add", () =>
    {
        // Some action
    });
    
    // return the menu to start from
    return mainMenu;
});

// Run application
application.Run();
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
