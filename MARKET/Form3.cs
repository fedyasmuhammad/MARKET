using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MARKET
{
    public partial class Form3 : Form
    {
        //internal Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        int Move;
        int MValX;
        int MValY;
        string label;
        string button1;
        string img;
        string img2;
        int adminCount;
        Form6 form6;
                string connecton = "Data Source=DESKTOP-HLB250B\\SQLEXPRESS;Initial Catalog=DB_MARKET;Integrated Security=True;TrustServerCertificate=True";

      
        public string loginUserName;
        public string loginPassword;
        public string loginRole;
        private string IMAGE_PATH = null;
       
        public string fullname;
        private byte[] imageBytes;
       // public byte[] IMAGE_PATH1;   
       public string image_path;
    




        public Form3(string user, string pass, string role, string full_name, string image_path, byte[] imageBytes)
        {
            InitializeComponent();
            this.loginUserName = user;
            this.loginPassword = pass;
            this.loginRole = role;
            this.fullname = full_name;
            this.image_path = image_path;
            this.imageBytes = imageBytes;

            //this.IMAGE_PATH1 = IMAGE_PATH1;


        }
        public void LoadData()
        {
            try
            {
                string query = "SELECT USER_ID,USER_NAME,PASS,ROLEE,FULL_NAME,IMAGE_PATH FROM TBL_USER";


                using (SqlConnection con = new SqlConnection(connecton))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        guna2DataGridView1.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An SQL error occurred while loading data: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message);
            }
        }


        public void insert()
        {
            try
            {
          

                string query = "INSERT INTO TBL_USER (FULL_NAME, USER_NAME, PASS, ROLEE, IMAGE_PATH) VALUES (@FULL_NAME, @USER_NAME, @PASS, @ROLEE, @IMAGE)";
                SqlConnection con = new SqlConnection(connecton);

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FULL_NAME", textbox1.Text);
                cmd.Parameters.AddWithValue("@USER_NAME", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@PASS", guna2TextBox2.Text);
                cmd.Parameters.AddWithValue("@ROLEE", guna2ComboBox2.Text);
                textbox1.Clear();
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                guna2ComboBox2.SelectedItem = null;

                string defaultImage = @"C:\Users\Fedyas Muhammad\Downloads\MARKET-master\MARKET\IMAGE\businessman.png";
                byte[] imageData;

                // CASE 1: User did NOT choose an image → use default
                if (string.IsNullOrEmpty(IMAGE_PATH) || !File.Exists(IMAGE_PATH))
                {
                    imageData = File.ReadAllBytes(defaultImage);

                    pictureBox1.Image = System.Drawing.Image.FromFile(defaultImage);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    // CASE 2: User selected an image → save chosen image
                    imageData = File.ReadAllBytes(IMAGE_PATH);

                    // After INSERT → Show default image again
                    pictureBox1.Image = System.Drawing.Image.FromFile(defaultImage);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    IMAGE_PATH = "";

                }

                // Add image to SQL
                cmd.Parameters.AddWithValue("@IMAGE", imageData);

                // Add byte[] to SQL parameter



                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {

                }
                else
                {
                    MessageBox.Show("No rows inserted. Please check your data.");
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exception
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



     

        private bool ValidatePassword(string password)
        {
            // Validate the password using a regex
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$");
        }

        private bool ValidateFullname(string fullname)
        {
            // Validate the password using a regex
            if (fullname.Length < 8) { return false; }

            return true;
            

        }

        // public string role { get; set; }

        private void Form3_Load(object sender, EventArgs e)
        {

            RemoveLastRow();
            LoadData();

            guna2DataGridView1.AllowUserToAddRows = false;

            // Attempt to remove or hide the last row
          


        }

        private void RemoveLastRow()
        {
            try
            {
                // Get the last row index
                int lastRowIndex = guna2DataGridView1.Rows.Count - 1;

                // Check if the last row is NOT a new row
                if (!guna2DataGridView1.Rows[lastRowIndex].IsNewRow)
                {
                    // Option 1: Hide the last row
                    guna2DataGridView1.Rows[lastRowIndex].Visible = false;


                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string fullname = textbox1.Text;
            if (!ValidateFullname(fullname))
            {

                MessageBox.Show("Full Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


         

            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password validation
            string password = guna2TextBox2.Text;
            if (!ValidatePassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and include both uppercase and lowercase letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2ComboBox2.Text))
            {
                MessageBox.Show("Role is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            insert();
            LoadData();
            string button10 = null;
            string button1 = null;
            string label = null;
            
            Form6 form6 = new Form6(label, button1, button10, img, this);

            form6.ShowDialog();

        }


        private void uploudButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Load the selected image into the PictureBox
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                // Save the image path
                IMAGE_PATH = openFileDialog.FileName;


            }

        }

        public void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {





            int deleteColumnIndex = 0; // Index of the delete column
            if (e.ColumnIndex == deleteColumnIndex && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex; // Store the row index
                int id = Convert.ToInt32(guna2DataGridView1.Rows[rowIndex].Cells["USER_ID"].Value); // Assuming "USER_ID" is your primary key
                string role = guna2DataGridView1.Rows[rowIndex].Cells["ROLEE"].Value.ToString(); // Get the role of the user
                string connectionString = "Data Source=DESKTOP-HLB250B\\SQLEXPRESS;Initial Catalog=DB_MARKET;Integrated Security=True;TrustServerCertificate=True";

                // Check if the user is an admin
                if (role == "بــەڕێــوبــەر")
                {
                    // Count the number of admins in the database
                    int adminCount = 0;
                    string countQuery = "SELECT COUNT(*) FROM TBL_USER WHERE ROLEE = N'بــەڕێــوبــەر'";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand countCmd = new SqlCommand(countQuery, con))
                        {
                            adminCount = (int)countCmd.ExecuteScalar();
                        }
                    }

                    // Debug: Show the actual count
                  //  MessageBox.Show($"Admin count: {adminCount}\nCurrent role: {role}", "Debug Info");

                    // If admin and only one admin left, show Form6
                    if (adminCount <= 1)
                    {
                        Form6 form6 = new Form6(label, button1, img, this); // Pass the necessary parameters
                        form6.ShowDialog();
                    }
                    else
                    {
                        // If admin and more than one admin, show Form4
                        Form4 form4 = new Form4(id, rowIndex,label, this); // Pass the necessary parameters
                        form4.ShowDialog();
                    }
                }
                else
                {
                    // If role is user, show Form4
                    Form4 form4 = new Form4(id, rowIndex,label, this); // Pass the necessary parameters
                    form4.ShowDialog();
                }
            }
        


























        ///////////////////////////////////////////

        int updateColumnIndex = 1;
            if (e.ColumnIndex == updateColumnIndex && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex; // Store the row index
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {


                }
                if (e.RowIndex >= 0) // Ensure a valid row is selected
                {
                    int id = Convert.ToInt32(guna2DataGridView1.Rows[rowIndex].Cells["USER_ID"].Value);
                    // Retrieve data from the selected row
                    string FULL_NAME = guna2DataGridView1.Rows[e.RowIndex].Cells["FULL_NAME"].Value.ToString();
                    string USER_NAME = guna2DataGridView1.Rows[e.RowIndex].Cells["USER_NAME"].Value.ToString();
                    string PASS = guna2DataGridView1.Rows[e.RowIndex].Cells["PASS"].Value.ToString();
                    string ROLEE = guna2DataGridView1.Rows[e.RowIndex].Cells["ROLEE"].Value.ToString();
                    var imageValue = guna2DataGridView1.Rows[e.RowIndex].Cells["IMAGE_PATH1"].Value;
                    byte[] imageData = null;
                    




                    if (guna2DataGridView1.Rows[e.RowIndex].Cells["IMAGE_PATH1"].Value != null)
                    {
                        imageData = (byte[])guna2DataGridView1.Rows[e.RowIndex].Cells["IMAGE_PATH1"].Value;
                    }




                    //var imageValue = guna2DataGridView1.Rows[e.RowIndex].Cells["IMAGE_PATH"].Value;
                    //if (imageValue != null && imageValue != DBNull.Value)
                    //{
                    //    imageData = (byte[])imageValue;
                    //}


                    // Open Form5 and pass data
                    Form5 form5 = new Form5(id, rowIndex, FULL_NAME, USER_NAME, PASS, ROLEE, imageData, this);
                    form5.ShowDialog();
                }



            }


        }



        public void DeleteRow(int id, int rowIndex, string role)
        {
            string connectionString = "Data Source=DESKTOP-HLB250B\\SQLEXPRESS;Initial Catalog=DB_MARKET;Integrated Security=True;TrustServerCertificate=True";

            // Check if the user being deleted is an Admin
            if (role == "بــەڕێــوبــەر")
            {
                string countQuery = "SELECT COUNT(*) FROM TBL_USER WHERE ROLEE = 'بــەڕێــوبــەر'";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand countCmd = new SqlCommand(countQuery, con))
                    {
                        int adminCount = (int)countCmd.ExecuteScalar();

                        // Prevent deletion if only one admin exists
                       
                    }
                }
            }

            // Proceed to delete the user if it's not the last admin
            string deleteQuery = "DELETE FROM TBL_USER WHERE USER_ID = @ID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }

            // Remove the row from the DataGridView if it exists
            if (rowIndex >= 0 && rowIndex < guna2DataGridView1.Rows.Count)
            {
                guna2DataGridView1.Rows.RemoveAt(rowIndex);
            }
        }






        public void Update(int id, int rowIndex, string FULL_NAME, string USER_NAME, string PASS, string ROLEE, string IMAGE_PATH)
        {
            using (SqlConnection connection = new SqlConnection(connecton))
            {
                try
                {
                    connection.Open();

                    // Check if we need to update the image
                    string query;
                    SqlCommand command;

                    if (!string.IsNullOrEmpty(IMAGE_PATH) && File.Exists(IMAGE_PATH))
                    {
                        // Update with new image - include IMAGE_PATH in the query
                        query = "UPDATE TBL_USER SET FULL_NAME = @FullName, USER_NAME = @Username, PASS = @Pass, ROLEE = @Rolee, IMAGE_PATH = @Image WHERE USER_ID = @Id";
                        command = new SqlCommand(query, connection);

                        // Add all parameters including image
                        command.Parameters.AddWithValue("@FullName", FULL_NAME);
                        command.Parameters.AddWithValue("@Username", USER_NAME);
                        command.Parameters.AddWithValue("@Pass", PASS);
                        command.Parameters.AddWithValue("@Rolee", ROLEE);
                        command.Parameters.AddWithValue("@Id", id);

                        // Convert image file to byte array for database storage
                        byte[] imageData = File.ReadAllBytes(IMAGE_PATH);
                        command.Parameters.AddWithValue("@Image", imageData);
                    }
                    else
                    {
                        // Update without changing the image - exclude IMAGE_PATH from query
                        query = "UPDATE TBL_USER SET FULL_NAME = @FullName, USER_NAME = @Username, PASS = @Pass, ROLEE = @Rolee WHERE USER_ID = @Id";
                        command = new SqlCommand(query, connection);

                        // Add parameters without image
                        command.Parameters.AddWithValue("@FullName", FULL_NAME);
                        command.Parameters.AddWithValue("@Username", USER_NAME);
                        command.Parameters.AddWithValue("@Pass", PASS);
                        command.Parameters.AddWithValue("@Rolee", ROLEE);
                        command.Parameters.AddWithValue("@Id", id);
                    }

                    int rowsAffected = command.ExecuteNonQuery();

                  
                        

                       

                        

                        // Update DataGridView to reflect changes
                        if (rowIndex >= 0 && rowIndex < guna2DataGridView1.Rows.Count)
                        {
                            guna2DataGridView1.Rows[rowIndex].Cells["FULL_NAME"].Value = FULL_NAME;
                            guna2DataGridView1.Rows[rowIndex].Cells["USER_NAME"].Value = USER_NAME;
                            guna2DataGridView1.Rows[rowIndex].Cells["PASS"].Value = PASS;
                            guna2DataGridView1.Rows[rowIndex].Cells["ROLEE"].Value = ROLEE;

                            // If image was updated, you might want to refresh the entire grid
                            // to show the new image data
                            if (!string.IsNullOrEmpty(IMAGE_PATH) && File.Exists(IMAGE_PATH))
                            {
                                LoadData(); // Refresh the entire grid to show updated image
                            }
                        }
                    
                    else
                    {
                        MessageBox.Show("No rows were updated. Please check the data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating record: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
    }
       







































        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)

            {
                //Form2 fr2 = new Form2();
                this.WindowState = FormWindowState.Normal;
                this.Size = new System.Drawing.Size(1280, 720);
                // Manually center the form on the screen
                this.Location = new System.Drawing.Point(
                    (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                    (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);


            }

            else { this.WindowState = FormWindowState.Maximized; }



        
    }

        private void guna2Button1_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void guna2Button1_MouseUp(object sender, MouseEventArgs e)
        {
       
        }

        private void guna2Button1_MouseMove(object sender, MouseEventArgs e)
        {
       
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1; // Enable move
            MValX = e.X; // Get current mouse X coordinate
            MValY = e.Y; // Get current mouse Y coordinate
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                // Update the form location based on mouse movement
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button4_Click(object sender, EventArgs e)

        {







            Form2 form2 = new Form2(loginUserName, loginPassword, loginRole, fullname, image_path, imageBytes);

            this.Hide();
            form2.ShowDialog();
            this.Close();


            //user_name,pass,role, full_name, image_path,  IMAGE_PATH1







        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
           
            Form4 form4 = new Form4(label,this);
            form4.ShowDialog();
        }
    }
}
