using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Ship
    {
       public  string ShipId;
        public Angle Longitude;
        public Angle Latitude;
        public Ship(string ShipNo,int deg, float min, char dir, int deg1, float min1, char dir1)
        {
            ShipId = ShipNo;
            Longitude = new Angle(deg, min, dir);
            Latitude = new Angle(deg1, min1, dir1);            
        }  
    }
}
