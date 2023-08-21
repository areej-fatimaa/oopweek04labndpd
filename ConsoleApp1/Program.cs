using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ship = new List<Ship>();
            int choice = 0;
            while(choice!=5)
            {
                choice = Menu();
                if(choice==1)
                {
                    Ship s=AddShip();
                    ship.Add(s);
                }
                if(choice==2)
                {
                    Console.WriteLine("Enter ship ID");
                    string ID = Console.ReadLine();
                   foreach(Ship sh in ship)
                    {
                        if(sh.ShipId==ID)
                        {
                            Console.WriteLine(sh.Longitude.ReturnAngle()+ " and "+ sh.Latitude.ReturnAngle());
                        }
                    }
                }
                if(choice==3)
                {
                    Console.WriteLine("Enter the ship Latitude(enter degree and minute symbol too):");
                    string lat=Console.ReadLine();
                    Console.WriteLine("Enter the ship Longitude(enter degree and minute symbol too):");
                    string lon = Console.ReadLine();
                    foreach(Ship sh in ship)
                    {
                        if(sh.Longitude.ReturnAngle()==lon && sh.Latitude.ReturnAngle()==lat)
                        {
                            Console.WriteLine(sh.ShipId);
                        }
                    }
                }
                if(choice==4)
                {
                    Console.WriteLine("Enter ship id whose position you want to change:");
                    string ID=Console.ReadLine();
                    foreach(Ship sh in ship)
                    {
                        if(sh.ShipId==ID)
                        {
                            Console.WriteLine("Enter ship Latitude:");
                            Console.WriteLine("Enter Latitude's Degree:");
                            int degree1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Latitude's Direction:");
                            char dir1 = char.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Latitude's Minutes:");
                            float min1 = float.Parse(Console.ReadLine());
                            Console.WriteLine("Enter ship Longitude:");
                            Console.WriteLine("Enter Longitude,s Degree:");
                            int degree2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Longitude's Minutes:");
                            float min2 = float.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Longitude's Direction:");
                            char dir2 = char.Parse(Console.ReadLine());
                            Angle longitude = new Angle(degree2, min2, dir2);
                            Angle latitude = new Angle(degree1, min1, dir1);
                            sh.Latitude = latitude;
                            sh.Longitude = longitude;
                        }
                    }
                }
            }
        }
        static int Menu()
        {
            Console.WriteLine("1.Add ship");
            Console.WriteLine("2.View ship position");
            Console.WriteLine("3.View ship serial number");
            Console.WriteLine("4.Change ship position");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Enter your choice");
            int choice=int.Parse(Console.ReadLine());
            return choice;
        }
        static void Input()
        {
            Console.WriteLine("Enter Degree");
            int degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter minutes");
            float min = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter direction");
            char dir=char.Parse(Console.ReadLine());
            Angle angle = new Angle(degree, min, dir);
        }
        static Ship AddShip()
        {
            Console.WriteLine("Enter ship Number:");
            string shipId = Console.ReadLine();
            Console.WriteLine("Enter ship Latitude:");
            Console.WriteLine("Enter Latitude's Degree:");
            int degree1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude's Direction:");
            char dir1 = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude's Minutes:");
            float min1=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter ship Longitude:");
            Console.WriteLine("Enter Longitude,s Degree:");
            int degree2=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude's Minutes:");
            float min2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude's Direction:");
            char dir2 = char.Parse(Console.ReadLine());
            Ship ship = new Ship(shipId, degree2, min2, dir2, degree1, min1, dir1);
                return ship; 
        }
    }
}
