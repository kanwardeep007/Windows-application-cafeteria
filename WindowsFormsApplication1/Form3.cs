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
    public partial class Form3 : Form
    {
        public Form3(String User)
        {
            InitializeComponent();
            fillUser(User);
            fillItems();
        
        }
        void fillItems()
        {
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.items ;";
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
                    string sName = myReader.GetString("item_name");
                    item_name_box.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void fillUser(String username)
        {
            username_form3.Text = username;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
            if (string.IsNullOrEmpty(item_id_box.Text))
            {
                MessageBox.Show("You need to enter item_id");
                m = false;
            }
            else if (string.IsNullOrEmpty(item_name_box.Text))
            {
                MessageBox.Show("You need to enter item_name");
                m = false;
            }
            else if (string.IsNullOrEmpty(item_price_box.Text))
            {
                MessageBox.Show("You need to enter item_price");
                m = false;
            }
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                var cmdDataBase = conDataBase.CreateCommand();

                cmdDataBase.CommandText = @"insert into employee.items (iditems,item_name,item_price) values (@iditems,@item_name,@item_price);";
                cmdDataBase.Parameters.AddWithValue("@iditems", this.item_id_box.Text);
                cmdDataBase.Parameters.AddWithValue("@item_name", this.item_name_box.Text);
                cmdDataBase.Parameters.AddWithValue("@item_price", this.item_price_box.Text);
                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show(this.item_name_box.Text + "has been added");
                while (reader.Read())
                {

                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(item_id_box.Text))
            {
                MessageBox.Show("You need to enter item_id");
                m = false;
            }
            else if (string.IsNullOrEmpty(item_name_box.Text))
            {
                MessageBox.Show("You need to enter item_name");
                m = false;
            }
            else if (string.IsNullOrEmpty(item_price_box.Text))
            {
                MessageBox.Show("You need to enter item_price");
                m = false;
            }
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                string Query = "UPDATE employee.items SET   item_name = '" + this.item_name_box.Text + "', item_price = '" + this.item_price_box.Text + "' where iditems = '" + this.item_id_box.Text + "' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show(item_name_box.Text + " has been edited");
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
            if (string.IsNullOrEmpty(item_id_box.Text))
            {
                MessageBox.Show("You need to enter item_id");
                m = false;
            }

            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                var cmdDataBase = conDataBase.CreateCommand();
                cmdDataBase.CommandText = @"delete from employee.items where iditems = @iditems;";
                cmdDataBase.Parameters.AddWithValue("@iditems", this.item_id_box.Text);
                try
                {
                    conDataBase.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MySqlDataReader reader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Deleted");
                while (reader.Read())
                {

                }
            }
        }

        private void back_form3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Qty f2 = new Qty(username_form3.Text);
            f2.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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
