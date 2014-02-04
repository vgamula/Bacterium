using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bacterium
{
    
    public class Game
    {
        public int LightCount 
        { 
            get 
            {
                return _lightList.Count;
            }
        }

        public int DarkCount 
        { 
            get 
            {
                return _darkList.Count;
            }
        }

        public Point ToFront(int side, int index)
        {
            if (side == Point.LIGHT)
            {
                this._lightList[index].BringToFront(); 
                return this._lightList[index];
            }
            else
            {
                this._darkList[index].BringToFront();
                return this._darkList[index];
            }
            
        }


        private List<Point> _lightList;
        private List<Point> _darkList;
        private List<List<Cell>> _cells;
        public bool IsLightTurn { get; set; }
        private Grid _grid;

        public Game(Grid grid)
        {
            _lightList = new List<Point>();
            _darkList = new List<Point>();
            _cells = new List<List<Cell>>();
            this._grid = grid;
            InitializeCells();
        }

        public bool IsLocked()
        {
            int i, j;
            for (int ii = 0; ii < (IsLightTurn ? _lightList.Count : _darkList.Count); ii++)
            {
                i = IsLightTurn ? _lightList[ii].I : _darkList[ii].I;
                j = IsLightTurn ? _lightList[ii].J : _darkList[ii].J;
                if (i - 1 >= 0)
                {
                    if (_cells[i - 1][j].Enabled) return false;
                    if (j - 1 >= 0) if (_cells[i - 1][j - 1].Enabled) return false;
                }
                if (i - 2 >= 0)
                {
                    if (_cells[i - 2][j].Enabled) return false;
                    if (j - 2 >= 0) if (_cells[i - 2][j - 2].Enabled) return false;
                }
                if (i + 1 < _cells.Count)
                {
                    if (_cells[i + 1][j].Enabled) return false;
                    if (j + 1 < _cells[i + 1].Count) if (_cells[i + 1][j + 1].Enabled) return false;
                }
                if (i + 2 < _cells.Count)
                {
                    if (_cells[i + 2][j].Enabled) return false;
                    if (j + 2 < _cells[i + 2].Count) if (_cells[i + 2][j + 2].Enabled) return false;
                }
                if (j + 1 < _cells[i].Count) if (_cells[i][j + 1].Enabled) return false;
                if (j + 2 < _cells[i].Count) if (_cells[i][j + 2].Enabled) return false;
                if (j - 1 >= 0) if (_cells[i][j - 1].Enabled) return false;
                if (j - 2 >= 0) if (_cells[i][j - 2].Enabled) return false;
            }
            return true;
        }

        public void Save()
        {
            FileStream fs = new FileStream("save.bin", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(IsLightTurn);
            w.Write((Int32)_lightList.Count);
            for (int i = 0; i < _lightList.Count; i++)
            {
                w.Write((Int32)_lightList[i].I);
                w.Write((Int32)_lightList[i].J);
            }
            for (int i = 0; i < _darkList.Count; i++)
            {
                w.Write((Int32)_darkList[i].I);
                w.Write((Int32)_darkList[i].J);
            }
            fs.Close();
            MessageBox.Show("Збережено! :)", "Повідомлення");
        }

        


        public void Load()
        {
            try
            {
                this._grid.Children.Clear();
                
                _lightList.Clear();
                _darkList.Clear();
                _cells.Clear();
                InitializeCells();
                FileStream fs = new FileStream("save.bin", FileMode.Open);
                BinaryReader r = new BinaryReader(fs);
                int i, j, lcount;
                Point t;
                IsLightTurn = r.ReadBoolean();
                lcount = r.ReadInt32();
                for (int ii = 0; ii < lcount; ii++)
                {
                    i = r.ReadInt32(); j = r.ReadInt32();
                    t = new Point(_cells[i][j], Point.LIGHT, i, j);
                    this._grid.Children.Add(t.CurrentImage);
                    _lightList.Add(t);
                }
                while (r.BaseStream.Position < r.BaseStream.Length)
                {
                    i = r.ReadInt32(); j = r.ReadInt32();
                    t = new Point(_cells[i][j], Point.DARK, i, j);
                    this._grid.Children.Add(t.CurrentImage);
                    _darkList.Add(t);
                }
                fs.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void InitializeCells()
        {
            const int StartX = -370, StartY = -220, ColumnStepX = 92, ColumnStepY = 53, RowStepY = 108;
            int RowStartY, i, j;
            for (i = 0; i < 9; i++)
            {
                RowStartY = StartY + RowStepY * i;
                List<Cell> CellList = new List<Cell>();
                for (j = 0; j < 9; j++)
                    CellList.Add(new Cell(StartX + ColumnStepX * j, RowStartY - ColumnStepY * j, true));
                _cells.Add(CellList);
            }
            int max = 0;
            for (i = 5; i < 9; i++, max++)
                for (j = 0; j <= max; j++)
                    _cells[i][j].Enabled = false;
            max = 5;
            for (i = 0; i < 4; i++, max++)
                for (j = max; j < 9; j++)
                    _cells[i][j].Enabled = false;
        }

        public void Start()
        {
            Point t;
            t = new Point(_cells[0][0], Point.LIGHT, 0, 0);
            this._grid.Children.Add(t.CurrentImage);
            _lightList.Add(t);
            t = new Point(_cells[4][8], Point.LIGHT, 4, 8);
            this._grid.Children.Add(t.CurrentImage);
            _lightList.Add(t);
            t = new Point(_cells[8][4], Point.LIGHT, 8, 4);
            this._grid.Children.Add(t.CurrentImage);
            _lightList.Add(t);
            t = new Point(_cells[0][4], Point.DARK, 0, 4);
            this._grid.Children.Add(t.CurrentImage);
            _darkList.Add(t);
            t = new Point(_cells[4][0], Point.DARK, 4, 0);
            this._grid.Children.Add(t.CurrentImage);
            _darkList.Add(t);
            t = new Point(_cells[8][8], Point.DARK, 8, 8);
            this._grid.Children.Add(t.CurrentImage);
            _darkList.Add(t);
            /*for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    t = new Point(_cells[i][j], Point.LIGHT, i, j);
                    if (t.CurrentImage != null)
                        this._grid.Children.Add(t.CurrentImage);
                }*/

        }

        public int Find(int side, int x, int y)
        {
            int closest = -1;
            if (side == Point.LIGHT)
                for (int i = 0; i < _lightList.Count; i++)
                {
                    if (x - _lightList[i].X >= 0 && x - _lightList[i].X <= Point.WIDTH &&
                        y - _lightList[i].Y >= 0 && y - _lightList[i].Y <= Point.HEIGHT)
                    { closest = i; break; }
                }
            else if (side == Point.DARK)
                for (int i = 0; i < _darkList.Count; i++)
                {
                    if (x - _darkList[i].X >= 0 && x - _darkList[i].X <= Point.WIDTH &&
                        y - _darkList[i].Y >= 0 && y - _darkList[i].Y <= Point.HEIGHT)
                    { closest = i; break; }
                }
            return closest;
        }

        public void Clone(Cell c, int side, int i, int j)
        {
            Point t = new Point(c, side, i, j);
            this._grid.Children.Add(t.CurrentImage);
            if (t.Side == Point.LIGHT) _lightList.Add(t);
            else _darkList.Add(t);
            IsLightTurn = !IsLightTurn;
            if (Expansion(t) < 0)
                MessageBox.Show("Кінець, " + (_darkList.Count == 0 ? "сині" : "жовті") + " перемогли!");

        }
        public void Jump(Point p, Cell c, int i, int j)
        {
            p.SetNewLocation(c.X, c.Y);
            p.I = i;
            p.J = j;
            c.Enabled = false;
            p.CurrentCell.Enabled = true;
            p.CurrentCell = c;
            IsLightTurn = !IsLightTurn;
            if (Expansion(p) < 0)
                MessageBox.Show("Кінець, " + (_darkList.Count == 0 ? "сині" : "жовті") + " перемогли!");
        }

        public int ChangeList(Point p, int i)
        {
            if (p.Side == Point.DARK)
            {
                p.Side = Point.LIGHT;
                _lightList.Add(_darkList[i]);
                _darkList.RemoveAt(i);
            }
            else
            {
                p.Side = Point.DARK;
                _darkList.Add(_lightList[i]);
                _lightList.RemoveAt(i);
            }
            i = i == 0 ? 0 : (i - 1);
            if (_lightList.Count == 0 || _darkList.Count == 0) return -1;
            return 0;
        }

        public int Expansion(Point p)
        {
            if (p.Side == Point.LIGHT)
            {
                for (int ii = 0; ii < _darkList.Count; ii++)
                {
                    if ((_darkList[ii].I == p.I - 1 && (_darkList[ii].J == p.J || _darkList[ii].J == p.J - 1)) ||
                        (_darkList[ii].I == p.I && (_darkList[ii].J == p.J - 1 || _darkList[ii].J == p.J + 1)) ||
                        (_darkList[ii].I == p.I + 1 && (_darkList[ii].J == p.J || _darkList[ii].J == p.J + 1)))
                        if (ChangeList(_darkList[ii], ii) < 0) return -1;
                }
            }
            else
                for (int ii = 0; ii < _lightList.Count; ii++)
                {
                    if ((_lightList[ii].I == p.I - 1 && (_lightList[ii].J == p.J || _lightList[ii].J == p.J - 1)) ||
                        (_lightList[ii].I == p.I && (_lightList[ii].J == p.J - 1 || _lightList[ii].J == p.J + 1)) ||
                        (_lightList[ii].I == p.I + 1 && (_lightList[ii].J == p.J || _lightList[ii].J == p.J + 1)))
                        if (ChangeList(_lightList[ii], ii) < 0) return -1;
                }
            return 0;
        }

        public bool JumpToCell(int x, int y, Point p)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                for (int j = 0; j < _cells[i].Count; j++)
                {
                    if (x - _cells[i][j].X >= 0 && x - _cells[i][j].X <= Point.WIDTH &&
                        y - _cells[i][j].Y >= 0 && y - _cells[i][j].Y <= Point.HEIGHT)
                    {
                        if (!_cells[i][j].Enabled || (i == p.I && j == p.J)) return false;
                        if ((i == p.I - 2 && (j == p.J || j == p.J - 2)) ||
                            (i == p.I && (j == p.J - 2 || j == p.J + 2)) ||
                            (i == p.I + 2 && (j == p.J || j == p.J + 2)))
                        { Jump(p, _cells[i][j], i, j); return true; }
                        if ((i == p.I - 1 && (j == p.J || j == p.J - 1)) ||
                            (i == p.I && (j == p.J - 1 || j == p.J + 1)) ||
                            (i == p.I + 1 && (j == p.J || j == p.J + 1)))
                            Clone(_cells[i][j], p.Side, i, j);
                        return false;
                    }
                }
            }
            return false;
        }
    }
}


