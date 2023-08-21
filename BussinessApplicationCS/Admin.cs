using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessApplicationCS
{
    class Admin
    {
        public string Name;
        public string Password;
        public string Role;
        public List<Medicines> med = new List<Medicines>();

        public Admin(string Name,string Password,string Role)
        {
            this.Name = Name;
            this.Password = Password;
            this.Role = Role;
        }
        public Admin()
        {

        }
        public void AddMedicines(Medicines medicine)
        {
            med.Add(medicine);
        }
    }
}
