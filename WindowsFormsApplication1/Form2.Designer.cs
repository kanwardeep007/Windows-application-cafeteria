namespace WindowsFormsApplication1
{
    partial class Qty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bill_no_txt = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.load_data = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.items = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.TextBox();
            this.subtotal_label = new System.Windows.Forms.Label();
            this.total_bill = new System.Windows.Forms.Button();
            this.edit_items = new System.Windows.Forms.Button();
            this.edit_accounts = new System.Windows.Forms.Button();
            this.user_name = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.price = new System.Windows.Forms.Label();
            this.subtotal_txt = new System.Windows.Forms.Label();
            this.show_all_data = new System.Windows.Forms.Button();
            this.save_excel = new System.Windows.Forms.Button();
            this.save_pdf = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.add_department = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(46, 270);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(100, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "Start Next Order";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item";
            // 
            // department
            // 
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(137, 70);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(160, 21);
            this.department.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bill no";
            // 
            // bill_no_txt
            // 
            this.bill_no_txt.Location = new System.Drawing.Point(137, 9);
            this.bill_no_txt.Name = "bill_no_txt";
            this.bill_no_txt.Size = new System.Drawing.Size(100, 20);
            this.bill_no_txt.TabIndex = 6;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(165, 270);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(96, 23);
            this.update.TabIndex = 7;
            this.update.Text = "Add Item";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(165, 311);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(96, 23);
            this.delete.TabIndex = 8;
            this.delete.Text = "Delete Order";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(303, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 248);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // load_data
            // 
            this.load_data.Location = new System.Drawing.Point(47, 399);
            this.load_data.Name = "load_data";
            this.load_data.Size = new System.Drawing.Size(99, 23);
            this.load_data.TabIndex = 10;
            this.load_data.Text = "Load Bill Data";
            this.load_data.UseVisualStyleBackColor = true;
            this.load_data.Click += new System.EventHandler(this.load_data_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(137, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // items
            // 
            this.items.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.items.FormattingEnabled = true;
            this.items.Location = new System.Drawing.Point(137, 103);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(160, 21);
            this.items.TabIndex = 13;
            this.items.SelectedIndexChanged += new System.EventHandler(this.items_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Quantity";
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(140, 148);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(100, 20);
            this.quantity.TabIndex = 18;
            this.quantity.TextChanged += new System.EventHandler(this.quantity_TextChanged);
            this.quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantity_KeyPress);
            // 
            // subtotal_label
            // 
            this.subtotal_label.AutoSize = true;
            this.subtotal_label.Location = new System.Drawing.Point(43, 229);
            this.subtotal_label.Name = "subtotal_label";
            this.subtotal_label.Size = new System.Drawing.Size(46, 13);
            this.subtotal_label.TabIndex = 23;
            this.subtotal_label.Text = "Subtotal";
            // 
            // total_bill
            // 
            this.total_bill.Location = new System.Drawing.Point(173, 481);
            this.total_bill.Name = "total_bill";
            this.total_bill.Size = new System.Drawing.Size(107, 23);
            this.total_bill.TabIndex = 24;
            this.total_bill.Text = "Total Bill";
            this.total_bill.UseVisualStyleBackColor = true;
            this.total_bill.Click += new System.EventHandler(this.total_bill_Click);
            // 
            // edit_items
            // 
            this.edit_items.Location = new System.Drawing.Point(47, 440);
            this.edit_items.Name = "edit_items";
            this.edit_items.Size = new System.Drawing.Size(100, 23);
            this.edit_items.TabIndex = 25;
            this.edit_items.Text = "Add Items";
            this.edit_items.UseVisualStyleBackColor = true;
            this.edit_items.Click += new System.EventHandler(this.edit_items_Click);
            // 
            // edit_accounts
            // 
            this.edit_accounts.Location = new System.Drawing.Point(165, 399);
            this.edit_accounts.Name = "edit_accounts";
            this.edit_accounts.Size = new System.Drawing.Size(96, 23);
            this.edit_accounts.TabIndex = 26;
            this.edit_accounts.Text = "Add Account";
            this.edit_accounts.UseVisualStyleBackColor = true;
            this.edit_accounts.Click += new System.EventHandler(this.edit_accounts_Click);
            // 
            // user_name
            // 
            this.user_name.AutoSize = true;
            this.user_name.Location = new System.Drawing.Point(614, 12);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(59, 13);
            this.user_name.TabIndex = 27;
            this.user_name.Text = "user_name";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(162, 565);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 28;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(137, 189);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(30, 13);
            this.price.TabIndex = 29;
            this.price.Text = "price";
            // 
            // subtotal_txt
            // 
            this.subtotal_txt.AutoSize = true;
            this.subtotal_txt.Location = new System.Drawing.Point(137, 229);
            this.subtotal_txt.Name = "subtotal_txt";
            this.subtotal_txt.Size = new System.Drawing.Size(44, 13);
            this.subtotal_txt.TabIndex = 30;
            this.subtotal_txt.Text = "subtotal";
            // 
            // show_all_data
            // 
            this.show_all_data.Location = new System.Drawing.Point(47, 311);
            this.show_all_data.Name = "show_all_data";
            this.show_all_data.Size = new System.Drawing.Size(99, 23);
            this.show_all_data.TabIndex = 31;
            this.show_all_data.Text = "Show All Data";
            this.show_all_data.UseVisualStyleBackColor = true;
            this.show_all_data.Click += new System.EventHandler(this.show_all_data_Click);
            // 
            // save_excel
            // 
            this.save_excel.Location = new System.Drawing.Point(255, 388);
            this.save_excel.Name = "save_excel";
            this.save_excel.Size = new System.Drawing.Size(42, 20);
            this.save_excel.TabIndex = 32;
            this.save_excel.Text = "Save Excel";
            this.save_excel.UseVisualStyleBackColor = true;
            this.save_excel.Visible = false;
            this.save_excel.Click += new System.EventHandler(this.save_excel_Click);
            // 
            // save_pdf
            // 
            this.save_pdf.Location = new System.Drawing.Point(47, 481);
            this.save_pdf.Name = "save_pdf";
            this.save_pdf.Size = new System.Drawing.Size(120, 23);
            this.save_pdf.TabIndex = 33;
            this.save_pdf.Text = "Save PDF and Excel";
            this.save_pdf.UseVisualStyleBackColor = true;
            this.save_pdf.Click += new System.EventHandler(this.save_pdf_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(303, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(607, 293);
            this.dataGridView2.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Hide All Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // add_department
            // 
            this.add_department.Location = new System.Drawing.Point(165, 440);
            this.add_department.Name = "add_department";
            this.add_department.Size = new System.Drawing.Size(96, 23);
            this.add_department.TabIndex = 36;
            this.add_department.Text = "Add Department";
            this.add_department.UseVisualStyleBackColor = true;
            this.add_department.Click += new System.EventHandler(this.add_department_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Change Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 244);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 38;
            this.textBox1.Visible = false;
            // 
            // Qty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 716);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.add_department);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.save_pdf);
            this.Controls.Add(this.save_excel);
            this.Controls.Add(this.show_all_data);
            this.Controls.Add(this.subtotal_txt);
            this.Controls.Add(this.price);
            this.Controls.Add(this.back);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.edit_accounts);
            this.Controls.Add(this.edit_items);
            this.Controls.Add(this.total_bill);
            this.Controls.Add(this.subtotal_label);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.items);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.load_data);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.bill_no_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.department);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Add);
            this.Name = "Qty";
            this.Text = "Bits Cafeteria Management System Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bill_no_txt;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button load_data;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox items;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.Label subtotal_label;
        private System.Windows.Forms.Button total_bill;
        private System.Windows.Forms.Button edit_items;
        private System.Windows.Forms.Button edit_accounts;
        private System.Windows.Forms.Label user_name;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label subtotal_txt;
        private System.Windows.Forms.Button show_all_data;
        private System.Windows.Forms.Button save_excel;
        private System.Windows.Forms.Button save_pdf;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button add_department;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}