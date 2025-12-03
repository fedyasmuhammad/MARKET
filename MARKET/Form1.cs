using MARKET.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using Guna.UI2.WinForms;
using System.IO;




namespace MARKET
{

    public partial class Form1 : Form
    {
        string con ="Data Source=DESKTOP-HLB250B\\SQLEXPRESS;Initial Catalog=DB_MARKET;Integrated Security=True;TrustServerCertificate=True";


        string label;

        public Form1(string user_name, string pass, string role, string full_name,string image_path, byte[] IMAGE_PATH1)
        {
            InitializeComponent();


            
        }

        public Form1(string label, Form4 form4)
        {
            InitializeComponent();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
           
            SqlConnection connnn = new SqlConnection(con);
            
                try
                {
                    connnn.Open();
               // string query = "SELECT * FROM TBL_USER WHERE USER_NAME = @USER_NAME AND PASS = @PASS  AND ROLEE=@ROLEE ";
                string query = "SELECT * FROM TBL_USER WHERE USER_NAME = @USER_NAME COLLATE SQL_Latin1_General_CP1_CS_AS AND PASS = @PASS COLLATE SQL_Latin1_General_CP1_CS_AS   AND ROLEE = @ROLEE";

                SqlCommand cmd = new SqlCommand(query, connnn);
                
                    cmd.Parameters.AddWithValue("@USER_NAME",textbox1.Text);
                    cmd.Parameters.AddWithValue("@PASS", textbox2.Text);
                    cmd.Parameters.AddWithValue("@ROLEE",guna2ComboBox1.Text);

                  SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();  
                    if (dr.HasRows)
                    {

                    string user_name = dr["USER_NAME"].ToString();
                    string pass = dr["PASS"].ToString();
                    string role = dr["ROLEE"].ToString();
                    string full_name = dr["FULL_NAME"].ToString();
                    
                   string image_path = dr["IMAGE_PATH"].ToString();
                    byte[] IMAGE_PATH1 = null;
                    if (dr["IMAGE_PATH"] != DBNull.Value)
                    {
                        IMAGE_PATH1 = (byte[])dr["IMAGE_PATH"];
                    }

                    Form2 form2 = new Form2(user_name,pass,role, full_name, image_path,  IMAGE_PATH1);
                   
                    //form2.role=role ;          
                    //form2.fullname = full_name;
                    //form2.image_path = image_path;
                    //form2.IMAGE_PATH1 = IMAGE_PATH1;
                 
                    // form3.role=role ;

                      this.Hide();
                     form2.Show();

                    }
                
                    else
                {
                    textbox1.Clear();
                    textbox2.Clear();
                    guna2ComboBox1.Text = null;
                    textbox1.BorderColor=Color.Red;
                    textbox2.BorderColor=Color.Red ;
                    guna2ComboBox1.BorderColor=Color.Red ;  


                    guna2HtmlLabel1.Visible = true;
                    guna2HtmlLabel1.Show();
                   
                   


                }

                    dr.Close();
                    connnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
      


        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pass_lable_Click(object sender, EventArgs e)
        {



        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        

            Form4 form4 = new Form4(label, this);
            form4.ShowDialog();
                


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void picturebox1_Click(object sender, EventArgs e)
        {
            string imageFolder = Path.Combine(Application.StartupPath, "IMAGE");

            if (textbox2.PasswordChar == '*')
            {
                // Show password
                textbox2.PasswordChar = '\0'; // No masking character
              //  picturebox1.Image = Image.FromFile("eye-crossed.png"); // Set the open eye image
                picturebox1.Image = Image.FromFile(Path.Combine(imageFolder, "eye-crossed.png"));
            }
            else
            {

                // Hide password
                textbox2.PasswordChar = '*'; // Set the masking character
              //  picturebox1.Image = Image.FromFile("eye.png"); // Set the closed eye image
                picturebox1.Image = Image.FromFile(Path.Combine(imageFolder, "eye.png"));
            }
        }

        private void lastlabel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}