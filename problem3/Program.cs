using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer cust = new Customer("Ali", "mianwali", "12345678");
            int choice = 0;
            float tax = 0;
            while (choice!=4)
            {
                choice = TakeChoice();
                if(choice==1)
                {
                    Product pro= ProductInput();
                    float calculateTax = pro.CalculateTax();
                    tax = tax + calculateTax;
                    cust.AddProduct(pro);
                }
                if(choice==2)
                {
                    Console.Clear();
                    Console.WriteLine(cust.CustomerName + "\t\t" + cust.CustomerAddress + "\t\t" + cust.ContactNo + "\t\t");
                    foreach (Product pro in cust.products)
                    {
                        Console.WriteLine(pro.Name);
                    }
                    Console.ReadKey();
                }
                if(choice==3)
                {
                    if (cust.products.Count > 0)
                    {
                        Console.WriteLine("Total tax on purchased products is:" + tax);
                    }
                    else
                    {
                        Console.WriteLine("Products are not purchased yet!");
                        Console.ReadKey();
                    }
                }
            }
           
        }
        static int TakeChoice()
        {
            Console.WriteLine("1.Add Product");
            Console.WriteLine("2.Total purchases");
            Console.WriteLine("3.Tax on purchsed products");
            Console.WriteLine("Enter choice");
            int choice=int.Parse(Console.ReadLine());
            return choice;
        }
        static Product  ProductInput()
        {
            Console.WriteLine("Enter name of product:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter category of product:");
            string category = Console.ReadLine();
            Console.WriteLine("Enter price of product:");
            int price= int.Parse(Console.ReadLine());
            Product pro = new Product(name,category,price);
            return pro;
        }
    }
}
