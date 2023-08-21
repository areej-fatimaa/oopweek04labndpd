using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInCsharp
{
    class Bullet
    {

        public int X;
        public int Y;
        public Bullet(int bulletX, int bulletY)
        {
            this.X = bulletX;
            this.Y = bulletY;
        }
        public Bullet()
        {

        }
        public void BulletDarco()
        {
            X--;
        }
    }
    
}
