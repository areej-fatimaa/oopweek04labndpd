using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem3
{
    class Customer
    {
        public string CustomerName;
        public string CustomerAddress;
        public string ContactNo;
        public List<Product> products = new List<Product>();
        public Customer(string CustomerName,string CustomerAddress,string ContactNo)
        {
            this.CustomerName = CustomerName;
            this.CustomerAddress = CustomerAddress;
            this.ContactNo = ContactNo;  
        }
        public List<Product> GetAllProduct()
        {
            return products;
        }
        public void AddProduct(Product p)
        {
            products.Add(p);
        }

    }
   
}
