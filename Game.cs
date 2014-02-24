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
        public int FreeCellsAmount
        {
            get
            {
                int am = 0;
                foreach (var cl in _cells)
                    foreach (Cell c in cl)
                    {
                        if (c.Enabled)
                            am++;
                    }
                return am;
            }
        }

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

        private List<MyPoint> _lightList;
        private List<MyPoint> _darkList;
        private List<List<Cell>> _cells;
        private Canvas _grid;

        public bool IsLightTurn { get; set; }

        public Game(Canvas grid)
        {
            _lightList = new List<MyPoint>();
            _darkList = new List<MyPoint>();
            _cells = new List<List<Cell>>();
            this._grid = grid;
            InitializeCells();
        }

        public bool IsLocked
        {
            get
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
        }

        public void Restart()
        {
            this._lightList.Clear();
            this._darkList.Clear();
            this._grid.Children.Clear();
            this._cells.Clear();
            this.InitializeCells();
            this.Start();
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
                MyPoint t;
                IsLightTurn = r.ReadBoolean();
                lcount = r.ReadInt32();
                for (int ii = 0; ii < lcount; ii++)
                {
                    i = r.ReadInt32(); j = r.ReadInt32();
                    t = new MyPoint(_cells[i][j], MyPoint.LIGHT, i, j);
                    this._grid.Children.Add(t.CurrentImage);
                    _lightList.Add(t);
                }
                while (r.BaseStream.Position < r.BaseStream.Length)
                {
                    i = r.ReadInt32(); j = r.ReadInt32();
                    t = new MyPoint(_cells[i][j], MyPoint.DARK, i, j);
                    this._grid.Children.Add(t.CurrentImage);
                    _darkList.Add(t);
                }
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InitializeCells()
        {
            //const int StartX = -370, StartY = -220, ColumnStepX = 92, ColumnStepY = 53, RowStepY = 108;
            const int StartX = 79, StartY = 119, ColumnStepX = 46, ColumnStepY = 27, RowStepY = 54;
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
            MyPoint t;
            t = new MyPoint(_cells[0][0], MyPoint.LIGHT, 0, 0);
            this._grid.Children.Add(t.CurrentImage);
            _lightList.Add(t);
            t = new MyPoint(_cells[4][8], MyPoint.LIGHT, 4, 8);
            this._grid.Children.Add(t.CurrentImage);
            _lightList.Add(t);
            t = new MyPoint(_cells[8][4], MyPoint.LIGHT, 8, 4);
            this._grid.Children.Add(t.CurrentImage);
            _lightList.Add(t);
            t = new MyPoint(_cells[0][4], MyPoint.DARK, 0, 4);
            this._grid.Children.Add(t.CurrentImage);
            _darkList.Add(t);
            t = new MyPoint(_cells[4][0], MyPoint.DARK, 4, 0);
            this._grid.Children.Add(t.CurrentImage);
            _darkList.Add(t);
            t = new MyPoint(_cells[8][8], MyPoint.DARK, 8, 8);
            this._grid.Children.Add(t.CurrentImage);
            _darkList.Add(t);
            this.IsLightTurn = true;

            /*for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    t = new MyPoint(_cells[i][j], MyPoint.LIGHT, i, j);
                    if (t.CurrentImage != null)
                        this._grid.Children.Add(t.CurrentImage);
                }*/

        }

        public MyPoint Find(int side, int x, int y)
        {
            MyPoint closest = null;
            if (side == MyPoint.LIGHT)
                for (int i = 0; i < _lightList.Count; i++)
                {
                    if (x - _lightList[i].X >= 0 && x - _lightList[i].X <= MyPoint.WIDTH &&
                        y - _lightList[i].Y >= 0 && y - _lightList[i].Y <= MyPoint.HEIGHT)
                    { closest = _lightList[i]; break; }
                }
            else if (side == MyPoint.DARK)
                for (int i = 0; i < _darkList.Count; i++)
                {
                    if (x - _darkList[i].X >= 0 && x - _darkList[i].X <= MyPoint.WIDTH &&
                        y - _darkList[i].Y >= 0 && y - _darkList[i].Y <= MyPoint.HEIGHT)
                    { closest = _darkList[i]; break; }
                }
            return closest;
        }

        public void Clone(Cell c, int side, int i, int j)
        {
            MyPoint t = new MyPoint(c, side, i, j);
            this._grid.Children.Add(t.CurrentImage);
            if (t.Side == MyPoint.LIGHT) _lightList.Add(t);
            else _darkList.Add(t);
            IsLightTurn = !IsLightTurn;
            Expansion(t);
              //  MessageBox.Show(String.Format("Game over! The winner is: {0}", _lightList.Count == 0 ? "Green team" : "Red team"));

        }
        private void Jump(MyPoint p, Cell c, int i, int j)
        {
            p.SetNewLocation(c.X, c.Y);
            p.I = i;
            p.J = j;
            c.Enabled = false;
            p.CurrentCell.Enabled = true;
            p.CurrentCell = c;
            IsLightTurn = !IsLightTurn;
            Expansion(p);
              //  MessageBox.Show(String.Format("Game over! The winner is: {0}", _lightList.Count == 0 ? "Green team" : "Red team"));
        }

        public int ChangeList(MyPoint p, int i)
        {
            if (p.Side == MyPoint.DARK)
            {
                p.Side = MyPoint.LIGHT;
                _lightList.Add(_darkList[i]);
                _darkList.RemoveAt(i);
            }
            else
            {
                p.Side = MyPoint.DARK;
                _darkList.Add(_lightList[i]);
                _lightList.RemoveAt(i);
            }
            if (_lightList.Count == 0 || _darkList.Count == 0) return -1;
            return 0;
        }

        public int Expansion(MyPoint p)
        {
            if (p.Side == MyPoint.LIGHT)
            {
                for (int i = 0; i < _darkList.Count; i++)
                {
                    if ((_darkList[i].I == p.I - 1 && (_darkList[i].J == p.J || _darkList[i].J == p.J - 1)) ||
                        (_darkList[i].I == p.I && (_darkList[i].J == p.J - 1 || _darkList[i].J == p.J + 1)) ||
                        (_darkList[i].I == p.I + 1 && (_darkList[i].J == p.J || _darkList[i].J == p.J + 1)))
                    {
                        if (ChangeList(_darkList[i], i) < 0)
                            return -1;
                        else i--;
                    }
                }
            }
            else
                for (int i = 0; i < _lightList.Count; i++)
                {
                    if ((_lightList[i].I == p.I - 1 && (_lightList[i].J == p.J || _lightList[i].J == p.J - 1)) ||
                        (_lightList[i].I == p.I && (_lightList[i].J == p.J - 1 || _lightList[i].J == p.J + 1)) ||
                        (_lightList[i].I == p.I + 1 && (_lightList[i].J == p.J || _lightList[i].J == p.J + 1)))
                    {
                        if (ChangeList(_lightList[i], i) < 0)
                            return -1;
                        else i--;
                    }
                }
            return 0;
        }

        public bool JumpToCell(int x, int y, MyPoint p)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                for (int j = 0; j < _cells[i].Count; j++)
                {
                    if (x - _cells[i][j].X >= 0 && x - _cells[i][j].X <= MyPoint.WIDTH &&
                        y - _cells[i][j].Y >= 0 && y - _cells[i][j].Y <= MyPoint.HEIGHT)
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

        public static void Message()
        {
            MessageBox.Show("A MOST IMPORTANT MESSAGE");
        }
    }
}


