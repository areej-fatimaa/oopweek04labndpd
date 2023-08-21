using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challange1
{
    class DegreeProgram
    {
        public string Name;
        public int Duration;
        public int Seats;
        public List<Subject> subjects;
        public DegreeProgram(string Name,int Duration,int Seats)
        {
            this.Name = Name;
            this.Duration = Duration;
            this.Seats = Seats;
            subjects = new List<Subject>();
        }
        public int CalculateCreditHours()
        {
            int count = 0;
            for(int i=0;i<subjects.Count;i++)
            {
                count += subjects[i].CreditHours;
            }
            return count;
        }
        public bool AddSubject(Subject sub)
        {
            int CreditHours = CalculateCreditHours();
            if(CreditHours+sub.CreditHours<=20)
            {
                subjects.Add(sub);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SubjectExists(Subject sub)
        {
            bool flag=false;
            foreach(Subject s in subjects)
            {
                if(sub.subCode==s.subCode)
                {
                    flag =true;
                }
            }
            return flag;
        }

    }
   
}
