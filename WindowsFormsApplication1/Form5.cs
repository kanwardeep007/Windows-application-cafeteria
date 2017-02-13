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
    public partial class Form5 : Form
    {
        public Form5(String User)
        {
            InitializeComponent();
            fillDepartment();
            fillUser(User);
        }
        void fillUser(String username)
        {
            username_form5.Text = username;
        }

        void fillDepartment()
        {
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.department_table ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                // MessageBox.Show("Deleted");
                while (myReader.Read())
                {
                    string sName = myReader.GetString("department_name");
                    department_name.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        

       

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(department_id.Text))
            {
                MessageBox.Show("You need to enter department_id");
                m = false;
            }
            else if (string.IsNullOrEmpty(department_name.Text))
            {
                MessageBox.Show("You need to enter department_name");
                m = false;
            }
            
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                var cmdDataBase = conDataBase.CreateCommand();

                cmdDataBase.CommandText = @"insert into employee.department_table (iddepartment,department_name) values (@iddepartment,@department_name);";
                cmdDataBase.Parameters.AddWithValue("@iddepartment", this.department_id.Text);
                cmdDataBase.Parameters.AddWithValue("@department_name", this.department_name.Text);
                
                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show(this.department_name.Text + " has been added ");
                while (reader.Read())
                {

                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(department_id.Text))
            {
                MessageBox.Show("You need to enter department_id");
                m = false;
            }
            else if (string.IsNullOrEmpty(department_name.Text))
            {
                MessageBox.Show("You need to enter department_name");
                m = false;
            }
            
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                string Query = "UPDATE employee.department_table SET   department_name = '" + department_name.Text + "' where iddepartment = '" + this.department_id.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show(department_name.Text + " has been edited ");
                    while (myReader.Read())
                    {

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(department_id.Text))
            {
                MessageBox.Show("You need to enter department_id");
                m = false;
            }

            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                var cmdDataBase = conDataBase.CreateCommand();
                cmdDataBase.CommandText = @"delete from employee.department_table where iddepartment = @iddepartment;";
                cmdDataBase.Parameters.AddWithValue("@iddepartment", this.department_id.Text);
                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show(" Deleted ");
                while (reader.Read())
                {

                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Qty f2 = new Qty(username_form5.Text);
            f2.ShowDialog();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
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
