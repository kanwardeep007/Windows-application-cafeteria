using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4(string User)
        {
            InitializeComponent();
            autoCompleteText();
            fillUser(User);
            password_box.PasswordChar = '*';
            fillpostbox();
        
        }


        void autoCompleteText()
        {
            username_box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            username_box.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.employeeinfo ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();


                while (myReader.Read())
                {
                    string sname = myReader.GetString("username");
                    coll.Add(sname);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            username_box.AutoCompleteCustomSource = coll;

        }

        void fillpostbox()
        {
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.employeeinfo ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                post_box.Items.Add("admin");
                post_box.Items.Add("operator");
                // MessageBox.Show("Deleted");
                while (myReader.Read())
                {
                    //string sName = myReader.GetString("post");
                    //post_box.Items.Add(sName);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void fillUser(String username)
        {
            username_form4.Text = username;
        }
        private void add_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(username_box.Text))
            {
                MessageBox.Show("You need to enter username");
                 m = false;
            }
            else if(string.IsNullOrEmpty(password_box.Text))
            {
                MessageBox.Show("You need to enter password");
                 m = false;
            }
            else if (string.IsNullOrEmpty(post_box.Text))
            {
                MessageBox.Show("You need to enter post");
                 m = false;
            }



            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = conDataBase.CreateCommand();
                cmdDataBase.CommandText = "insert into employee.employeeinfo (username,password,post) values (@username,@password,@post);";
                cmdDataBase.Parameters.AddWithValue("@username", this.username_box.Text);
                cmdDataBase.Parameters.AddWithValue("@password", this.password_box.Text);
                cmdDataBase.Parameters.AddWithValue("@post", this.post_box.Text);
                //MessageBox.Show("Added");
                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show(this.username_box.Text + " Added");
                while (reader.Read())
                {

                }
            }
            
            
        }

        private void edit_Click(object sender, EventArgs e)
        {

            //item_name = '" + item_name_box.Text + "', item_price = '" + item_name_box + "' where iditems = '" + this.item_id_box.Text + "' ;";
            Boolean m = true;
            if (string.IsNullOrEmpty(username_box.Text))
            {
                MessageBox.Show("You need to enter username");
                m = false;
            }
            else if (string.IsNullOrEmpty(password_box.Text))
            {
                MessageBox.Show("You need to enter password");
                m = false;
            }
            else if (string.IsNullOrEmpty(post_box.Text))
            {
                MessageBox.Show("You need to enter post");
                m = false;
            }
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = conDataBase.CreateCommand();

                cmdDataBase.CommandText = "UPDATE employee.employeeinfo SET password =@password , post = @post  where username = @username;";
                cmdDataBase.Parameters.AddWithValue("@username", this.username_box.Text);
                cmdDataBase.Parameters.AddWithValue("@password", this.password_box.Text);
                cmdDataBase.Parameters.AddWithValue("@post", this.post_box.Text);

                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show(this.username_box.Text + " has been Edited");
                while (reader.Read())
                {

                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(username_box.Text))
            {
                MessageBox.Show("You need to enter username");
                m = false;
            }
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                var cmdDataBase = conDataBase.CreateCommand();
                cmdDataBase.CommandText = @"delete from employee.employeeinfo where username = @username;";
                cmdDataBase.Parameters.AddWithValue("@username", this.username_box.Text);
                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show( this.username_box.Text + " has been Deleted");
                while (reader.Read())
                {

                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Qty f2 = new Qty(username_form4.Text);
            f2.ShowDialog();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program ?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
