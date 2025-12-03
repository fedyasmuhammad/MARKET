using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System .Data.SqlClient;
using System.IO;
namespace MARKET
{
    public partial class Form6 : Form
    {
        string button1;

        string button10;

        string label;
        string img;
        

        private  Form3 form3;
      
        public Form6( string label,string button1, string button10, string img, Form3 form3)
        {
            InitializeComponent();
            this.form3 = form3;
            this.button1 = insert.Text;
            this.img = "C:\\Users\\Fedyas Muhammad\\Downloads\\MARKET-master\\MARKET\\IMAGE\\accept.png";
            pictureBox1.Image = Image.FromFile(this.img);
            label1.ForeColor = Color.Green;
            this.label = label1.Text;
          label1.Text= "زانــیــاریــیــەکــە بــە ســەرکــەوتــوویــی زیــادکرا";
           
           
            




        }
        public Form6(string label, string button1, string img, Form4 form4)
        {
            InitializeComponent();
            guna2Panel1.BorderColor = Color.Red;
            this.label = label1.Text;
            this.button1=insert.Text;
            insert.FillColor = Color.Red;
            label1.ForeColor = Color.Red;
            
            label1.Text = "زانــیــاریــیــەکــە بــە ســەرکــەوتــوویــی ســڕایــەوە";
            this.img = "C:\\Users\\Fedyas Muhammad\\Downloads\\MARKET-master\\MARKET\\IMAGE\\bin.png";
            pictureBox1.Image = Image.FromFile(this.img);


            this.Hide();
           
        }
        public Form6(string label, string button1, string img, Form5 form5)
        {
            InitializeComponent();

            this.label = label1.Text;
            this.button1 = insert.Text;
            label1.ForeColor = Color.Green;
            label1.Text = "زانــیــاریــیــەکــە بــە ســەرکــەوتــوویــی تــازەکـرایــەوە";
            this.img = "C:\\Users\\Fedyas Muhammad\\Downloads\\MARKET-master\\MARKET\\IMAGE\\accept.png";
            pictureBox1.Image = Image.FromFile(this.img);

            this.Hide();

        }

        public Form6(string label, string button1, string img, Form3 form3)
        {
            InitializeComponent();

            this.label = label1.Text;
            this.button1 = insert.Text;
            insert.FillColor = Color.Red;
            label1.ForeColor = Color.Red;
            guna2Panel1.BorderColor = Color.Red;
            label1.Text = "کــۆتــا بــەڕێــوبــەر نــاتــوانــدرێــت بــســڕێــتــەوە";
            this.img = "C:\\Users\\Fedyas Muhammad\\Downloads\\MARKET-master\\MARKET\\IMAGE\\warning.png";
            pictureBox1.Image = Image.FromFile(this.img);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        
      
            
            this.Hide();

           
        }

        private void Form6_Load(object sender, EventArgs e)
        {
              
        }

        private void delet_Click(object sender, EventArgs e)
        {

        }
    }
}
