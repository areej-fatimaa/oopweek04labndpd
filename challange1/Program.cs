  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challange1
{
    class Program
    {
        static List<Student> studentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();
        static void Main(string[] args)
        {
            List<Student> student = new List<Student>();
            List<string> preference = new List<string>();
            List<DegreeProgram> degrees = new List<DegreeProgram>();
            int choice = 0;
            while(choice!=8)
            {
                Header();
                choice = Menu();
                if (choice == 1)
                {
                    if (programList.Count > 0)
                    {
                        Student s = InputAddStudent();
                        AddIntoStudentList(s);
                    }

                }
                else if (choice == 2)
                {
                    DegreeProgram pro = AddDegreeProgram();
                    AddIntoDegreeList(pro);
                }
                else if(choice==3)
                {
                    List<Student> sortedList = new List<Student>();
                    sortedList = SortStudentByMerit();
                    GiveAdmission(sortedList);
                    PrintStudent();
                }
                else if(choice==4)
                {
                    ViewAllRegisteredStudent();
                }
                else if(choice==5)
                {
                    string degName;
                    Console.WriteLine("Enter degree name:");
                    degName = Console.ReadLine();
                    ViewStudentInDegree(degName);
                }
                else if(choice==6)
                {
                    Console.WriteLine("Enter student name");
                    string name = Console.ReadLine();
                    Student s = StudentPresent(name);
                    if(s!=null)
                    {
                        ViewSubjects(s);
                        RegisterSubjects(s);
                    }
                }
                else if(choice==7)
                {
                    CalculateFeesForAll();
                }
            }
            
        }
            static void Header()
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("                      UMAS                           ");
            Console.WriteLine("*****************************************************");
        }
        static int Menu()
        {
            Console.WriteLine("1.Add student");
            Console.WriteLine("2.Add degree program");
            Console.WriteLine("3.Generate merit");
            Console.WriteLine("4.View registered students");
            Console.WriteLine("5.View students of specific program");
            Console.WriteLine("6.Register subjects for specific student");
            Console.WriteLine("7.Calculate fees for all registered students");
            Console.WriteLine("8.Exit");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static DegreeProgram AddDegreeProgram()
        {
            Console.WriteLine("Enter degree name:");
            string degName=Console.ReadLine();
            Console.WriteLine("Enter degree duration:");
            int degreeDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter seats for degree:");
            int degSeats= int.Parse(Console.ReadLine());
           
            DegreeProgram program = new DegreeProgram(degName, degreeDuration, degSeats);
            Console.WriteLine("How many subjects you want to enter");
            int count = int.Parse(Console.ReadLine());
            for(int i=0;i<count;i++)
            {
                program.AddSubject(InputAddSubject());
            }
            return program;
        }  
        static void AddIntoDegreeList(DegreeProgram deg)
        {
            programList.Add(deg);
        }
        static Subject InputAddSubject()
        {
            Console.WriteLine("Enter subject code:");
            string subCode = Console.ReadLine();
            Console.WriteLine("Enter subject type:");
            string subType = Console.ReadLine();
            Console.WriteLine("Subject credit hours:");
            int creditHour = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter subject fee:");
            int subFee = int.Parse(Console.ReadLine());
            Subject sub = new Subject(subCode, subType, creditHour, subFee);
            return sub;
        }
        static Student InputAddStudent()
        {
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.WriteLine("Enter student name:");
            string name= Console.ReadLine();
            Console.WriteLine("Enter Age:");
            string age = Console.ReadLine();
            Console.WriteLine("Enter FSC marks:");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ECAT marks:");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Available degree programs");
            ViewDegreeProgram();
            Console.WriteLine("How many preferences you want to enter");
            int count = int.Parse(Console.ReadLine());
            for(int i=0;i<count;i++)
            {
                string degName = Console.ReadLine();
                bool flag = CheckDegreeName(degName, preferences);
                if (flag==false)
                {
                    Console.WriteLine("Enter valid degree name");
                }
            }
            Student stu = new Student(name, age, fscMarks, ecatMarks,preferences);
            return stu;
        }
        static bool CheckDegreeName(string degName,List<DegreeProgram>pref)
        {
            bool flag = false;
            foreach(DegreeProgram dp in programList)
            {
                if(degName==dp.Name&&!(pref.Contains(dp)))
                    {
                    pref.Add(dp);
                    flag = true;
                }
            }
            return flag;
        }
        static void AddIntoStudentList(Student s)
        {
            studentList.Add(s);
        }
        static void ViewDegreeProgram()
        {
            foreach(DegreeProgram dp in programList)
            {
                Console.WriteLine(dp.Name);
            }
        }
        static void ViewSubjects(Student stu)
        {
            if(stu.regDegree!=null)
            {
                Console.WriteLine("Sub code\tSub type");
                foreach(Subject sub in stu.regDegree.subjects)
                {
                    Console.WriteLine(sub.subCode+"\t"+sub.subType);
                }
            }
        }
        static Student StudentPresent(string name)
        {
            foreach(Student stu in studentList)
            {
                if(name==stu.Name&&stu.regDegree!=null)
                {
                    return stu;
                }
            }
            return null;
        }
        static void CalculateFeesForAll()
        {
            foreach(Student stu in studentList)
            {
                if(stu.regDegree!=null)
                {
                    Console.WriteLine(stu.Name + "has" + stu.CalculateFee() + "fees");
                }
            }
        }
        static void RegisterSubjects(Student stu)
        {
            Console.WriteLine("Enter how many subjects you want to register");
            int count = int.Parse(Console.ReadLine());
            for(int i=0;i<count;i++)
            {
                Console.WriteLine("Enter the subject code");
                string code = Console.ReadLine();
                bool flag = false;
                foreach(Subject sub in stu.regDegree.subjects)
                {
                    if(code==sub.subCode&&!(stu.regSubject.Contains(sub)))
                    {
                        stu.RegStudentSubject(sub);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter valid course");
                    i--;
                }
            }
        }
        static List<Student> SortStudentByMerit()
        {
            List < Student > sortedList = new List<Student>(); 
            foreach(Student stu in studentList)
            {
                stu.CalculateMerit();
            }
            sortedList = studentList.OrderByDescending(s => s.merit).ToList();
            return sortedList;
        }
        static void GiveAdmission(List<Student> sortedList)
        {
           foreach(Student stu in sortedList)
            {
                foreach(DegreeProgram deg in stu.preference)
                {
                    if (deg.Seats > 0&&stu.regDegree==null)
                    {
                        stu.regDegree = deg;
                        deg.Seats--;
                        break;
                    }
                }
               
            }
        }
        static void PrintStudent()
        {
            foreach(Student stu in studentList)
            {
                if(stu.regDegree!=null)
                {
                    Console.WriteLine(stu.Name+" got admission in "+stu.regDegree.Name);
                }
                else
                {
                    Console.WriteLine(stu.Name + " did not get admission");
                }
            }
        }
        static void ViewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tECAT\tAge");
            foreach(Student stu in studentList)
            {
                if(degName==stu.regDegree.Name)
                {
                    Console.WriteLine(stu.Name+"\t"+stu.FscMarks+"\t"+stu.EcatMarks+"\t"+stu.Age);
                }
            }
        }
        static void ViewAllRegisteredStudent()
        {
            Console.WriteLine("Name\tFSC\tECAT\tAge");
            foreach(Student stu in studentList)
            {
                if(stu.regDegree!=null)
                {
                    Console.WriteLine(stu.Name + "\t" + stu.FscMarks + "\t" + stu.EcatMarks + "\t" + stu.Age);
                }
            }
        }
    }
}
