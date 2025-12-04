using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace MARKET
{

    public partial class Form4 : Form
    {

        private int rowIndex;
        private Form3 form3;
        private Form2 form2;
        private Form6 form6;
        private Form4 form4;
        private int ID;
        private string label;
        private string labe2=null;
        private string button1;
        private string button2;
        private string button3;
        private string role;
        private string img;
        private string mode = "";



        public Form4(int rowID, int rowIndex,string lebal, Form3 form3)
        {
            InitializeComponent();
            this.rowIndex = rowIndex;
            this.form3 = form3;
            this.ID = rowID;
            this.role = role;
            Form1 form1;
            this.label = guna2HtmlLabel2.Text;
            guna2HtmlLabel2.Text = "دڵنیایت لە سـڕیـنـەوەی زانـاریـەکـە";
            mode = "delete";
            
        }
        public Form4(string label, Form2 form2)
        {

            InitializeComponent();
           
            this.form2 = form2;
            this.label = guna2HtmlLabel2.Text;
            guna2HtmlLabel2.Text = "دڵنیایت لە داخستنەوەی بەرنامەکە";
            mode = "exit";

        }
        public Form4(string label, Form3 form3)
        {

            InitializeComponent();

            this.form3 = form3;
            this.label = guna2HtmlLabel2.Text;
            guna2HtmlLabel2.Text = "دڵنیایت لە داخستنەوەی بەرنامەکە";
            mode = "exit";


        }
        public Form4(string label, Form1 form1)
        {

            InitializeComponent();
            
            this.label = guna2HtmlLabel2.Text;
           
            guna2HtmlLabel2.Text = "دڵنیایت لە داخستنەوەی بەرنامەکە";
            
            mode = "exit";


        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (mode == "delete" )
            {
               

                form3.DeleteRow(ID, rowIndex, role);

                Form6 form6 = new Form6(label, button1, img, this);
             


                form6.ShowDialog();
                this.Hide();
            }

             else if (mode == "exit"  )
            {
                // If it's the exit confirmation version
                Application.Exit();
            }
          
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        

      
    }
    }

