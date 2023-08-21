using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challange1
{
    class Subject
    {
       public  string subCode;
        public string subType;
        public int CreditHours;
        public int Fees;
        public Subject(string subCode,string subType,int CreditHours,int Fees)
        {
            this.subCode = subCode;
            this.subType = subType;
            this.CreditHours = CreditHours;
            this.Fees = Fees;
        }

    }
}
