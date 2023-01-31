using System;
using System.Globalization;
using System.Collections.Generic;
using Exercise.Entities;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> product = new List<Product>();
            
            Console.Write("Enter the number of products: ");
            var n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Product #{i} data: ");

                Console.Write("Common, used or imported(c/u/i): ");
                var optionProduct = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Price: ");
                var price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(optionProduct == 'i' || optionProduct == 'I')
                {
                    Console.Write("Customs fee: ");
                    var customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    product.Add(new ImportedProduct(name, price, customFee));
                }
                else if(optionProduct == 'u' || optionProduct == 'U'){
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    var manufactureDate = DateTime.Parse(Console.ReadLine());

                    product.Add(new UsedProduct(name, price, manufactureDate));
                }
                else if(optionProduct == 'c' || optionProduct == 'C')
                {
                    product.Add(new Product(name, price));
                }
                else
                {
                    Console.WriteLine("Option does not exist...");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach (Product prod in product)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}