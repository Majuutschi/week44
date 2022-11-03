
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To Enter a new product - follow the steps | To quit - enter \"Q\"");

Console.ResetColor();

var keepGoing = true;
var addMore = true;
string choice = "";

void ShowMenu()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("To enter a new product - enter: \"P\" | To search fort product - enter \"S\" | to quit - enter \"Q\"");

    Console.ResetColor();
    choice = Console.ReadLine();
}

List<Product> products = new List<Product>();
void AddMoreProducts()
{
    while (addMore)
    {
        Console.Write("Enter a Category: ");
        string category = Console.ReadLine();

        if (category.ToLower().Trim() == "q")
        {
            break;
        }

        Console.Write("Enter a Product Name: ");
        string productName = Console.ReadLine();

        Console.Write("Enter a Price: ");
        int price = Convert.ToInt32(Console.ReadLine());

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
AddMoreProducts();


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


while(keepGoing)
{
    switch (choice.ToLower().Trim())
    {
        case ("p"):
            //addMore = true;
            AddMoreProducts();
            break;

        case("s"):
            SearchProducts();
            break;

        case ("q"):
            keepGoing = false;
            break;

        default:
            keepGoing = false;
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




