using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BussinessApplicationCS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Admin> admin = new List<Admin>();
            List<Customers> customer = new List<Customers>();
           // List<Medicines> m = new List<Medicines>();
            Admin ad = new Admin();
            Customers cust = new Customers();
            Medicines med = new Medicines();
            ReadAdminfromFile(admin);
            ReadCustomerfromFile(customer);
            ReadInventoryDetailsFromFile(ad);
            int choice = 0;
            int checkADMS = 0;
            int checkCMS = 0;
            while (choice != 3) // loop for login
            {
                choice = LoginView();
                if (choice == 1) // choice 1 is for admin
                {
                    Console.Clear();
                    string role=InputSignIN(admin,customer);
                        if (role == "admin")
                        {
                            while (checkADMS != 5) // loop for checking admin options
                            {
                                checkADMS = AdminMainScreen();
                                if (checkADMS == 1)
                                {
                                    Console.Clear();
                                    CheckList(ad);
                                }
                                else if (checkADMS == 2)
                                {
                                    Console.Clear();
                                    UpdateList(ad);
                                    StoreInventoryInFileUpdate(ad);
                                }
                                else if (checkADMS == 3)
                                {
                                Console.Clear();
                                DeleteItems(ad);
                                StoreInventoryInFileUpdate(ad);
                            }

                            else if (checkADMS == 4)
                            {
                                Console.Clear();
                                CreateList(ad);
                                StoreInventoryInFileUpdate(ad);
                            }
                            }
                        }
                        else if (role == "customer")
                        {
                            checkCMS = 0;
                            while (checkCMS != 5) // loop for checking customer option
                            {
                                checkCMS = CustomerMainScreen();
                                if (checkCMS == 1)
                                {
                                    Console.Clear();
                                    ShowList(ad);
                                }
                                if(checkCMS==2)
                                {
                                Console.Clear();
                                AddToCart(cust, ad);
                                }
                                if(checkCMS==3)
                                {
                                CheckCart(cust);
                                }
                            if (checkCMS == 4)
                            {
                                RemoveMedFromCart(cust);
                            }
                            if (checkCMS==5)
                                {
                                //PayBill(cust, med);
                                RemoveCart(cust);
                                }
                            }
                        }
                        else if (role == "")
                        {
                            Console.WriteLine("You entered wrong informatin!!");
                        }
                }

                else if (choice == 2) // choice 2 is for signup
                {
                    bool flag=SignUp(admin,customer);
                    if (flag)
                    {
                        Console.WriteLine("SignedUp Successfully!");
                    }
                    if (!flag)
                    {
                        Console.WriteLine("Try Again");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Wrong Input!");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        static int LoginView()
        {
            Console.Clear();


            Console.WriteLine("Enter Choice");
            Console.WriteLine("1.sign in");
            Console.WriteLine("2.sign up");
            Console.WriteLine("Enter key: ");
            while (true)
            {
                string choice = Console.ReadLine();
                   int conChoice = int.Parse(choice);
                if (conChoice <= 2)
                {
                    return conChoice;
                    //  break;
                }
                else
                {
                    Console.WriteLine("You entered an invalid input");
                }
            }

        }
        static string InputSignIN(List<Admin> admin,List<Customers> cust)
        {
            string role="";
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();    // will store name entered by user
            Console.WriteLine("Enter your password: ");
            string userpassword = Console.ReadLine();   // will store password entered by user
            if (username != null && userpassword != null)
            {
                foreach (Customers person in cust) // loop for identifying users
                {
                    if (username == person.Name && userpassword == person.Password)
                    {
                        role= person.Role;
                    }
                }
                foreach (Admin person in admin) // loop for identifying users
                {
                    if (username == person.Name && userpassword == person.Password)
                    {
                        role = person.Role;
                    }
                }
                return role;
            }
            // string checkUser = CheckUsersInArray(username, userpassword, s);  // will check presence of user

            return null;
        }
        static bool SignUp(List<Admin> admin, List<Customers> customer)
        {
            bool flag = false;
            string userName;
            bool isValiduserName=false;
            // to store role entered by user
            Console.WriteLine("Enter role");
            string role = Console.ReadLine();
            string Role = role.ToLower();
            if (!(role == "admin" || role == "customer")) return false; //isko apne hisaab se likh lena 
            while (true)
            {
                Console.WriteLine("Enter name");
                userName = Console.ReadLine();  // to store name entered by user
                if (Role == "admin")
                {
                    isValiduserName = ValidAdminName(userName, admin);
                }
                if(Role=="customer")
                {
                    isValiduserName = ValidCustomerName(userName, customer);
                }
                if (isValiduserName)
                {
                    break;
                }
            }
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();  // to store password enteres by user
            if(Role=="admin")
            {
                Admin ad= new Admin(userName, password, Role);
                StoreInFileAdmin(ad);
                admin.Add(ad);
                flag = true;
            }  
            if(Role=="customer")
            {
                Customers cust = new Customers(userName, password, role);
                StoreInFileCustomer(cust);
                customer.Add(cust);
                flag = true;
            }
            return flag;
        }
        static void StoreInFileAdmin(Admin admin)
        {
            string path = "D:\\oopweek4pdTask\\BussinessApplicationCS\\admin.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(admin.Name + "," + admin.Password + "," + admin.Role);
            Console.ReadKey();
            file.Flush();
            file.Close();
        }
        static void StoreInFileCustomer(Customers customer)
        {
            string path = "D:\\oopweek4pdTask\\BussinessApplicationCS\\customer.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(customer.Name + "," + customer.Password + "," + customer.Role);
            Console.ReadKey();
            file.Flush();
            file.Close();
        }
        static Boolean ValidAdminName(string userName, List<Admin> admin)
        {
            bool ispresent = true;
            for (int i = 0; i < admin.Count; i++) // loop for checking presence of user
            {
                if (admin[i].Name == userName)
                {
                    ispresent = false;
                    break;
                }
            }
            if (ispresent == false)
            {
                Console.WriteLine("Admin name already present!");
                return ispresent;
            }
            return ispresent;

        }
        static Boolean ValidCustomerName(string userName, List<Customers> customer)
        {
            bool ispresent = true;
            for (int i = 0; i < customer.Count; i++) // loop for checking presence of user
            {
                if (customer[i].Name == userName)
                {
                    ispresent = false;
                    break;
                }
            }
            if (ispresent == false)
            {
                Console.WriteLine("Admin name already present!");
                return ispresent;
            }
            return ispresent;
        }
        static void ReadAdminfromFile(List<Admin> admin)
        {
            string path = "D:\\oopweek4pdTask\\BussinessApplicationCS\\admin.txt";

            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);

                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string userName = record.Split(',')[0];
                    string password = record.Split(',')[1];
                    string role = record.Split(',')[2];
                    Admin s1 = new Admin(userName, password, role);
                    admin.Add(s1);
                    x++;
                    if (x > admin.Count)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void ReadCustomerfromFile(List<Customers> customer)
        {
            string path = "D:\\oopweek4pdTask\\BussinessApplicationCS\\customer.txt";

            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);

                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string userName = record.Split(',')[0];
                    string password = record.Split(',')[1];
                    string role = record.Split(',')[2];
                    Customers cust = new Customers(userName, password, role);
                    customer.Add(cust);
                    x++;
                    if (x > customer.Count)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static int AdminMainScreen()
        {
            Console.Clear();
            Console.WriteLine("**************Admin Main Screen******************");
            Console.WriteLine("1.Check list");
            Console.WriteLine("2.Update list");
            Console.WriteLine("3.Delete items");
            Console.WriteLine("4.Create list");
            Console.WriteLine(" Enter Choice");
            int key = int.Parse(Console.ReadLine());
            return key;

        }
        static int CustomerMainScreen()
        {
            Console.Clear();
            Console.WriteLine("***************CUSTOMER MAIN SCREEN**************");
            Console.WriteLine("1.Show List ");
            Console.WriteLine("2.Add to Cart ");
            Console.WriteLine("3.Check Cart");
            Console.WriteLine("4.Remove medicines from cart");
            Console.WriteLine("5.Pay bill");   
            Console.WriteLine(" Enter Choice");
            string key = Console.ReadLine();
            int convertedKey = Convert.ToInt32(key);
            return convertedKey;
        }
        static void CheckList(Admin ad)
        {
            Console.Clear();
            Console.WriteLine("*****************LIST*******************");
            Console.WriteLine("\tMEDICINE NAME\t\tPRICE\t\t<<STOCK");
            foreach ( Medicines medicine in ad.med) // loop tp print medicie names quantity and stock
            {
                Console.WriteLine("\t\t" + medicine.MedID + "\t\t" + medicine.MedName+ "\t\t" + "\t\t"+medicine.MedPrice+"\t\t"+medicine.MedStock);
            }
            Console.ReadKey();
        }
        static void UpdateList(Admin ad)
        {
            Console.Clear();
            Console.WriteLine("********************UPDATE MENU********************");
            Console.WriteLine("enter medicine ID");
            string MedID = Console.ReadLine(); // to store name of medicine admin want to update in list
            bool ispresent = CheckMedicineInArray(ad, MedID);
            if (ispresent)
            {
                Console.WriteLine("enter medicine name");
                string mName = Console.ReadLine();
                Console.WriteLine("Enter medicine price: ");
                string mPrice = Console.ReadLine();  // to store price of medicine admin want to update in list
                int convertedPrice = int.Parse((mPrice));   //handle exception here
                Console.WriteLine("Enter stock you want to enter: ");
                string mStock = Console.ReadLine();// to store stock of medicine stock admin want to update in list
                int convertedStock = Convert.ToInt32(mStock);
                Medicines s1 = new Medicines(MedID,mName, convertedPrice, convertedStock);
                ad.med.Add(s1);
            }
        }
        static Boolean CheckMedicineInArray(Admin ad ,string mID)
        {
            bool flag = true;
            foreach (Medicines medicine in ad.med)
            {
                if (medicine.MedID == mID)
                {
                    flag = false;
                    Console.WriteLine("Already Present");
                    Console.ReadKey();   
                    break;
                }  
            }
            return flag;
        }
        static void ReadInventoryDetailsFromFile(Admin ad)
        {
            string path = "D:\\oopweek4pdTask\\BussinessApplicationCS\\inventory.txt";

            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);

                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string medicineID= record.Split(',')[0];
                    string medicineName = record.Split(',')[1];
                    int medicinePrice = int.Parse(record.Split(',')[2]) ;
                    int medicineStock = int.Parse(record.Split(',')[3]) ;
                    Medicines med = new Medicines(medicineID,medicineName, medicinePrice, medicineStock);
                    ad.AddMedicines(med);
                }

                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void StoreInventoryInFileUpdate(Admin ad)
        {
            string path = "D:\\oopweek4pdTask\\BussinessApplicationCS\\inventory.txt";
            StreamWriter file = new StreamWriter(path);
            foreach(Medicines medicine in ad.med)
            {
                file.WriteLine(medicine.MedID+","+medicine.MedName + "," + medicine.MedPrice + "," + medicine.MedStock);
            }
            file.Flush();
            file.Close();

        }
        static void DeleteItems(Admin ad)
        {

            Console.Clear();
            Console.WriteLine("**************************DELETE ITEMS********************");
            int index = 0;
            index = CheckinArraytoDeleteitem(ad);
            if (index != -1)
            {
                ad.med.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("You entered wrong medicine name!");
            }
            Console.ReadKey();
        }
        static int CheckinArraytoDeleteitem(Admin ad)
        {
            Console.WriteLine("enter medicine id you want to delete:");
            string mID = Console.ReadLine();// to store name of medicine admin wants to delete
            int index = -1;                         // to store array index where medicine name is found
            for (int i = 0; i < ad.med.Count; i++) // loop to check presence of medicine
            {
                if (ad.med[i].MedID == mID)
                {
                    index = i;
                    Console.WriteLine("press any key to confirm deletion!!");
                }
            }
            return index;
        }
        static void CreateList(Admin ad)
        {
            Console.Clear();
            Console.WriteLine("Enter number of items you want to add: ");
            string noOfItems = Console.ReadLine();
            int convertedNoOfItems = Convert.ToInt32(noOfItems);

            for (int i = 0; i < convertedNoOfItems; i++)
            {
                Console.WriteLine("Enter id of medicine: ");
                string mID = Console.ReadLine();
                // check validation
                bool ispresent = CheckMedicineInArray(ad, mID);
                if (ispresent)
                {
                    Console.WriteLine("Enter name of medicine: ");
                    string mName = Console.ReadLine();
                    Console.WriteLine("Enter price of medicine: ");
                    string mPrice = Console.ReadLine();
                    var convertedPrice = Convert.ToInt32(mPrice);

                    Console.WriteLine("Enter stock you want to enter: ");
                    string mStock = Console.ReadLine();
                    int convertedStock = Convert.ToInt32(mStock);

                    // to store medicines in array
                    Medicines s1 = new Medicines(mID,mName, convertedPrice, convertedStock);
                    ad.AddMedicines(s1);
                }

            }
        }
        static void ShowList(Admin ad) // will show list to customer
        {
            Console.Clear();
            Console.WriteLine("***********************LIST OF MEDICINES*********************");
            Console.WriteLine("\t\tMedicine Name\t\tPrice\t\t");
            foreach (Medicines medicine in ad.med)
            {
                Console.WriteLine(medicine.MedID+"\t\t" + medicine.MedName + "\t\t" + medicine.MedPrice);
            }
            Console.ReadKey();
        }
      static  void AddToCart(Customers cust,Admin ad) // customer can add medicines to cart
        {
            int bill = 0;
            bool flag = false;
            Console.Clear();
            Console.WriteLine("*****************ADD TO CART****************"); 
            if (cust.selectedmed.Count>0)
            {
                Console.WriteLine("Empty the cart first!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter amount of medicine: ");
                int numberOfMedicine = int.Parse(Console.ReadLine());
                for (int i = 0; i < numberOfMedicine; i++)
                {
                    Console.WriteLine( "Enter Medicine id:");
                    string medID = Console.ReadLine();
                    foreach (Medicines med in ad.med) // loop to check presence of desired medicine
                    {
                        if (med.MedID== medID)
                        {
                            Console.WriteLine("Enter quantity you want to buy: ");
                            int quantity=int.Parse(Console.ReadLine());
                            bill = bill + med.MedPrice*quantity;
                            flag = true;
                            Medicines m = new Medicines(med.MedID, med.MedName, med.MedPrice,quantity,bill); 
                            cust.AddMedicines(m);
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Medicine is not in List!");;
                    Console.ReadKey();
                }
            }
        }
        static void CheckCart(Customers cust) // customer will check his cart
        {
            Console.Clear();
            Console.WriteLine("*********************YOUR CART********************");
            Console.WriteLine( "medicine id\t\tmedicines\tquantitiy\tprice");
            // loop
            foreach (Medicines med in cust.selectedmed)
            {
                Console.WriteLine( med.MedID+"\t\t"+med.MedName +"\t\t" + "\t\t"+med.MedPrice);
            }
            Console.ReadKey();
        }
        static void RemoveCart(Customers cust) // will remove cart
        {
            Console.Clear();
            {
                for (int i=0;i<cust.selectedmed.Count;i++) // loop to delete item and store other itens at that place
                {
                    cust.selectedmed.RemoveAt(i);
                }
            }
        }

        static void RemoveMedFromCart(Customers cust) // customer can unselect items from his order
        {
            Console.Clear();
            int index = 0;
            index = checkInArrayToRemoveFromCart(cust);
            if (index != -1)
            {
                cust.selectedmed.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("You entered wrong medicine id!" );
            }
        }

        static int checkInArrayToRemoveFromCart(Customers cust)
        {
            Console.WriteLine("enter medicine id you want to remove from cart:");
            string mName = Console.ReadLine();
            int index = -1;                                 // to store array index where medicine name is found
            for (int i = 0; i < cust.selectedmed.Count; i++) // loop to check presence of medicine
            {
                if (cust.selectedmed[i].MedID == mName)
                {
                    index = i;
                    Console.WriteLine("press any key to confirm !!");
                    Console.ReadKey();
                }
            }
            return index;
        }
    }
}
