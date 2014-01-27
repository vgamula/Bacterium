#pragma once
#include "cell.h"
using namespace System::Drawing;
using namespace System::Windows::Forms;

const int light=1, dark=2, width=38, height=36;

ref class point
{
private:
	PictureBox^ img;
	int Side, x, y;
public:
	int i, j;
	cell^ C;
	point(cell^ c, int side, int I, int J)
	{
		if (!c->enabled) return;
		img = gcnew PictureBox;
		x=c->x; y=c->y; i=I; j=J;
		img->Location=Point(x,y);
		img->Size = Size(width, height);
		Side=side;
		if (side==light)
		img->Image = Image::FromFile(L"image\\beta1.png");
		else img->Image = Image::FromFile(L"image\\beta2.png");
		img->BackColor = Color::Transparent;
		img->Enabled=false;
		c->enabled=false;
		C=c;
	}
	PictureBox^ get_img() {return img;}
	int get_side() {return Side;}
	int get_x() {return x;}
	int get_y() {return y;}
	void ToFront() {img->BringToFront();}
	void change(int side)
	{
		if (side==light)
			img->Image = Image::FromFile(L"image\\beta1.png");
		else img->Image = Image::FromFile(L"image\\beta2.png");
		Side=side;
	}
	void newlocation(int X, int Y)
	{
		img->Location=Point(X,Y);
		x=X; y=Y;
	}
};

