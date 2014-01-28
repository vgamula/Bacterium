using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacterium
{
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Enabled { get; set; }

        public Cell(int x = 0, int y = 0, bool enabled = false)
        {
            X = x;
            Y = y;
            Enabled = enabled;
        }


    }

    
}
