using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessApplicationCS
{
    class Medicines
    {
        public string MedName;
        public int MedPrice;
        public int MedStock;
        public string MedID;
        public int bill;
        public int quantity;
        public Medicines(string MedID, string MedName, int MedPrice,int MedStock)
        {
            this.MedID = MedID;
            this.MedName = MedName;
            this.MedPrice = MedPrice;
            this.MedStock = MedStock;
        }
        public Medicines(string MedID,string MedName,int MedPrice,int quantity,int bill)
        {
            this.MedID = MedID;
            this.MedName = MedName;
            this.MedPrice = MedPrice;
            this.bill = bill;
            this.quantity = quantity;
        }
        public Medicines()
        {

        }
    }
}
