using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Bacterium
{
    class Point
    {
        public static readonly int LIGHT = 1;
        public static readonly int DARK = 2;
        public static readonly int WIDTH = 38;
        public static readonly int HEIGHT = 36;

        private Image _image;
        private int _side;
        private int _x;
        private int _y;

        public int I { get; set; }
        public int J { get; set; }
        public Cell CurrentCell { get; set; }

        public Image CurrentImage
        {
            get { return _image; }
        }

        public int Side
        {
            get { return _side; }
            set
            {
                _side = value;
                BitmapImage tmp;
                if (_side == LIGHT)
                    tmp = new BitmapImage(new Uri(""));
                else
                    tmp = new BitmapImage(new Uri(""));
                _image.Source = tmp;
            }
        }

        public int X
        {
            get { return _x; }
            set 
            {
                _x = value;
                Canvas.SetLeft(_image, _x);
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                Canvas.SetTop(_image, _y);
            }
        }

        public Point(Cell cell, int side, int i, int j)
        {
            if (!cell.Enabled) return;
            CurrentCell = cell;
            cell.Enabled = false;
            I = i;
            J = j;
            _image = new Image();
            _image.Height = HEIGHT;
            _image.Width = WIDTH;
            _image.IsEnabled = false;
            SetNewLocation(cell.X, cell.Y);
            Side = side;
        }

        public void BringToFront()
        { Panel.SetZIndex(_image, 100); }

        public void SetToBack()
        { Panel.SetZIndex(_image, 0); }

        public void SetNewLocation(int x, int y)
        { X = x; Y = y; }
    }
}
