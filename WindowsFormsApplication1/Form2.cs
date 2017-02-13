using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApplication1
{
    public partial class Qty : Form
    {
        int totalbill = 0;
        public Qty(String User)
        {
            InitializeComponent();
            fillComboDepartment();
            fillItems();
            //fillBillNo();
            fillUser(User);
            generateFormAccordingToPost();

        }


        void clickLoadData()
        {
            string additionalString = "";
            string shown_itemsName ="";
            Boolean m = true;
            if (string.IsNullOrEmpty(department.Text))
            {
                MessageBox.Show("You need to choose Department and Date");
                m = false;
            }
            if (m == true)
            {
                // MessageBox.Show(dateTimePicker1.Value.Month.ToString());
                //string month = dateTimePicker1.Value.ToString("MMMM");
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                var cmdDataBase2 = conDataBase.CreateCommand();
                cmdDataBase2.CommandText = @"select group_concat(shown_itemsname) as 'columnname' from (select distinct shown_itemsname  from employee.transaction_shown where shown_departmentname = @department and month(shown_date) = @month_ and year(shown_date) = @year_) as x;";
                cmdDataBase2.Parameters.AddWithValue("@department", this.department.Text);
                cmdDataBase2.Parameters.AddWithValue("@month_", this.dateTimePicker1.Value.Month);
                cmdDataBase2.Parameters.AddWithValue("@year_", this.dateTimePicker1.Value.Year);
                //MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    shown_itemsName = cmdDataBase2.ExecuteScalar().ToString();
                    
                    //MessageBox.Show("Added");
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                additionalString = "billno,department,date,subtotal,";
                shown_itemsName = additionalString+shown_itemsName;
                textBox1.Text = shown_itemsName;
                //MessageBox.Show(shown_itemsName);

                var cmdDataBase = conDataBase.CreateCommand();

                /*
                cmdDataBase.CommandText = @"select * from employee.transaction where department = @department AND month_ = @month_ AND year_ = @year_";
                //cmdDataBase.CommandText = @"select * from employee.transaction where department = @department;";
                cmdDataBase.Parameters.AddWithValue("@department", this.department.Text);
                cmdDataBase.Parameters.AddWithValue("@month_", this.dateTimePicker1.Value.Month);
                cmdDataBase.Parameters.AddWithValue("@year_", this.dateTimePicker1.Value.Year);
                */
                //'"+shown_itemsName+"'
                //cmdDataBase.CommandText = "select @shown_itemsName from employee.transaction where department = @department AND MONTH(date) = @month_ AND YEAR(date) = @year_";
                //cmdDataBase.Parameters.AddWithValue("@shown_itemsName", textBox1.Text);
                //cmdDataBase.Parameters.AddWithValue("@department", this.department.Text);
                //cmdDataBase.Parameters.AddWithValue("@month_", this.dateTimePicker1.Value.Month);
                //cmdDataBase.Parameters.AddWithValue("@year_", this.dateTimePicker1.Value.Year);


                cmdDataBase.CommandText = "select " + shown_itemsName + " from employee.transaction where department = @department AND MONTH(date) = @month_ AND YEAR(date) = @year_";

                cmdDataBase.Parameters.AddWithValue("@department", this.department.Text);
                cmdDataBase.Parameters.AddWithValue("@month_", this.dateTimePicker1.Value.Month);
                cmdDataBase.Parameters.AddWithValue("@year_", this.dateTimePicker1.Value.Year);

                using (var reader = cmdDataBase.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // ...
                    }
                    reader.Close();
                }

                // MySqlCommand cmdDataBase = new MySqlCommand("select * from employee.transaction  where department = '" + this.department.Text + "' and month = '" + this.dateTimePicker1.Value.Month.ToString() + "' and year = '" + this.dateTimePicker1.Value.Year.ToString() + "' ;", conDataBase);
                try
                {
                    // showing data in data grid view here
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda.SelectCommand = cmdDataBase;
                    DataTable dbdataset = new DataTable();
                    sda.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();

                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    sda.Update(dbdataset);

                    //DataGridViewColumn column = dataGridView1.Columns[0];
                    //column.Width = 300;
                    //creating Excel file here
                    DataSet ds = new DataSet("New_DataSet");

                    ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                    //finding total bill here
                    int sum = 0;
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    }
                    //messagebox.show(sum.tostring());

                    //string sql = "select * from employee.transaction where department = '" + this.department.text + "' and month = '" + month + "';";

                    //    "C:\\Users\\dell\\Desktop\\bill_files\\"
                    ds.Tables.Add(dbdataset);
                    ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\Users\\dell\\Desktop\\bill_files\\" + this.department.Text + this.dateTimePicker1.Value.Month + "-" + this.dateTimePicker1.Value.Year + ".xls", ds);
                   // C:\Users\Admin\Desktop\bill_files
                    //string file = this.department.Text + this.dateTimePicker1.Value.Month + "-" + this.dateTimePicker1.Value.Year + ".xls";
                    //Workbook book = Workbook.Load(file);
                    //Worksheet sheet = book.Worksheets[0];
                    //sheet.Cells[1, 1] = new Cell(sum);
                    //book.Worksheets.Add(sheet);
                    //book.Save(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"this was from click load data");
                }
            }
        }
        void generateFormAccordingToPost()
        {
            if (user_name.Text.Contains("admin") == false)
            {
                edit_accounts.Visible = false;
                edit_items.Visible = false;
                add_department.Visible = false;
            }
            else
            {

            }
        }

        void fillUser(String username)
        {
            user_name.Text = username;
        }

        void fillBillNo()
        {
            string billno_in_string;
            int bill = 0;
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.transaction ;";
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

                    int billno = myReader.GetInt32("billno");
                    if (billno > bill)
                    {
                        bill = billno;
                    }
                }
                bill = bill + 1;
                billno_in_string = bill.ToString();
                bill_no_txt.Text = billno_in_string;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillComboDepartment()
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
                    department.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    items.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click_1(object sender, EventArgs e)
        {
            fillBillNo();
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            var cmdDataBase = conDataBase.CreateCommand();

            cmdDataBase.CommandText = @"insert into employee.transaction (billno,date,subtotal) values (@billno,@date,0)";
            cmdDataBase.Parameters.AddWithValue("@billno", this.bill_no_txt.Text);
            cmdDataBase.Parameters.AddWithValue("@date", this.dateTimePicker1.Text);
            //cmdDataBase.Parameters.AddWithValue("@month_", this.dateTimePicker1.Value.Month);
            //cmdDataBase.Parameters.AddWithValue("@year_", this.dateTimePicker1.Value.Year);
            cmdDataBase.Parameters.AddWithValue("@subtotal", this.dateTimePicker1.Value.Year);



            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                //MessageBox.Show("Added");
                while (myReader.Read())
                {

                }
                department.SelectedIndex = -1;
                items.SelectedIndex = -1;
                quantity.Text = "";
                price.Text = "";
                subtotal_txt.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            conDataBase.Close();

        }


        private void update_Click(object sender, EventArgs e)
        {



            //string departmentID = "";
            //string itemID = "";
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "UPDATE employee.transaction SET   department = '" + this.department.Text + "'," + this.items.Text + "=  ' " + this.quantity.Text + " ' , date = '" + this.dateTimePicker1.Text + "', subtotal = subtotal + '" + subtotal_txt.Text + "' where billno = ' " + this.bill_no_txt.Text + " ' ;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show(this.items.Text + " has been added");
                while (myReader.Read())
                {

                }
                //fillBillNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conDataBase.Close();
            var cmdDataBase4 = conDataBase.CreateCommand();
            cmdDataBase4.CommandText = "insert into employee.transaction_shown (shown_departmentname,shown_itemsname,shown_date,shown_billno,shown_quantity) values (@shown_departmentname,@shown_itemsname,@shown_date,@shown_billno,@shown_quantity) ;";
            cmdDataBase4.Parameters.AddWithValue("@shown_departmentname", department.Text);
            cmdDataBase4.Parameters.AddWithValue("@shown_itemsname", items.Text);
            cmdDataBase4.Parameters.AddWithValue("@shown_date", this.dateTimePicker1.Text);
            cmdDataBase4.Parameters.AddWithValue("@shown_billno", this.bill_no_txt.Text);
            cmdDataBase4.Parameters.AddWithValue("@shown_quantity", this.quantity.Text);

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase4.ExecuteReader();
                //MessageBox.Show("Added");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message);
            }
            conDataBase.Close();
            load_data_method();
            items.SelectedIndex = -1;
            quantity.Text = "";
            price.Text = "";
            subtotal_txt.Text = "";
            conDataBase.Close();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(bill_no_txt.Text))
            {
                MessageBox.Show("Choose bill number which you want to delete");
                m = false;
            }
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                string Query = "delete from employee.transaction where billno = '" + this.bill_no_txt.Text + "';";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show(this.bill_no_txt.Text + " bill no has been deleted");
                    while (myReader.Read())
                    {

                    }
                    //fillBillNo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conDataBase.Close();
            }
        }

        void load_data_method()
        {
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            var cmdDataBase = conDataBase.CreateCommand();
            //cmdDataBase.CommandText = @"select * from employee.transaction_shown where shown_departmentname = @department and MONTH(shown_date) = @month and YEAR(shown_date) = @year;";

            cmdDataBase.CommandText = @"select * from employee.transaction_shown where shown_departmentname = @department and shown_date = @shown_date and shown_billno = @shown_billno;";
            cmdDataBase.Parameters.AddWithValue("@department", department.Text);
            //cmdDataBase.Parameters.AddWithValue("@month", this.dateTimePicker1.Value.Month);
            //cmdDataBase.Parameters.AddWithValue("@year", this.dateTimePicker1.Value.Year);
            cmdDataBase.Parameters.AddWithValue("@shown_date", this.dateTimePicker1.Text);
            cmdDataBase.Parameters.AddWithValue("@shown_billno", this.bill_no_txt.Text);
            try
            {
                // showing data in data grid view here
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView2.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void load_data_Click(object sender, EventArgs e)
        {

            try
            {
                clickLoadData();
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                }
                //if (string.IsNullOrEmpty(department.Text))
                //{
                //    MessageBox.Show("Choose the department and the date (choose month by choosing any date in that month)");
                //}
                //else
                //{
                totalbill = sum;
                // MessageBox.Show(sum.ToString());
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            //string Query3 = "select * from employee.department_table where department_name = '"+department.Text+"';";
            //MySqlCommand cmdDataBase3 = new MySqlCommand(Query3, conDataBase);
            //MySqlDataReader myReader;
            //try
            //{

            //    conDataBase.Open();
            //    myReader = cmdDataBase3.ExecuteReader();
            //    // MessageBox.Show("Deleted");
            //    while (myReader.Read())
            //    {
            //        departmentID = myReader.GetString("iddepartment");
            //    }
            //}
            //catch (Exception ex3)
            //{
            //    MessageBox.Show(ex3.Message);
            //}
            conDataBase.Close();
            //string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            //MySqlConnection conDataBase = new MySqlConnection(constring);
            load_data_method();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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



        private void items_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.items where item_name = '" + items.Text + "';";
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
                    string sName = myReader.GetString("item_price");
                    price.Text = sName;
                    int x = Int32.Parse(price.Text);

                    if (string.IsNullOrEmpty(quantity.Text))
                    {
                        int y = 0;
                        int subtotal_sum = x * y;
                        string myString = subtotal_sum.ToString();
                        subtotal_txt.Text = myString;
                    }

                    //if (Int32.Parse(quantity.Text) == 0)
                    //{
                    //    int y = 0;
                    //    int subtotal_sum = x * y;
                    //    string myString = subtotal_sum.ToString();
                    //    subtotal_txt.Text = myString;
                    //}
                    else
                    {
                        int y = Int32.Parse(quantity.Text);
                        int subtotal_sum = x * y;
                        string myString = subtotal_sum.ToString();
                        subtotal_txt.Text = myString;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conDataBase.Close();
        }

        //private void next_Click(object sender, EventArgs e)
        //{
        //   // MessageBox.Show(this.dateTimePicker1.Text);
        //    //fillBillNo();
        //    //string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
        //    //string Query = "insert into employee.transaction (billno,date,month,year) values ('" + this.bill_no_txt.Text + "','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker1.Value.Month.ToString() + "','" + this.dateTimePicker1.Value.Year.ToString() + "') ;";
        //   // MySqlConnection conDataBase = new MySqlConnection(constring);
        //   // MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

        //    string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
        //    MySqlConnection conDataBase = new MySqlConnection(constring);
        //    var cmdDataBase = conDataBase.CreateCommand();

        //    cmdDataBase.CommandText = @"insert into employee.transaction (billno,date,month_,year_,subtotal) values (@billno,@date,@month_,@year_,0)";
        //    cmdDataBase.Parameters.AddWithValue("@billno", this.bill_no_txt.Text);
        //    cmdDataBase.Parameters.AddWithValue("@date", this.dateTimePicker1.Text);
        //    cmdDataBase.Parameters.AddWithValue("@month_", this.dateTimePicker1.Value.Month);
        //    cmdDataBase.Parameters.AddWithValue("@year_", this.dateTimePicker1.Value.Year);
        //    //cmdDataBase.Parameters.AddWithValue("@subtotal", this.dateTimePicker1.Value.Year);



        //    MySqlDataReader myReader;
        //    try
        //    {
        //        conDataBase.Open();
        //        myReader = cmdDataBase.ExecuteReader();
        //        //MessageBox.Show("Added");
        //        while (myReader.Read())
        //        {

        //        }
        //        department.Text = "";
        //        items.Text = "";
        //        quantity.Text = "";
        //        price.Text = "";
        //        subtotal_txt.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }



        //}

        private void button1_Click(object sender, EventArgs e)
        {


        }



        private void total_bill_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(department.Text))
            {
                MessageBox.Show("You need to choose Department and Date");
                m = false;
            }
            if (m == true)
            {
                try
                {
                    clickLoadData();
                    int sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    }
                    //if (string.IsNullOrEmpty(department.Text))
                    //{
                    //    MessageBox.Show("Choose the department and the date (choose month by choosing any date in that month)");
                    //}
                    //else
                    {
                        string departmentname = this.department.Text;
                        string month = this.dateTimePicker1.Value.Month.ToString();
                        string year = this.dateTimePicker1.Value.Year.ToString();

                        totalbill = sum;
                        MessageBox.Show("Total bill for department - " + departmentname + " in " + month + " / " + year + "  is  " + sum.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void edit_items_Click(object sender, EventArgs e)
        {
            if (user_name.Text.Contains("admin") == false)
            {
                MessageBox.Show("You are not authorized to edit items.Only Admin is allowed.");
            }
            else
            {
                this.Hide();
                Form3 f3 = new Form3(user_name.Text);

                f3.ShowDialog();
            }
        }

        private void edit_accounts_Click(object sender, EventArgs e)
        {
            if (user_name.Text.Contains("admin") == false)
            {
                MessageBox.Show("You are not authorized to edit items.Only Admin is allowed.");
            }
            else
            {
                this.Hide();
                Form4 f4 = new Form4(user_name.Text);

                f4.ShowDialog();
            }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();

            f1.ShowDialog();
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            string Query = "select * from employee.items where item_name = '" + items.Text + "';";
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
                    string sName = myReader.GetString("item_price");
                    price.Text = sName;
                    int x = Int32.Parse(price.Text);

                    if (string.IsNullOrEmpty(quantity.Text))
                    {
                        int y = 0;
                        int subtotal_sum = x * y;
                        string myString = subtotal_sum.ToString();
                        subtotal_txt.Text = myString;
                    }

                    //if (Int32.Parse(quantity.Text) == 0)
                    //{
                    //    int y = 0;
                    //    int subtotal_sum = x * y;
                    //    string myString = subtotal_sum.ToString();
                    //    subtotal_txt.Text = myString;
                    //}
                    else
                    {
                        int y = Int32.Parse(quantity.Text);
                        int subtotal_sum = x * y;
                        string myString = subtotal_sum.ToString();
                        subtotal_txt.Text = myString;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void show_all_data_Click(object sender, EventArgs e)
        {
            //string constring1 = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            //MySqlConnection conDataBase1 = new MySqlConnection(constring1);
            //var cmdDataBase1 = conDataBase1.CreateCommand();
            //cmdDataBase1.CommandText = @"select * from employee.transaction_shown ;";
            //try
            //{
            //    // showing all data in data grid view here
            //    MySqlDataAdapter sda = new MySqlDataAdapter();
            //    sda.SelectCommand = cmdDataBase1;
            //    DataTable dbdataset1 = new DataTable();
            //    sda.Fill(dbdataset1);
            //    BindingSource bSource1 = new BindingSource();

            //    bSource1.DataSource = dbdataset1;
            //    dataGridView2.DataSource = bSource1;
            //    sda.Update(dbdataset1);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}



            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            dataGridView1.Visible = true;

            string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            var cmdDataBase = conDataBase.CreateCommand();
            cmdDataBase.CommandText = @"select * from employee.transaction ;";
            try
            {
                // showing all data in data grid view here
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //    if (e.RowIndex >= 0)
            //    {
            //        DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //        bill_no_txt.Text = row.Cells["billno"].Value.ToString();
            //    }
        }

        private void save_excel_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(department.Text))
            {
                MessageBox.Show("You need to choose Department and Date");
                m = false;
            }
            if (m == true)
            {
                try
                {
                    string file = this.department.Text + this.dateTimePicker1.Value.Month + "-" + this.dateTimePicker1.Value.Year + ".xls";
                    clickLoadData();
                    MessageBox.Show(file + " file saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void save_pdf_Click(object sender, EventArgs e)
        {
            {
                Boolean m = true;
                if (string.IsNullOrEmpty(department.Text))
                {
                    MessageBox.Show("You need to choose Department and Date");
                    m = false;
                }
                if (m == true)
                {
                    try
                    {
                        clickLoadData();
                        int sum = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                        }
                        //if (string.IsNullOrEmpty(department.Text))
                        //{
                        //    MessageBox.Show("Choose the department and the date (choose month by choosing any date in that month)");
                        //}
                        //else
                        {
                            string departmentname = this.department.Text;
                            string month = this.dateTimePicker1.Value.Month.ToString();
                            string year = this.dateTimePicker1.Value.Year.ToString();

                            totalbill = sum;
                            //MessageBox.Show("Total bill for department - " + departmentname + " in " + month + " / " + year + "  is  " + sum.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            
            
                try
                {
                    //  "C:\\Users\\dell\\Desktop\\bill_files\\"
                    string file = this.department.Text + this.dateTimePicker1.Value.Month + "-" + this.dateTimePicker1.Value.Year + ".pdf ";
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\dell\\Desktop\\bill_files\\" + file, FileMode.Create));
                    doc.Open();
                    string month = dateTimePicker1.Value.ToString("MMMM");
                    string year = dateTimePicker1.Value.Year.ToString();
                    Paragraph paragraph4 = new Paragraph("                                                Bits Pilani Institution Canteen Bill Receipt ");
                    Paragraph paragraph0 = new Paragraph(" " + month + "/" + year);
                    Paragraph paragraph1 = new Paragraph("Department = " + this.department.Text);
                    Paragraph paragraph2 = new Paragraph("The Bill of your department  is " + totalbill);
                    doc.Add(paragraph4);
                    doc.Add(paragraph0);
                    doc.Add(paragraph1);
                    doc.Add(paragraph2);
                    doc.Close();
                    MessageBox.Show(file + " file saved ");
                    totalbill = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void add_department_Click(object sender, EventArgs e)
        {
            if (user_name.Text.Contains("admin") == false)
            {
                MessageBox.Show("You are not authorized to edit items.Only Admin is allowed.");
            }
            else
            {
                this.Hide();
                Form5 f5 = new Form5(user_name.Text);

                f5.ShowDialog();
            }
        }
        // button2_click is change order button 
        private void button2_Click(object sender, EventArgs e)
        {
            Boolean m = true;
            if (string.IsNullOrEmpty(bill_no_txt.Text))
            {
                MessageBox.Show("Choose bill number which you want to edit");
                m = false;
            }

            else if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Choose date ");
                m = false;
            }
            else if (string.IsNullOrEmpty(department.Text))
            {
                MessageBox.Show("Choose department ");
                m = false;
            }
            else if (string.IsNullOrEmpty(items.Text))
            {
                MessageBox.Show("Choose item ");
                m = false;
            }
            if (m == true)
            {
                string constring = "datasource = localhost;port = 3306;username = root;password = kanwardeep";
                string Query = "UPDATE employee.transaction SET   department = '" + this.department.Text + "'," + this.items.Text + "=  ' " + this.quantity.Text + " ' , date = '" + this.dateTimePicker1.Text + "', subtotal = subtotal + '" + subtotal_txt.Text + "' where billno = ' " + this.bill_no_txt.Text + " ' ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    //MessageBox.Show(this.items.Text + " has been added");
                    while (myReader.Read())
                    {

                    }
                    //fillBillNo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conDataBase.Close();
                string query2 = "update employee.transaction_shown set   shown_quantity = '" + this.quantity.Text + "' where shown_billno = '" + this.bill_no_txt.Text + "' and shown_departmentname = '" + this.department.Text + "' and shown_date = '" + this.dateTimePicker1.Text + "' and shown_itemsname = '" + this.items.Text + "' ;";
                MySqlConnection conDataBase1 = new MySqlConnection(constring);
                MySqlCommand cmdDataBase1 = new MySqlCommand(query2, conDataBase1);
                MySqlDataReader myReader1;
                try
                {
                    conDataBase1.Open();
                    myReader1 = cmdDataBase1.ExecuteReader();
                    MessageBox.Show(this.items.Text + " has been edited");
                    while (myReader1.Read())
                    {

                    }
                    //fillBillNo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                conDataBase1.Close();
                load_data_method();
                items.SelectedIndex = -1;
                quantity.Text = "";
                price.Text = "";
                subtotal_txt.Text = "";

            }
            }

        

        }
    }


