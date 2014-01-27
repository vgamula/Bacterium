using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bacterium
{
    class Point
    {
        static const int LIGHT = 1;
        static const int DARK = 2;
        static const int WIDTH = 38;
        static const int HEIGHT = 36;

        private Image _image;
        private int _side;
        private int _x;
        private int _y;
        private int _i;
        private int _j;
        private Cell _cell;

        public int i
        {
            get { return _i; }
            set { _i = value; }
        }
        public int j
        {
            get { return _j; }
            set { _j = value; }
        }
        public Cell CurrentCell
        {
            get { return _cell; }
            set { _cell = value; }
        }

        public Point(Cell c, int Side, int I, int J)
        {
            if (_cell.enabled) return;
            _image = new Image();
            _x = _cell.x;
            _y = _cell.y;
            _i = I;
            _j = J;
            Canvas.SetLeft(_image, _x);
            Canvas.SetTop(_image, _y);
            //..
        }
    }
}
