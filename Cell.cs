using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacterium
{
    class Cell
    {
        public int x { get; set; }
        public int y { get; set; }

        public bool enabled=false;

        public Cell(int x=0, int y=0, int enabled=false)
        {
            this.x = x;
            this.y = y;
            this.enabled = enabled;
        }


    }

    
}
