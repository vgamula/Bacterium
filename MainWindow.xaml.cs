using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bacterium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Game _game;
        //private int _currentPointNumber;
        private int _lastX;
        private int _lastY;
        private Point _currentPoint;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            String path = Directory.GetCurrentDirectory() + @"\..\..\";
            loadButton.Source = new BitmapImage(new Uri(path + @"Images\SaveAndLoad\Load1.png"));
            saveButton.Source = new BitmapImage(new Uri(path + @"Images\SaveAndLoad\Save1.png"));
            resetButton.Source = new BitmapImage(new Uri(path + @"Images\RestartArrows\RestartArrow1.png"));

            imageFlag1.Source = new BitmapImage(new Uri(path + @"Images\Flags\RedFlag.png"));
            imageFlag2.Source = new BitmapImage(new Uri(path + @"Images\Flags\GreenFlag.png"));
            BitmapImage tmp = new BitmapImage(new Uri(path + @"Images\Cells.png"));
            ImageBrush brush = new ImageBrush(tmp);
            RootGrid.Background = brush;
            _game = new Game(PointGrid);
            _game.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show(this.Width.ToString());
            MessageBox.Show(this.Height.ToString());
        }

        private void loadButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _game.Load();
                label1.Content = Convert.ToString(_game.LightCount);
                label2.Content = Convert.ToString(_game.DarkCount);
                if (_game.IsLightTurn)
                {
                    imageFlag1.Visibility = Visibility.Visible;
                    imageFlag2.Visibility = Visibility.Hidden;
                }
                else
                {
                    imageFlag2.Visibility = Visibility.Visible;
                    imageFlag1.Visibility = Visibility.Hidden;
                }
                MessageBox.Show("Завантажено! :)", "Повідомлення");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartGame();
            }

        }

        private void PointGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            int side, _currentPointNumber;
            if (_game.IsLightTurn)
                side = Point.LIGHT;
            else 
                side = Point.DARK;


            if ((_currentPointNumber = _game.Find(side, (int)e.GetPosition(PointGrid).X, (int)e.GetPosition(PointGrid).X)) >= 0)
            {
                _currentPoint = _game.ToFront(side, _currentPointNumber);
                _lastX = _currentPoint.X;
                _lastY = _currentPoint.Y;
            }
           
        }
    }
}
