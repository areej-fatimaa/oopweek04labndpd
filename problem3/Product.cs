using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3
{
    class Product
    {
       public string Name;
        public string Category;
        public int Price;
        public Product(string Name,string Category,int Price)
        {
            this.Name = Name;
            this.Price = Price;
            this.Category = Category;
        }
        public float CalculateTax()
        {
            float tax=(Price * 10) / 100;
            return tax;
        }
    }
}
