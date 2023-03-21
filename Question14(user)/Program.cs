using System;
using System.Collections.Generic;

namespace ProductInventory
{
    // Product class implementing IEquatable interface
    public class Product : IEquatable<Product>
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public bool Equals(Product other)
        {
            if (other == null) return false;
            return (this.Id == other.Id && this.Price == other.Price);
        }
        public Product(string id, decimal price)
        {
            this.Id = id;
            this.Price = price;
        }

        public override int GetHashCode()
        {
            return (this.Id.GetHashCode() ^ this.Price.GetHashCode());
        }
    }

    // Inventory class with dictionary and total value properties
    public class Inventory
    {
        public Dictionary<Product, int> Products { get; } = new Dictionary<Product, int>();
        public decimal TotalValue { get; set; }

        // Event handler for defective products
        public event EventHandler<Product> ProductDefective;

        // Method to add a product to inventory
        public void AddProduct(Product product, int quantity)
        {
            if (Products.ContainsKey(product))
            {
                Products[product] += quantity;
            }
            else
            {
                Products[product] = quantity;
            }
            TotalValue += (product.Price * quantity);
        }

        // Method to remove a product from inventory
        public void RemoveProduct(Product product)
        {
            if (Products.ContainsKey(product))
            {
                int quantity = Products[product];
                TotalValue -= (product.Price * quantity);
                Products.Remove(product);
            }
        }

        // Method to update the quantity of a product in inventory
        public void UpdateProductQuantity(Product product, int newQuantity)
        {
            if (Products.ContainsKey(product))
            {
                int oldQuantity = Products[product];
                int deltaQuantity = newQuantity - oldQuantity;
                Products[product] = newQuantity;
                TotalValue += (product.Price * deltaQuantity);
            }
        }

        // Method to update the price of a product in inventory
        public void UpdateProductPrice(Product product, decimal newPrice)
        {
            if (Products.ContainsKey(product))
            {
                int quantity = Products[product];
                TotalValue -= (product.Price * quantity);
                product.Price = newPrice;
                TotalValue += (product.Price * quantity);
            }
        }

        // Method to mark a product as defective
        public void MarkProductAsDefective(Product product)
        {
            if (Products.ContainsKey(product))
            {
                if (ProductDefective != null)
                {
                    ProductDefective(this, product);
                }
            }
        }

        // Method to print inventory
        public void PrintInventory()
        {
            Console.WriteLine("Product\tQuantity\tPrice");
            foreach (var item in Products)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key.Id}\t{item.Value}\t\t{item.Key.Price:C}");
                }
            }
            Console.WriteLine($"Total Value: {TotalValue:C}");
        }

        // Method to handle defective products
        public void OnProductDefective(Product product)
        {
            if (ProductDefective != null)
            {
                ProductDefective(this, product);
            }
            RemoveProduct(product);
        }
    }
    // Example usage
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = new Inventory();

            while (true)
            {
                Console.WriteLine("Enter a command:");
                Console.WriteLine("1 - Add product");
                Console.WriteLine("2 - Remove product");
                Console.WriteLine("3 - Update product quantity");
                Console.WriteLine("4 - Update product price");
                Console.WriteLine("5 - Mark product as defective");
                Console.WriteLine("6 - Print inventory");
                Console.WriteLine("0 - Exit");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.WriteLine("Enter product id:");
                        var id = Console.ReadLine();
                        Console.WriteLine("Enter product price:");
                        var price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter product quantity:");
                        var quantity = int.Parse(Console.ReadLine());
                        inventory.AddProduct(new Product(id, price), quantity);
                        Console.WriteLine("Product added to inventory.");
                        break;
                    case "2":
                        Console.WriteLine("Enter product id:");
                        var removeId = Console.ReadLine();
                        inventory.RemoveProduct(new Product(removeId, 0));
                        Console.WriteLine("Product removed from inventory.");
                        break;
                    case "3":
                        Console.WriteLine("Enter product id:");
                        var updateId = Console.ReadLine();
                        Console.WriteLine("Enter new quantity:");
                        var newQuantity = int.Parse(Console.ReadLine());
                        inventory.UpdateProductQuantity(new Product(updateId, 0), newQuantity);
                        Console.WriteLine("Product quantity updated.");
                        break;
                    case "4":
                        Console.WriteLine("Enter product id:");
                        var updatePriceId = Console.ReadLine();
                        Console.WriteLine("Enter new price:");
                        var newPrice = decimal.Parse(Console.ReadLine());
                        inventory.UpdateProductPrice(new Product(updatePriceId, 0), newPrice);
                        Console.WriteLine("Product price updated.");
                        break;
                    case "5":
                        Console.WriteLine("Enter product id:");
                        var defectiveId = Console.ReadLine();
                        inventory.MarkProductAsDefective(new Product(defectiveId, 0));
                        Console.WriteLine("Product marked as defective.");
                        break;
                    case "6":
                        inventory.PrintInventory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}