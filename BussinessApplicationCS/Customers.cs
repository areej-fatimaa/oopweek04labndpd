using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessApplicationCS
{
    class Customers
    {
        public string Name;
        public string Password;
        public string Role;
        public List<Medicines> selectedmed = new List<Medicines>();
        public Customers(string Name,string Password,string Role)
        {
            this.Name = Name;
            this.Password = Password;
            this.Role = Role;
        }
        public Customers()
        {

        }
        public void AddMedicines(Medicines medicine)
        {
            selectedmed.Add(medicine);
        }  
    }
}
