namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.item_id = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.Label();
            this.item_price = new System.Windows.Forms.Label();
            this.item_id_box = new System.Windows.Forms.TextBox();
            this.item_price_box = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.username_form3 = new System.Windows.Forms.Label();
            this.back_form3 = new System.Windows.Forms.Button();
            this.item_name_box = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(48, 181);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 0;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(157, 181);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(75, 23);
            this.edit.TabIndex = 1;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // item_id
            // 
            this.item_id.AutoSize = true;
            this.item_id.Location = new System.Drawing.Point(45, 38);
            this.item_id.Name = "item_id";
            this.item_id.Size = new System.Drawing.Size(42, 13);
            this.item_id.TabIndex = 2;
            this.item_id.Text = "Item_Id";
            // 
            // item_name
            // 
            this.item_name.AutoSize = true;
            this.item_name.Location = new System.Drawing.Point(45, 74);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(61, 13);
            this.item_name.TabIndex = 3;
            this.item_name.Text = "Item_Name";
            // 
            // item_price
            // 
            this.item_price.AutoSize = true;
            this.item_price.Location = new System.Drawing.Point(45, 114);
            this.item_price.Name = "item_price";
            this.item_price.Size = new System.Drawing.Size(57, 13);
            this.item_price.TabIndex = 4;
            this.item_price.Text = "Item_Price";
            // 
            // item_id_box
            // 
            this.item_id_box.Location = new System.Drawing.Point(132, 38);
            this.item_id_box.Name = "item_id_box";
            this.item_id_box.Size = new System.Drawing.Size(100, 20);
            this.item_id_box.TabIndex = 5;
            this.item_id_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // item_price_box
            // 
            this.item_price_box.Location = new System.Drawing.Point(132, 114);
            this.item_price_box.Name = "item_price_box";
            this.item_price_box.Size = new System.Drawing.Size(100, 20);
            this.item_price_box.TabIndex = 7;
            this.item_price_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(48, 223);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 8;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // username_form3
            // 
            this.username_form3.AutoSize = true;
            this.username_form3.Location = new System.Drawing.Point(142, 9);
            this.username_form3.Name = "username_form3";
            this.username_form3.Size = new System.Drawing.Size(35, 13);
            this.username_form3.TabIndex = 9;
            this.username_form3.Text = "label1";
            // 
            // back_form3
            // 
            this.back_form3.Location = new System.Drawing.Point(157, 223);
            this.back_form3.Name = "back_form3";
            this.back_form3.Size = new System.Drawing.Size(75, 23);
            this.back_form3.TabIndex = 10;
            this.back_form3.Text = "Back";
            this.back_form3.UseVisualStyleBackColor = true;
            this.back_form3.Click += new System.EventHandler(this.back_form3_Click);
            // 
            // item_name_box
            // 
            this.item_name_box.FormattingEnabled = true;
            this.item_name_box.Location = new System.Drawing.Point(132, 74);
            this.item_name_box.Name = "item_name_box";
            this.item_name_box.Size = new System.Drawing.Size(121, 21);
            this.item_name_box.TabIndex = 11;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.item_name_box);
            this.Controls.Add(this.back_form3);
            this.Controls.Add(this.username_form3);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.item_price_box);
            this.Controls.Add(this.item_id_box);
            this.Controls.Add(this.item_price);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_id);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Name = "Form3";
            this.Text = "Items form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label item_id;
        private System.Windows.Forms.Label item_name;
        private System.Windows.Forms.Label item_price;
        private System.Windows.Forms.TextBox item_id_box;
        private System.Windows.Forms.TextBox item_price_box;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label username_form3;
        private System.Windows.Forms.Button back_form3;
        private System.Windows.Forms.ComboBox item_name_box;
    }
}