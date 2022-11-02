
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To Enter a new product - follow the steps | To quit - enter \"Q\"");

Console.ResetColor();

List<Product> products = new List<Product>();

while (true)
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

Console.ReadLine();
Console.WriteLine("");
Console.WriteLine("".PadRight(20) + "Total amount:".PadRight(20) + sumOfList);
Console.WriteLine("--------------------------------------------------");

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("To enter a new product - enter: \"P\" | To search fort product - enter \"S\" | to quit - enter \"Q\"");

Console.ResetColor();
string choice = Console.ReadLine();

if (choice.ToLower().Trim() == "s")
{
    Console.Write("Enter a Product Name: ");
    string searchName = Console.ReadLine();

    // string searchMatch = searchName.Where(product => product.ProductName.Contains(searchName));

    
}


Console.ReadLine();

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




