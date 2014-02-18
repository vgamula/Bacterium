using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace Bacterium
{
   
    public class MyPoint
    {
        public static readonly int LIGHT = 1;
        public static readonly int DARK = 2;
        public static readonly int WIDTH = 40;
        public static readonly int HEIGHT = 40;

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
                //String path = Directory.GetCurrentDirectory() + @"\..\..\";
                String path = Directory.GetCurrentDirectory() + @"\";
                if (_side == LIGHT)
                    tmp = new BitmapImage(new Uri(path + @"Images\Bacteriums\Bacterium1.png"));
                else
                    tmp = new BitmapImage(new Uri(path + @"Images\Bacteriums\Bacterium2.png"));
                _image.Source = tmp;
            }
        }

        public int X
        {
            get { return _x; }
            set 
            {
                _x = value;
                //_image.Margin = new System.Windows.Thickness(_x, _y, 0, 0);
                Canvas.SetLeft(_image, _x);
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                //_image.Margin = new System.Windows.Thickness(_x, _y, 0, 0);
                Canvas.SetTop(_image, _y);   
            }
        }

        public MyPoint(Cell cell, int side, int i, int j)
        {
            _image = null;
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
