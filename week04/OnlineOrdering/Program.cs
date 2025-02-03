class Program
{
    static void Main()
    {
     
        Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Vancouver", "BC", "Canada");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

     
        Product product1 = new Product("Laptop", "P001", 1000, 2);
        Product product2 = new Product("Mouse", "P002", 20, 1);
        Product product3 = new Product("Keyboard", "P003", 50, 1);

 
        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product2, product3 }, customer2);

      
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackagingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackagingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}