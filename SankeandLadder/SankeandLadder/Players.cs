using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeandLadder
{
    internal class Players
    {
        
            private readonly Random rnd = new Random();

            public void  Roll()
            {
                int diceResult = rnd.Next(1, 7);
            }

        
    }
}
