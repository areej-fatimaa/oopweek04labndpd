using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInCsharp
{
    class Player
    {
        public int X;
        public int Y;
        public int HealthCount;
        public int score;
        public Player(int pikachuX, int pikachuY, int pikachuHealth, int score)
        {
            this.X = pikachuX;
            this.Y = pikachuY;
            this.HealthCount = pikachuHealth;
            this.score = score;
        }
        public void MovePikachuRight()
        {
            X++;
        }
        public void MovePikachuLeft()
        {
            X--;
        }
        public void MovePikachuUp()
        {
            Y--;
        }
        public void MovePikachuDown()
        {
            Y++;
        }
    }
    
}
