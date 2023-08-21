using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInCsharp
{
    class Enemy
    {

        public int X;
        public int Y;
        public int HealthCount;
        public string Direction;
        public Enemy(int spikoX, int spikoY, int spikoHealth, string spikoDirection)
        {
            this.X = spikoX;
            this.Y = spikoY;
            this.HealthCount = spikoHealth;
            this.Direction = spikoDirection;
        }
        public void MoveSpikoDown()
        {
            Y--;
        }
        public void MoveSpikoUp()
        {
            Y++;
        }
        public void MoveDarcoRight()
        {
            X++;
        }
        public void MoveDarcoLeft()
        {
            X--;
        }
    }
    
}
