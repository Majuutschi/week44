

bool keepGoing = true;
bool addMore = true;
string choice = "";


// The menu
void ShowMenu()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("To enter a new product - enter: \"P\" | To search fort product - enter \"S\" | to quit - enter \"Q\"");

    Console.ResetColor();
    choice = Console.ReadLine();
}

// Making the list and adding products
List<Product> products = new List<Product>();
void AddMoreProducts()
{
    while (addMore)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("To Enter a new product - follow the steps | To quit - enter \"Q\"");

        Console.ResetColor();

        Console.Write("Enter a Category: ");
        string category = Console.ReadLine();

        if (category.ToLower().Trim() == "q")
        {
            break;
        }
        else if(category.Trim() == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You must type at least one character.");
            Console.ResetColor();
            break;
        }

        Console.Write("Enter a Product Name: ");
        string productName = Console.ReadLine();

        if (productName.Trim() == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You must type at least one character.");
            Console.ResetColor();
            break;
        }

        Console.Write("Enter a Price: ");
        int price = Convert.ToInt32(Console.ReadLine());

        if (price <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You must type a valid price.");
            Console.ResetColor();
            break;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product was successfully added!");

        Console.ResetColor();
        Console.WriteLine("--------------------------------------------------");

        products.Add(new Product(category, productName, price));
    }

    Console.WriteLine("--------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price");
    Console.ResetColor();

    List<Product> sortedList = products.OrderBy(product => product.Price).ToList();
    foreach (Product product in sortedList)
    {
        Console.WriteLine(product.Category.PadRight(20) + product.ProductName.PadRight(20) + product.Price);
    }

    int sumOfList = products.Sum(product => product.Price);


    Console.WriteLine("");
    Console.WriteLine("".PadRight(20) + "Total amount:".PadRight(20) + sumOfList);
    Console.WriteLine("--------------------------------------------------");
    
    ShowMenu();
}
// Call AddMoreProducts the first time
AddMoreProducts();

// Search for product name
void SearchProducts() {
    Console.Write("Enter a Product Name: ");
    string searchName = Console.ReadLine();

    List<Product> searchedList = products.OrderBy(product => product.Price).ToList();
    foreach (Product product in searchedList)
    {
        if (product.ProductName == searchName)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(product.Category.PadRight(20) + product.ProductName.PadRight(20) + product.Price);
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(product.Category.PadRight(20) + product.ProductName.PadRight(20) + product.Price);
        }
    }
    Console.WriteLine("--------------------------------------------------");
    ShowMenu();
}

// Choices on the menu
while(keepGoing)
{
    switch (choice.ToLower().Trim())
    {
        case ("p"):
            AddMoreProducts();
            break;

        case("s"):
            SearchProducts();
            break;

        case ("q"):
            keepGoing = false;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not a valid choice");
            Console.ResetColor();
            ShowMenu();
            break;
    }
}


 




class Product
{
    public Product(string category, string productName, int price)
    {
        Category = category;
        ProductName = productName;
        Price = price;
    }

    public string Category { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }


}

class ProductMenu
{
    public ProductMenu(string choice, string searchName)
    {
        Choice = choice;
        SearchName = searchName;
    }

    public string Choice { get; set; }
    public string SearchName { get; set; }

}




