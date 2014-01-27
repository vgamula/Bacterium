using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacterium
{
    class Game
    {
        public List<Point> lstl, lstd;
        public List<Cell> cells;

        public bool isLocked()
        {
            int i, j;
            for (int ii = 0; ii < (turnl ? lstl.Count : lstd.Count); i++)
            {
                i = turnl ? lstl[ii]->i : lstd[ii]->i;
                j = turnl ? lstl[ii]->j : lstd[ii]->j;
                if (i - 1 >= 0)
                {
                    if (cells[i - 1, j].enabled) return false;
                    if (j - 1 >= 0) if (cells[i - 1, j - 1].enabled) return false;
                }
                if (i - 2 >= 0)
                {
                    if (cells[i - 2, j].enabled) return false;
                    if (j - 2 >= 0) if (cells[i - 2, j - 2].enabled) return false;
                }
                if (i + 1 < cells.Count)
                {
                    if (cells[i + 1, j].enabled) return false;
                    if (j + 1 < cells[i + 1].Count) if (cells[i + 1, j + 1].enabled) return false;
                }
                if (i + 2 < cells.Count)
                {
                    if (cells[i + 2, j].enabled) return false;
                    if (j + 2 < cells[i + 2].Count) if (cells[i + 2, j + 2].enabled) return false;
                }
                if (j + 1 < cells[i].Count) if (cells[i, j + 1].enabled) return false;
                if (j + 2 < cells[i].Count) if (cells[i, j + 2].enabled) return false;
                if (j - 1 >= 0) if (cells[i, j - 1].enabled) return false;
                if (j - 2 >= 0) if (cells[i, j - 2].enabled) return false;
            }
            return true;
        }

        public void Save()
        {
            FileStream fs = new FileStream("save.bin", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(turnl);
            w.Write((Int32)lstl.Count);
            for (int i = 0; i < lstl.Count; i++)
            {
                w.Write((Int32)lstl[i].i);
                w.Write((Int32)lstl[i].j);
            }
            for (int i = 0; i < lstd.Count; i++)
            {
                w.Write((Int32)lstd[i].i);
                w.Write((Int32)lstd[i].j);
            }
            fs.Close();
            MessageBox.Show("Збережено! :)", "Повідомлення");
        }

        public void Load()
        {
            try
            {
                Controls.Clear();
                InitializeComponent();
                lstl.Clear();
                lstd.Clear();
                cells.Clear();
                //new method here
                InitializeCells();
                FileStream fs = new FileStream("save.bin", FileMode.Open);
                BinaryReader r = new BinaryReader(fs);
                int i, j, lcount;
                Point t;
                turnl = r.ReadBoolean();
                lcount = r.ReadInt32();
                for (int ii = 0; ii < lcount; ii++)
                {
                    i = r.ReadInt32(); j = r.ReadInt32();
                    t = new Point(cells[i, j], light, i, j);
                    Controls.Add(t.get_img());
                    lstl.Add(t);
                }
                while (r.BaseStream.Position < r.BaseStream.Length)
                {
                    i = r.ReadInt32(); j = r.ReadInt32();
                    t = new Point(cells[i, j], dark, i, j);
                    Controls.Add(t.get_img());
                    lstd.Add(t);
                }
                fs.Close();
                label1.Text = Convert.ToString(lstl.Count);
                label2.Text = Convert.ToString(lstd.Count);
                if (turnl)
                {
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = false;
                }
                else
                {
                    pictureBox4.Visible = true;
                    pictureBox3.Visible = false;
                }
                MessageBox.Show("Завантажено! :)", "Повідомлення");
            }
            catch
            {
                MessageBox.Show("Немає збережених даних.", "Повідомлення");
                start_game();
            }
        }

        public void InitializeCells()
        {
            List<Cell> clst;
            const int startx = 23, starty = 114, prx = 43, pry = 24, py = 48;
            int strty, i, j;
            for (i = 0; i < 9; i++)
            {
                strty = starty + py * i;
                clst = new List<Cell>();
                for (j = 0; j < 9; j++)
                    clst.Add(new Cell(startx + prx * j, starty + pry * j, true));
                cells.Add(clst);
            }
            int max = 0;
            for (i = 5; i < 9; i++, max++)
                for (j = 0; j <= max; j++)
                    cells[i, j].enabled = false;
            max = 5;
            for (i = 0; i < 4; i++, max++)
                for (j = max; j < 9; j++)
                    cells[i, j].enabled = false;
        }

        public void Start()
        {
            Point t;
            t = new Point(cells[0, 0], light, 0, 0);
            Controls.Add(t.get_img());
            lstl.Add(t);
            t = new Point(cells[4, 8], light, 4, 8);
            Controls.Add(t.get_img());
            lstl.Add(t);
            t = new Point(cells[8, 4], light, 8, 4);
            Controls.Add(t.get_img());
            lstl.Add(t);
            t = new Point(cells[0, 4], dark, 0, 4);
            Controls.Add(t.get_img());
            lstd.Add(t);
            t = new Point(cells[4, 0], dark, 4, 0);
            Controls.Add(t.get_img());
            lstd.Add(t);
            t = new Point(cells[8, 8], dark, 8, 8);
            Controls.Add(t.get_img());
            lstd.Add(t);
        }

        public int Find(int side, int x, int y)
        {
            int closest = -1;
            if (side == light)
            {
                for (int i = 0; i < lstl.Count; i++)
                {
                    if (x - lstl[i].get_x() >= 0 && x - lstl[i].get_x() <= width &&
                        y - lstl[i].get_y() >= 0 && y - lstl[i].get_y() <= height)
                    { closest = i; break; }
                }
                return closest;
            }
            else if (side == dark)
            {
                for (int i = 0; i < lstd.Count; i++)
                {
                    if (x - lstd[i].get_x() >= 0 && x - lstd[i].get_x() <= width &&
                        y - lstd[i].get_y() >= 0 && y - lstd[i].get_y() <= height)
                    { closest = i; break; }
                }
                return closest;
            }
        }

        public void Clone(Cell c, int side, int i, int j)
        {
            Point t = new Point(c, side, i, j);
            Controls.Add(t.get_img());
            if (t.get_side() == light) lstl.Add(t);
            else lstd.Add(t);
            turnl = !turnl;
            if (expansion(t) < 0)
                MessageBox.Show("Кінець, " + (lstd.Count == 0 ? "сині" : "жовті") + " перемогли!");

        }
        public void jump(Point p, Cell c, int i, int j)
        {
	        p.NewLocation(c.x, c.y);
	        p.i=i; p.j=j;
	        c.enabled=false;
	        p.C.enabled=true;
	        p.C=c; turnl=!turnl;
	        if (expansion(p)<0)
		        MessageBox.Show("Кінець, "+(lstd.Count==0?"сині":"жовті")+" перемогли!");
        }

        public int ChangeList(Point p, int i)
        {
            if (p.get_side()==dark)
	        {
		        p.change(light);
		        lstl.Add(lstd[i]);
		        lstd.RemoveAt(i);
	        } else
	        {
		        p.change(dark);
		        lstd.Add(lstl[i]);
		        lstl.RemoveAt(i);
	        }
	        i=i==0?0:(i-1);
	        if ( lstl.Count==0 || lstd.Count==0 ) return -1;
	        return 0;
        }

        public int Expansion(Point p)
        {
            if (p.get_side() == light)
            {
                for (int ii = 0; ii < lstd.Count; ii++)
                {
                    if ((lstd[ii].i == p.i - 1 && (lstd[ii].j == p.j || lstd[ii].j == p.j - 1)) ||
                        (lstd[ii].i == p.i && (lstd[ii].j == p.j - 1 || lstd[ii].j == p.j + 1)) ||
                        (lstd[ii].i == p.i + 1 && (lstd[ii].j == p.j || lstd[ii].j == p.j + 1)))
                        if (changelist(lstd[ii], ii) < 0) return -1;
                }
            }
            else
                for (int ii = 0; ii < lstl.Count; ii++)
                {
                    if ((lstl[ii].i == p.i - 1 && (lstl[ii].j == p->j || lstl[ii].j == p.j - 1)) ||
                        (lstl[ii].i == p.i && (lstl[ii].j == p->j - 1 || lstl[ii].j == p.j + 1)) ||
                        (lstl[ii].i == p.i + 1 && (lstl[ii].j == p->j || lstl[ii].j == p.Sj + 1)))
                        if (changelist(lstl[ii], ii) < 0) return -1;
                }
            return 0;
        }

        public bool JumpToCell(int x, int y, Point p)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if (x - cells[i,j].x >= 0 && x - cells[i,j].x <= width &&
                        y - cells[i,j].y >= 0 && y - cells[i,j].y <= height)
                    {
                        if (!cells[i,j]->enabled || (i == p.i && j == p.j)) return false;
                        if ((i == p.i - 2 && (j == p.j || j == p.j - 2)) ||
                            (i == p.i && (j == p.j - 2 || j == p.j + 2)) ||
                            (i == p.i + 2 && (j == p.j || j == p.j + 2)))
                        { jump(p, cells[i,j], i, j); return true; }
                        if ((i == p.i - 1 && (j == p.j || j == p.j - 1)) ||
                            (i == p.i && (j == p.j - 1 || j == p.j + 1)) ||
                            (i == p.i + 1 && (j == p.j || j == p.j + 1)))
                            clone(cells[i,j], p.get_side(), i, j);
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
