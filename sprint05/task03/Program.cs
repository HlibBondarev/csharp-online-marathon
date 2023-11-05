namespace task03
{
    //Please create a method TotalPrice(ILookup<string, Product> lookup) in which print(Name + " " + Price) from one category and
    //total price for products from these categories(Key + " " + totalPriceForCategory)
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();
            products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
            products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
            products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
            products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
            products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });
            ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
            TotalPrice(lookup);
            Console.ReadKey();
        }

        public static void TotalPrice(ILookup<string, Product> lookup)
        {
            // Iterate through each IGrouping in the Lookup and output the contents.
            foreach (IGrouping<string, Product> packageGroup in lookup)
            {
                decimal totalPriceForCategory = 0;
                // Iterate through each value in the IGrouping and print its value of Price.
                foreach (Product product in packageGroup)
                {
                    Console.WriteLine($"{product.Name} {product.Price}");
                    totalPriceForCategory += product.Price;
                }
                // Print the key value of the IGrouping and totalPriceForCategory.
                Console.WriteLine($"{packageGroup.Key} {totalPriceForCategory}");              
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}