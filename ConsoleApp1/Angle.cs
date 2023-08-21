using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Angle
    {
        public int Degrees;   
        public float Min;
        public char Direction;
        public Angle(int Degrees,float Min,char Direction)
        {
            this.Degrees = Degrees;
            this.Min = Min;
            this.Direction = Direction;
        }
        public void ChangeAngle(int degree,float min,char dir)
        {
            Degrees = degree;
            Min = min;
            Direction = dir;
        }
        public string ReturnAngle()
        {
            string str=Degrees+"\u00b0" + Min + Direction;
            return str;
        }
    }
}
