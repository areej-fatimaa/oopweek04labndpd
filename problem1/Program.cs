using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{
        public class Program
    {
        static void Main(string[] args)
        {
            List<Student> stu = new List<Student>();
            int option=0;
            
            while (option!=3)
            {
                option = int.Parse(TakeOptions());
                if (option==1)
                {
                    Console.Clear();
                    stu.Add(TakeInput());
                }
                if(option==2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter name of student whose merit is to be calculated:");
                    string name= Console.ReadLine();
                   float merit=CalculateMerit(name,stu);
                    Console.WriteLine("Merit of " + name + "is " + merit);
                }
                if(option==3)
                {
                    Console.Clear();
                    Console.WriteLine("Enter name of student whose elegibility is to be checked:");
                    string name = Console.ReadLine();
                    Elegibility(CalculateMerit(name, stu),name,stu);
                    Console.ReadKey();
                }
                else if(option==4)
                {
                    Console.WriteLine("Enter valid choice!");
                    break;
                }
            }
            

        }
        static string TakeOptions ()
        {
            Console.WriteLine("1.Enter information");
            Console.WriteLine("2.Calculate merit");
            Console.WriteLine("3.Eligibal for scholorship or not");
             Console.WriteLine("Enter your choice:");
                string choice =Console.ReadLine();
            return choice;


        }
        static Student TakeInput()
        {
            Console.WriteLine("Enter your name:");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Roll no:");
            int rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Entar your CGPA:");
            float CGPA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter matric marks:");
            int matricMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fsc marks: ");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ecat marks");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter address:");
            string homeTown = Console.ReadLine();
            bool isHostellite = false;
            bool isScholorship = false; 
            while (true)
            {
                Console.WriteLine("Hostellite or not(yes/no):");
                string hostellite =Console.ReadLine();
                hostellite.ToUpper();
                if(hostellite=="YES"||hostellite=="NO")
                {
                    if(hostellite=="YES")
                    {
                        isHostellite = true;
                        break;
                    }
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Taking scholorship or not(yes/no):");
                string scholorship = Console.ReadLine();
                scholorship.ToUpper();
                if (scholorship == "YES" || scholorship == "NO")
                {
                    if (scholorship == "YES")
                    {
                        isScholorship = true;
                    }
                    break;
                }
            }
            Student info = new Student(name, rollNo, CGPA, matricMarks, fscMarks, ecatMarks, homeTown, isHostellite,isScholorship);
            return info;
        }
          static float CalculateMerit(string name, List<Student>stu)
        {
            float merit=0;
            for (int i=0;i<stu.Count;i++)
            {
                if(name== stu[i].Name)
                {
                    merit = (60.0F / 100.0F) * (stu[i].FscMarks) + (40.0F/ 100.0F) * (stu[i].EcatMarks);            
                    return merit;
                }
            }
            return merit;
        }
       static void  Elegibility(float merit,string name,List<Student> stu)
        {
            for (int i = 0; i < stu.Count; i++)
            {
                if (name == stu[i].Name)
                {
                    if (merit > 80.0 && stu[i].IsHostellite == true)
                    {
                        Console.WriteLine(name + "is eligible for scholorship");
                    }
                    else
                    {
                        Console.WriteLine(name + "is not eligible for scholorship");
                    }
                }
            }
            
        }

    }
}
