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
        static const int LIGHT = 1;
        static const int DARK = 2;
        static const int WIDTH = 38;
        static const int HEIGHT = 36;

        private Image _image;
        private int _side;

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
            get;
            set { Canvas.SetLeft(_image, value); }
        }

        public int Y
        {
            get;
            set { Canvas.SetTop(_image, value); }
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
