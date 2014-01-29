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

        public MainWindow()
        {
            InitializeComponent();
            String path = Directory.GetCurrentDirectory() + @"\..\..\";
            BitmapImage tmp = new BitmapImage(new Uri(path + @"Images\Cells.png"));
            ImageBrush brush = new ImageBrush(tmp);
            RootGrid.Background = brush;
            _game = new Game(RootGrid);
            _game.Start();
        }

        private void RootGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
