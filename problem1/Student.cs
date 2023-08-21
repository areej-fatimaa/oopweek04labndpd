using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{
       class Student
    {
        public  string Name;
        public int RollNo;
        public float CGPA;
        public int MatricMarks;
        public int FscMarks;
        public int EcatMarks;
        public string HomeTown;
        public  bool IsHostellite;
        public bool IsTakingScholorship;
        public Student(string name, int rollno, float cgpa, int matricmarks, int fscmarks, int ecatmarks, string hometown, bool ishostellite, bool istakingscholorship)
        {
            this.Name = name;
            this.RollNo = rollno;
            this.CGPA = cgpa;
            this.MatricMarks = matricmarks;
            this.FscMarks = fscmarks;
            this.EcatMarks = ecatmarks;
            this.HomeTown = hometown;
            this.IsHostellite = ishostellite;
            this.IsTakingScholorship = istakingscholorship;
        }
        public Student()
        {

        }
    }
}
