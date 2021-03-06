﻿using System;
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
        private MyPoint _currentPoint;
        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            //String path = Directory.GetCurrentDirectory() + @"\..\..\";
            String path = Directory.GetCurrentDirectory() + @"\";
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
            ShowState();
            this.Icon = new BitmapImage(new Uri(path + @"Images\icon.ico"));
            MessageBox.Show("The game is began!");
        }

        private void loadButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _game.Load();
                ShowState();
                MessageBox.Show("Loaded! :)", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartGame();
            }

        }

        private void ShowState()
        {
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
        }

        private void PointGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentPoint != null)
            {
                Cell tmp = _currentPoint.CurrentCell;
                _currentPoint.SetNewLocation(tmp.X, tmp.Y);
                _currentPoint = null;
            }
            int side;
            if (_game.IsLightTurn)
                side = MyPoint.LIGHT;
            else
                side = MyPoint.DARK;
            int x = (int)e.GetPosition(PointGrid).X;
            int y = (int)e.GetPosition(PointGrid).Y;
            _currentPoint = _game.Find(side, x, y);

            if (_currentPoint != null)
            {
                _currentPoint.BringToFront();
            }

        }

        private void PointGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!e.LeftButton.Equals(MouseButtonState.Pressed))
                return;
            if (_currentPoint == null)
                return;
            int x = (int)e.GetPosition(PointGrid).X - MyPoint.WIDTH / 2;
            int y = (int)e.GetPosition(PointGrid).Y - MyPoint.HEIGHT / 2;
            if (x < _currentPoint.X || x > _currentPoint.X + MyPoint.WIDTH ||
                y < _currentPoint.Y || y > _currentPoint.Y + MyPoint.HEIGHT)
            {
                Cell tmp = _currentPoint.CurrentCell;
                _currentPoint.SetNewLocation(tmp.X, tmp.Y);
            }
            _currentPoint.SetNewLocation(x, y);
        }

        private void PointGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_currentPoint == null)
                return;
            int x = (int)e.GetPosition(PointGrid).X;
            int y = (int)e.GetPosition(PointGrid).Y;
            if (x < _currentPoint.X || x > _currentPoint.X + MyPoint.WIDTH ||
                y < _currentPoint.Y || y > _currentPoint.Y + MyPoint.HEIGHT ||
                !_game.JumpToCell(x, y, _currentPoint))
            {
                Cell tmp = _currentPoint.CurrentCell;
                _currentPoint.SetNewLocation(tmp.X, tmp.Y);
            }
            ShowState();
            if (_game.FreeCellsAmount == 0)
                MessageBox.Show(String.Format("Game over! The winner is {0}", _game.DarkCount < _game.LightCount ? "Red team" : "Green team"));
            else
                if (_game.IsLocked)
                {
                    int lightCount = _game.LightCount + (_game.IsLightTurn ? 0 : _game.FreeCellsAmount);
                    int darkCount = _game.DarkCount + (_game.IsLightTurn ? _game.FreeCellsAmount : 0);
                    MessageBox.Show(String.Format("Game over! The winner is: {0}", (lightCount > darkCount) ? "Red team" : "Green team"));
                }
            _currentPoint.SetToBack();
            _currentPoint = null;
        }

        private void saveButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _game.Save();
            MessageBox.Show("Saved! :)", "Message");
        }

        private void resetButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _game.Restart();
            ShowState();
        }

        private void RootGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            if (_currentPoint == null)
                return;
            int x = (int)e.GetPosition(PointGrid).X - MyPoint.WIDTH / 2;
            int y = (int)e.GetPosition(PointGrid).Y - MyPoint.HEIGHT / 2;
            _currentPoint.SetNewLocation(x, y);
        }
    }
}
