#include "stdafx.h"

Generic::List <point^> lstl;
Generic::List <point^> lstd;
Generic::List <Generic::List <cell^>^ > cells;

bool locked()
{
	int i,j;
	for (int ii=0; ii<(turnl ? lstl.Count : lstd.Count); ii++)
	{
		i=turnl ? lstl[ii]->i : lstd[ii]->i;
		j=turnl ? lstl[ii]->j : lstd[ii]->j;
		if (i-1>=0)
		{
			if (cells[i-1][j]->enabled) return false;
			if (j-1>=0) if (cells[i-1][j-1]->enabled) return false;
		}
		if (i-2>=0)
		{
			if (cells[i-2][j]->enabled) return false;
			if (j-2>=0) if (cells[i-2][j-2]->enabled) return false;
		}
		if (i+1<cells.Count)
		{
			if (cells[i+1][j]->enabled) return false;
			if (j+1<cells[i+1]->Count) if (cells[i+1][j+1]->enabled) return false;
		}
		if (i+2<cells.Count)
		{
			if (cells[i+2][j]->enabled) return false;
			if (j+2<cells[i+2]->Count) if (cells[i+2][j+2]->enabled) return false;
		}
		if (j+1<cells[i]->Count) if (cells[i][j+1]->enabled) return false;
		if (j+2<cells[i]->Count) if (cells[i][j+2]->enabled) return false;
		if (j-1>=0) if (cells[i][j-1]->enabled) return false;
		if (j-2>=0) if (cells[i][j-2]->enabled) return false;
	}
	return true;
}

void save_game()
{
	FileStream^ fs = gcnew FileStream("save.bin",  FileMode::Create);
	BinaryWriter^ w = gcnew BinaryWriter(fs);
	w->Write(turnl);
	w->Write((Int32) lstl.Count);
	for (int i=0; i<lstl.Count; i++)
	{
		w->Write((Int32) lstl[i]->i);
		w->Write((Int32) lstl[i]->j);
	}
	for (int i=0; i<lstd.Count; i++)
	{
		w->Write((Int32) lstd[i]->i);
		w->Write((Int32) lstd[i]->j);
	}
	fs->Close();
	MessageBox::Show("Збережено! :)");
}

void load_game()
{
	try {
	Controls->Clear();
	InitializeComponent();
	lstl.Clear(); lstd.Clear();
	cells.Clear(); 
	init_cells();
	FileStream^ fs = gcnew FileStream("save.bin",  FileMode::Open);
	BinaryReader^ r = gcnew BinaryReader(fs);
	int i,j, lcount;
	point^ t;
	turnl = r->ReadBoolean();
	lcount = r->ReadInt32();
	for (int ii=0; ii<lcount; ii++)
	{
		i = r->ReadInt32(); j = r->ReadInt32();
		t = gcnew point(cells[i][j], light, i, j);
		Controls->Add(t->get_img());
		lstl.Add(t);
	}
	while (r->BaseStream->Position < r->BaseStream->Length)
	{
		i = r->ReadInt32(); j = r->ReadInt32();
		t = gcnew point(cells[i][j], dark, i, j);
		Controls->Add(t->get_img());
		lstd.Add(t);
	}
	fs->Close();
	label1->Text=Convert::ToString(lstl.Count);
	label2->Text=Convert::ToString(lstd.Count);
	if (turnl) 
	{ pictureBox3->Visible=true;
	pictureBox4->Visible=false;}
	else
	{ pictureBox4->Visible=true;
	pictureBox3->Visible=false;}
	MessageBox::Show("Завантажено! :)");
	} catch (Exception^ e)
	{MessageBox::Show("Немає збережених даних.");
	start_game();}
}

void init_cells()
{
	Generic::List <cell^>^ clst;
	const int startx=23, starty=114, prx=43, pry=24, py=48;
	int strty, i,j;
	for (i=0; i<9; i++)
	{ 
		strty=starty+py*i;
		clst = gcnew Generic::List <cell^>;
		for (j=0; j<9; j++)
		{
			cell^ c = gcnew cell;
			c->x=startx+prx*j;
			c->y=strty-pry*j;
			c->enabled=true;
			clst->Add(c);
		}
		cells.Add(clst);
	}
	int max=0;
	for (i=5; i<9; i++, max++)
		for (j=0; j<=max; j++)
			cells[i][j]->enabled=false;
	max=5;
	for (i=0; i<4; i++, max++)
		for (j=max; j<9; j++)
			cells[i][j]->enabled=false;
}

void start_game()
{
	point^ t;
	t=gcnew point(cells[0][0], light, 0, 0);
	Controls->Add(t->get_img());
	lstl.Add(t);
	t=gcnew point(cells[4][8], light, 4, 8);
	Controls->Add(t->get_img());
	lstl.Add(t);
	t=gcnew point(cells[8][4], light, 8, 4);
	Controls->Add(t->get_img());
	lstl.Add(t);
	t=gcnew point(cells[0][4], dark, 0, 4);
	Controls->Add(t->get_img());
	lstd.Add(t);
	t=gcnew point(cells[4][0], dark, 4, 0);
	Controls->Add(t->get_img());
	lstd.Add(t);
	t=gcnew point(cells[8][8], dark, 8, 8);
	Controls->Add(t->get_img());
	lstd.Add(t);
}

int find(int side, int x, int y)
{
	int closest=-1;
	if (side==light)
	{
		for (int i=0; i<lstl.Count; i++)
		{
			if (x-lstl[i]->get_x()>=0 && x-lstl[i]->get_x()<=width &&
				y-lstl[i]->get_y()>=0 && y-lstl[i]->get_y()<=height)
			{closest=i; break;}
		}
		return closest;
	} else if (side==dark)
	{
		for (int i=0; i<lstd.Count; i++)
		{
			if (x-lstd[i]->get_x()>=0 && x-lstd[i]->get_x()<=width &&
				y-lstd[i]->get_y()>=0 && y-lstd[i]->get_y()<=height)
			{closest=i; break;}
		}
		return closest;
	}
}

void clone(cell^ c, int side, int i, int j)
{
	point^ t=gcnew point(c, side, i, j);
	Controls->Add(t->get_img());
	if (t->get_side()==light) lstl.Add(t);
	else lstd.Add(t);
	turnl=!turnl;
	if (expansion(t)<0) 
		MessageBox::Show("Кінець, "+(lstd.Count==0?"сині":"жовті")+" перемогли!");
}

void jump(point^ p, cell^ c, int i, int j)
{
	p->newlocation(c->x, c->y);
	p->i=i; p->j=j;
	c->enabled=false;
	p->C->enabled=true;
	p->C=c; turnl=!turnl;
	if (expansion(p)<0)
		MessageBox::Show("Кінець, "+(lstd.Count==0?"сині":"жовті")+" перемогли!");
}

int changelist(point^ p, int &i)
{
	if (p->get_side()==dark)
	{
		p->change(light);
		lstl.Add(lstd[i]);
		lstd.RemoveAt(i);
	} else
	{
		p->change(dark);
		lstd.Add(lstl[i]);
		lstl.RemoveAt(i);
	}
	i=i==0?0:(i-1);
	if ( lstl.Count==0 || lstd.Count==0 ) return -1;
	return 0;
}

int expansion(point^ p)
{
	if (p->get_side()==light)
	{
		for (int ii=0; ii<lstd.Count; ii++)
		{
			if ((lstd[ii]->i==p->i-1 && (lstd[ii]->j==p->j || lstd[ii]->j==p->j-1)) ||
				(lstd[ii]->i==p->i && (lstd[ii]->j==p->j-1 || lstd[ii]->j==p->j+1)) ||
				(lstd[ii]->i==p->i+1 && (lstd[ii]->j==p->j || lstd[ii]->j==p->j+1)) ) 
				if (changelist(lstd[ii], ii)<0) return -1;
		}
	} else
		for (int ii=0; ii<lstl.Count; ii++)
		{
			if ((lstl[ii]->i==p->i-1 && (lstl[ii]->j==p->j || lstl[ii]->j==p->j-1)) ||
				(lstl[ii]->i==p->i && (lstl[ii]->j==p->j-1 || lstl[ii]->j==p->j+1)) ||
				(lstl[ii]->i==p->i+1 && (lstl[ii]->j==p->j || lstl[ii]->j==p->j+1)) ) 
				if (changelist(lstl[ii], ii)<0) return -1;
		}
	return 0;
}

bool jumptocell(int x, int y, point^ p)
{
	for (int i=0; i<cells.Count; i++)
	{
		for (int j=0; j<cells[i]->Count; j++)
		{
			if (x-cells[i][j]->x>=0 && x-cells[i][j]->x<=width &&
				y-cells[i][j]->y>=0 && y-cells[i][j]->y<=height )
			{
				if (!cells[i][j]->enabled || (i==p->i && j==p->j)) return false;
				if ((i==p->i-2 && (j==p->j || j==p->j-2)) ||
					(i==p->i && (j==p->j-2 || j==p->j+2)) ||
					(i==p->i+2 && (j==p->j || j==p->j+2)) )
				{ jump(p, cells[i][j], i, j);  return true; }
				if ((i==p->i-1 && (j==p->j || j==p->j-1)) ||
					(i==p->i && (j==p->j-1 || j==p->j+1)) ||
					(i==p->i+1 && (j==p->j || j==p->j+1)) ) 
					clone(cells[i][j], p->get_side(), i, j);
				return false;
			}
		}
	}
	return false;
}