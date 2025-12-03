using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;
using System.Security.Cryptography.X509Certificates;
using System.IO;


namespace MARKET
{
    public partial class Form5 : Form
    {

        int id;
        int rowIndex;
        string FULL_NAME;
        string USER_NAME;
        string PASS;
        string ROLEE;
        private byte[] imageData; // Store image as byte array
        private string IMAGE_PATH; // For new image uploads
        private Form3 form3;
        string label;
        string button1;
        String img;

        string connecton = "Data Source=DESKTOP-HLB250B\\SQLEXPRESS;Initial Catalog=DB_MARKET;Integrated Security=True;TrustServerCertificate=True";
        public Form5(int id, int rowIndex, string FULL_NAME, string USER_NAME, string PASS, string ROLEE, byte[] imageData, Form3 form3)
        {
            InitializeComponent();

            this.id = id;
            this.rowIndex = rowIndex;
            this.FULL_NAME = FULL_NAME;
            this.USER_NAME = USER_NAME;
            this.PASS = PASS;
            this.ROLEE = ROLEE;
            this.imageData = imageData;
            this.form3 = form3;


            textbox1.Text = FULL_NAME;
            guna2TextBox1.Text = USER_NAME;
            guna2TextBox2.Text = PASS;
            guna2ComboBox2.Text = ROLEE;

            // Load the image into PictureBox
            LoadImageToPictureBox();
            // Load the image into the PictureBox
        }
        private void LoadImageToPictureBox()
        {
            try
            {
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Set a default image or leave empty
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}");
                pictureBox1.Image = null;
            }
        }
    

    private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }






        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Determine which image to use - new upload or existing
            string imagePath = !string.IsNullOrEmpty(IMAGE_PATH) ? IMAGE_PATH : null;

            form3.Update(
                id,
                rowIndex,
                textbox1.Text,           // FULL_NAME
                guna2TextBox1.Text,      // USER_NAME
                guna2TextBox2.Text,      // PASS
                guna2ComboBox2.Text,     // ROLEE
                imagePath                // Use the new image path if uploaded, otherwise null
            );
            Form5 form5 =new Form5( id,  rowIndex,  FULL_NAME,  USER_NAME,  PASS,  ROLEE, imageData,  form3);
             this.Close();
                
            Form6 form6 = new Form6( label,button1,img,this);
        
             form6.ShowDialog();    


        }

        private void uploudButton_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Load the selected image into the PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                // Save the image path
                IMAGE_PATH = openFileDialog.FileName;
             


            }
        }
    }
}
