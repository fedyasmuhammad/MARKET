using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MARKET
{
    public partial class Form2 : Form
    {

     
        int Move;
        int MValX;
        int MValY;
        string label;
        Form2 form2;
        Form3 form3;
        public string fullname;



        public string image_path;
        public byte[] IMAGE_PATH1;
        public string loginUserName;
        public string loginPassword;
        public string loginRole;



        public Form2(string user, string pass, string role, string full_name, string image_path, byte[] IMAGE_PATH1)
        {
            InitializeComponent();
            this.loginUserName = user;
            this.loginPassword = pass;
            this.loginRole = role;
            this.fullname = full_name;

            this.image_path = image_path;
            this.IMAGE_PATH1 = IMAGE_PATH1;

        }
       // public Form2(string user, string pass, string role, string full_name, string image_path, byte[] IMAGE_PATH1,Form3 form3)
       //{
       //     this.IMAGE_PATH1 = IMAGE_PATH1;
       //     InitializeComponent();

       //}  







        private void Form2_Load(object sender, EventArgs e)
            
        {
           
            label21.Text =fullname;
            label2.Text = loginRole;

            if (IMAGE_PATH1 != null && IMAGE_PATH1.Length > 0)
            {
                MemoryStream ms = new MemoryStream(IMAGE_PATH1);
                byte[] imageData = ms.ToArray();
                guna2CirclePictureBox1.Image = Image.FromStream(ms);


               // guna2CirclePictureBox1.Image = Image.FromFile(image_path);
               // guna2CirclePictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image display
            }
            else
            {
                // Option 1: Load a default image from file
                string defaultImagePath = "C:\\Users\\Fedyas Muhammad\\Downloads\\MARKET-master\\MARKET\\IMAGE\\businessman.png"; // Make sure this file exists in your project directory
               
                if (System.IO.File.Exists(defaultImagePath))
                {
                   
                    guna2CirclePictureBox1.Image = Image.FromFile(defaultImagePath);
                }

            }




        }

        private void Form2_MouseDown_1(object sender, MouseEventArgs e)
        {
            Move = 1; // Enable move
            MValX = e.X; // Get current mouse X coordinate
            MValY = e.Y; // Get current mouse Y coordinate

        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
           Move = 0; // Disable move
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                // Update the form location based on mouse movement
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)

            {
                //Form2 fr2 = new Form2();
                this.WindowState = FormWindowState.Normal;
                this.Size = new System.Drawing.Size(1280,720);
                // Manually center the form on the screen
                this.Location = new System.Drawing.Point(
                    (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
           }

            else { this.WindowState = FormWindowState.Maximized; }

        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TileButton14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TileButton13_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (loginRole == "بــەڕێــوبــەر")  // admin
            {
                Form3 form3 = new Form3(loginUserName, loginPassword, loginRole, fullname, image_path, IMAGE_PATH1);


                this.Hide();
                form3.ShowDialog();
                this.Show(); // return to Form2 after closing Form3
            }
            else
            {
                guna2MessageDialog1.Show();
            }
        }

        private void guna2TileButton7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            

            
            Form4 form4 = new Form4(label,this);
            form4.ShowDialog();
             
           
        }

        private void guna2TileButton11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}