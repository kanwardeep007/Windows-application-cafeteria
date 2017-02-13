using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            autoCompleteText();
            password_txt.PasswordChar = '*';
            fillpostbox();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection myConn = new MySqlConnection(myConnection);
               // MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
               // myDataAdapter.SelectCommand = new MySqlCommand("select * employee.employeeinfo;", myConn);
               //MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                MySqlCommand SelectCommand = new MySqlCommand("select * from employee.employeeinfo where username = '" + this.username_txt.Text + "' and password= '" + this.password_txt.Text + "' and post = '" + post_box.Text+ "';", myConn);
                MySqlDataReader myReader;
                myConn.Open();
                //DataSet ds = new DataSet();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                //MessageBox.Show("Connected");
                
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    
                    //MessageBox.Show("Username and password correct");
                    this.Hide();
                    Qty f2 = new Qty("Hello " + username_txt.Text +"_"+ post_box.Text);

                    f2.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("duplicate username and password.So access denied");
                }
                else
                    MessageBox.Show("Username or Password  or Post incorrect");
                myConn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    //if (post_box.Items.ToString() != sName)
                    //{
                    //    post_box.Items.Add(sName);
                    //}
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void autoCompleteText()
        {
            username_txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            username_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            username_txt.AutoCompleteCustomSource = coll;

        }

        
        

        
    }
}
