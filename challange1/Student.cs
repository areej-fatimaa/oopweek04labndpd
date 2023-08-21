using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challange1
{
    class Student
    {
        public string Name;
        public string Age;
        public int FscMarks;
        public int EcatMarks;
        public double merit;
        public List<DegreeProgram> preference = new List<DegreeProgram>();
        public List<Subject> regSubject;
        public DegreeProgram regDegree;
        public Student(string Name, string Age, int Fsc,int Ecat,List<DegreeProgram> preference)
        {
            this.Name = Name;  
            this.Age = Age;
            this.FscMarks = Fsc;
            this.EcatMarks = Ecat;
            this.preference = preference;
            regSubject = new List<Subject>();
        }
        public void CalculateMerit()
        {
            this.merit = (((FscMarks / 110) * 0.45F) + ((EcatMarks / 400) * 0.55F)) * 100;
        }
      public bool RegStudentSubject(Subject sub)
        {
            int stuCH = GetCreditHours();
            if(regDegree!=null&&regDegree.SubjectExists(sub)&&stuCH+sub.CreditHours<=9)
            {
                regSubject.Add(sub);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetCreditHours()
        {
            int count = 0;
            foreach(Subject sub in regSubject)
            {
                count += sub.CreditHours;
            }
            return count;
        }
        public float CalculateFee()
        {
            float fee = 0;
            if(regDegree!=null)
            {
                foreach(Subject sub in regSubject)
                {
                    fee += sub.CreditHours;
                }
            }
            return fee;
        }
    }
}
