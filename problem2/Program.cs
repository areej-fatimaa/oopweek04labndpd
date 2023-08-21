using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book("ALI",288,200,300);
            int choice = 0;
            while(choice!=7)
            {
                Console.Clear();
                choice = TakeChoice();
                if(choice==1)
                {
                    Console.WriteLine("How many chapters you want to add");
                    int chap=int.Parse(Console.ReadLine());
                    for(int i=0;i<chap;i++)
                    {
                        string chapName = AskChapName();
                        b.AddChapters(chapName);
                    }
                }
                if(choice==2)
                {
                    Console.WriteLine("Enter chapter no you want to read:");
                    int chapNo = int.Parse(Console.ReadLine());
                    string chapter = b.GetChap(chapNo);
                    Console.WriteLine(chapter);
                    Console.ReadLine();
                }
                if(choice==3)
                {
                   int bookMark= b.GetBookMark();
                    Console.WriteLine(bookMark);
                    Console.ReadKey();
                }
                if(choice==4)
                {
                    Console.WriteLine("Enter bookmark you want to add:");
                    int bookmark=int.Parse(Console.ReadLine());
                    b.SetBookMark(bookmark);
                }
                if(choice==5)
                {
                    int bookprice = b.GetBookPrice();
                    Console.WriteLine(bookprice);
                    Console.ReadKey();
                }
                if(choice==6)
                {
                    Console.WriteLine("Enter price you want to set:");
                    int bookprice = int.Parse(Console.ReadLine());
                    b.SetBookPrice(bookprice);
                }
            }

        }
        static int TakeChoice()
        {
            Console.WriteLine("1.Add chapters");
            Console.WriteLine("2.Get chapter");
            Console.WriteLine("3.Get bookmark");
            Console.WriteLine("4.Set bookmark");
            Console.WriteLine("5.Get bookprice");
            Console.WriteLine("6.Set bookprice");
            Console.WriteLine("Enter your choice");
            int choice=int.Parse(Console.ReadLine());
            return choice;
        }
        static string AskChapName()
        {
            Console.WriteLine("Enter chapter name:");
            string chapName=Console.ReadLine();
            return chapName;
        }
    }
}
