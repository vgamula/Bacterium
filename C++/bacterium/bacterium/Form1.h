#pragma once

namespace bacterium {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::IO;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::PictureBox^  pictureBox1;
	protected: 
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::PictureBox^  pictureBox2;
	private: System::Windows::Forms::PictureBox^  pictureBox3;
	private: System::Windows::Forms::PictureBox^  pictureBox4;

	private: System::Windows::Forms::PictureBox^  pictureBox5;
	private: System::Windows::Forms::PictureBox^  pictureBox6;
	private: System::Windows::Forms::PictureBox^  pictureBox7;




	protected: 
	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->pictureBox2 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox3 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox4 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox5 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox6 = (gcnew System::Windows::Forms::PictureBox());
			this->pictureBox7 = (gcnew System::Windows::Forms::PictureBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox3))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox4))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox5))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox6))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox7))->BeginInit();
			this->SuspendLayout();
			// 
			// pictureBox1
			// 
			this->pictureBox1->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox1.Image")));
			this->pictureBox1->Location = System::Drawing::Point(12, 12);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(40, 39);
			this->pictureBox1->TabIndex = 0;
			this->pictureBox1->TabStop = false;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::Color::Transparent;
			this->label1->Font = (gcnew System::Drawing::Font(L"Arial Rounded MT Bold", 24, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label1->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(64)), static_cast<System::Int32>(static_cast<System::Byte>(64)), 
				static_cast<System::Int32>(static_cast<System::Byte>(64)));
			this->label1->Location = System::Drawing::Point(58, 12);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(36, 37);
			this->label1->TabIndex = 1;
			this->label1->Text = L"3";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->BackColor = System::Drawing::Color::Transparent;
			this->label2->Font = (gcnew System::Drawing::Font(L"Arial Rounded MT Bold", 24, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(0)));
			this->label2->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(64)), static_cast<System::Int32>(static_cast<System::Byte>(64)), 
				static_cast<System::Int32>(static_cast<System::Byte>(64)));
			this->label2->Location = System::Drawing::Point(314, 12);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(36, 37);
			this->label2->TabIndex = 3;
			this->label2->Text = L"3";
			// 
			// pictureBox2
			// 
			this->pictureBox2->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox2->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox2.Image")));
			this->pictureBox2->Location = System::Drawing::Point(375, 12);
			this->pictureBox2->Name = L"pictureBox2";
			this->pictureBox2->Size = System::Drawing::Size(40, 39);
			this->pictureBox2->TabIndex = 2;
			this->pictureBox2->TabStop = false;
			// 
			// pictureBox3
			// 
			this->pictureBox3->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox3->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox3.Image")));
			this->pictureBox3->Location = System::Drawing::Point(12, 57);
			this->pictureBox3->Name = L"pictureBox3";
			this->pictureBox3->Size = System::Drawing::Size(40, 38);
			this->pictureBox3->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBox3->TabIndex = 4;
			this->pictureBox3->TabStop = false;
			// 
			// pictureBox4
			// 
			this->pictureBox4->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox4->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox4.Image")));
			this->pictureBox4->Location = System::Drawing::Point(375, 57);
			this->pictureBox4->Name = L"pictureBox4";
			this->pictureBox4->Size = System::Drawing::Size(40, 38);
			this->pictureBox4->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBox4->TabIndex = 5;
			this->pictureBox4->TabStop = false;
			this->pictureBox4->Visible = false;
			// 
			// pictureBox5
			// 
			this->pictureBox5->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox5->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox5.Image")));
			this->pictureBox5->Location = System::Drawing::Point(351, 383);
			this->pictureBox5->Name = L"pictureBox5";
			this->pictureBox5->Size = System::Drawing::Size(64, 60);
			this->pictureBox5->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBox5->TabIndex = 7;
			this->pictureBox5->TabStop = false;
			this->pictureBox5->Click += gcnew System::EventHandler(this, &Form1::pictureBox5_Click);
			this->pictureBox5->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox5_MouseDown);
			this->pictureBox5->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox5_MouseUp);
			// 
			// pictureBox6
			// 
			this->pictureBox6->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox6->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox6.Image")));
			this->pictureBox6->Location = System::Drawing::Point(1, 401);
			this->pictureBox6->Name = L"pictureBox6";
			this->pictureBox6->Size = System::Drawing::Size(51, 51);
			this->pictureBox6->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBox6->TabIndex = 8;
			this->pictureBox6->TabStop = false;
			this->pictureBox6->Click += gcnew System::EventHandler(this, &Form1::pictureBox6_Click);
			this->pictureBox6->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox6_MouseDown);
			this->pictureBox6->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox6_MouseUp);
			// 
			// pictureBox7
			// 
			this->pictureBox7->BackColor = System::Drawing::Color::Transparent;
			this->pictureBox7->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"pictureBox7.Image")));
			this->pictureBox7->Location = System::Drawing::Point(58, 401);
			this->pictureBox7->Name = L"pictureBox7";
			this->pictureBox7->Size = System::Drawing::Size(51, 51);
			this->pictureBox7->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBox7->TabIndex = 9;
			this->pictureBox7->TabStop = false;
			this->pictureBox7->Click += gcnew System::EventHandler(this, &Form1::pictureBox7_Click);
			this->pictureBox7->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox7_MouseDown);
			this->pictureBox7->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox7_MouseUp);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::SystemColors::Control;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(427, 455);
			this->Controls->Add(this->pictureBox7);
			this->Controls->Add(this->pictureBox6);
			this->Controls->Add(this->pictureBox5);
			this->Controls->Add(this->pictureBox4);
			this->Controls->Add(this->pictureBox3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->pictureBox2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->pictureBox1);
			this->DoubleBuffered = true;
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->MaximizeBox = false;
			this->Name = L"Form1";
			this->Tag = L"";
			this->Text = L"ExpansioN";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::Form1_MouseDown);
			this->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::Form1_MouseMove);
			this->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::Form1_MouseUp);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox3))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox4))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox5))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox6))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox7))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
#include "mod.h"
#include "cell.h"
#include "point.h"
int numb, tag, lastx, lasty;
bool turnl;

	private: Void Form1_Load(Object^  sender, EventArgs^  e) {
				 tag=0; turnl=true;
				 init_cells();
				 start_game();
			 }
	private: Void Form1_MouseDown(Object^  sender, MouseEventArgs^  e) {
				 if (e->Button == System::Windows::Forms::MouseButtons::Left) {
				 if (turnl)
				 {	if ((numb=find(light,e->X,e->Y))>=0) 
					{
						tag=1;
						lstl[numb]->ToFront();
						lastx=lstl[numb]->get_x();
						lasty=lstl[numb]->get_y();
					}
				 } else
					 if ((numb=find(dark,e->X,e->Y))>=0) 
					 {
						 tag=1;
						 lstd[numb]->ToFront();
						 lastx=lstd[numb]->get_x();
						 lasty=lstd[numb]->get_y();
					 }
				}
			 }
	private: Void Form1_MouseMove(Object^  sender, MouseEventArgs^  e) {
				 if (tag==1) 
				 {
					 int x=e->X-width/2, y=e->Y-height/2;
					 if (turnl) lstl[numb]->newlocation(x,y);
					 else lstd[numb]->newlocation(x,y);
				 }
			 }
	private: Void Form1_MouseUp(Object^  sender, MouseEventArgs^  e) {
				 if (tag==1)
				 {
					 tag=0;
					 if (turnl) {if (!jumptocell(e->X, e->Y, lstl[numb]))
						lstl[numb]->newlocation(lastx, lasty);}
					 else {if (!jumptocell(e->X, e->Y, lstd[numb]))
						 lstd[numb]->newlocation(lastx, lasty);}
					 label1->Text=Convert::ToString(lstl.Count);
					 label2->Text=Convert::ToString(lstd.Count);
					 if (turnl) 
					 { pictureBox3->Visible=true;
					 pictureBox4->Visible=false;}
					 else
					 { pictureBox4->Visible=true;
					 pictureBox3->Visible=false;}
					 if (lstl.Count + lstd.Count == 61)
					 MessageBox::Show("Кінець, "+(lstl.Count>lstd.Count?"сині":"жовті")+" перемогли!");
					 else if (locked())
					 MessageBox::Show("Кінець, "+(turnl?"жовті":"сині")+" перемогли!");
				 }
			 }
private: Void pictureBox5_Click(Object^  sender, EventArgs^  e) { 
			 Controls->Clear();
			 InitializeComponent();
			 lstl.Clear(); lstd.Clear();
			 cells.Clear(); 
			 MouseEventArgs^ m;
			 Form1_Load(this, m);
		 }
private: Void pictureBox5_MouseDown(Object^  sender, MouseEventArgs^  e) {
			 pictureBox5->Image = Image::FromFile(L"image\\replay1.png");
		 }
private: Void pictureBox5_MouseUp(Object^  sender, MouseEventArgs^  e) {
			 pictureBox5->Image = Image::FromFile(L"image\\replay.png");
		 }
private: Void pictureBox6_MouseDown(Object^  sender, MouseEventArgs^  e) {
			 pictureBox6->Image = Image::FromFile(L"image\\save2.png");
		 }
private: Void pictureBox6_MouseUp(Object^  sender, MouseEventArgs^  e) {
			 pictureBox6->Image = Image::FromFile(L"image\\save1.png");
		 }
private: Void pictureBox6_Click(Object^  sender, System::EventArgs^  e) {
			 save_game();
		 }
private: Void pictureBox7_MouseDown(Object^  sender, MouseEventArgs^  e) {
			 pictureBox7->Image = Image::FromFile(L"image\\load1.png");
		 }
private: Void pictureBox7_MouseUp(Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
			 pictureBox7->Image = Image::FromFile(L"image\\load.png");
		 }
private: Void pictureBox7_Click(Object^  sender, System::EventArgs^  e) {
			 load_game();
		 }
};
}

