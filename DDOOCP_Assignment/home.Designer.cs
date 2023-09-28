namespace DDOOCP_Assignment
{
    partial class home
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvApplianceUser = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxQuan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDuration = new System.Windows.Forms.ComboBox();
            this.btnGoCart = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplianceUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RosyBrown;
            this.label2.Location = new System.Drawing.Point(69, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 28);
            this.label2.TabIndex = 30;
            this.label2.Text = "Search By Type";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbxSort
            // 
            this.cbxSort.BackColor = System.Drawing.Color.RosyBrown;
            this.cbxSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSort.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSort.ForeColor = System.Drawing.Color.Linen;
            this.cbxSort.FormattingEnabled = true;
            this.cbxSort.Items.AddRange(new object[] {
            "Energy Consumption",
            "Monthly Cost"});
            this.cbxSort.Location = new System.Drawing.Point(285, 80);
            this.cbxSort.Name = "cbxSort";
            this.cbxSort.Size = new System.Drawing.Size(262, 33);
            this.cbxSort.TabIndex = 33;
            this.cbxSort.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(70, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 28);
            this.label1.TabIndex = 34;
            this.label1.Text = "Sort";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvApplianceUser
            // 
            this.dgvApplianceUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplianceUser.GridColor = System.Drawing.Color.Linen;
            this.dgvApplianceUser.Location = new System.Drawing.Point(75, 147);
            this.dgvApplianceUser.Name = "dgvApplianceUser";
            this.dgvApplianceUser.Size = new System.Drawing.Size(1026, 350);
            this.dgvApplianceUser.TabIndex = 35;
            this.dgvApplianceUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSearch.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Linen;
            this.btnSearch.Location = new System.Drawing.Point(630, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(195, 42);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Linen;
            this.button1.Location = new System.Drawing.Point(75, 625);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 48);
            this.button1.TabIndex = 37;
            this.button1.Text = "Add to Cart";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RosyBrown;
            this.label3.Location = new System.Drawing.Point(69, 529);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 28);
            this.label3.TabIndex = 39;
            this.label3.Text = "Select Quantity";
            // 
            // cbxQuan
            // 
            this.cbxQuan.BackColor = System.Drawing.Color.RosyBrown;
            this.cbxQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxQuan.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuan.ForeColor = System.Drawing.Color.Linen;
            this.cbxQuan.FormattingEnabled = true;
            this.cbxQuan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxQuan.Location = new System.Drawing.Point(291, 524);
            this.cbxQuan.Name = "cbxQuan";
            this.cbxQuan.Size = new System.Drawing.Size(212, 33);
            this.cbxQuan.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RosyBrown;
            this.label4.Location = new System.Drawing.Point(575, 529);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 28);
            this.label4.TabIndex = 41;
            this.label4.Text = "Select Duration(month)";
            // 
            // cbxDuration
            // 
            this.cbxDuration.BackColor = System.Drawing.Color.RosyBrown;
            this.cbxDuration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDuration.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDuration.ForeColor = System.Drawing.Color.Linen;
            this.cbxDuration.FormattingEnabled = true;
            this.cbxDuration.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbxDuration.Location = new System.Drawing.Point(889, 524);
            this.cbxDuration.Name = "cbxDuration";
            this.cbxDuration.Size = new System.Drawing.Size(212, 33);
            this.cbxDuration.TabIndex = 42;
            // 
            // btnGoCart
            // 
            this.btnGoCart.BackColor = System.Drawing.Color.RosyBrown;
            this.btnGoCart.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoCart.ForeColor = System.Drawing.Color.Linen;
            this.btnGoCart.Location = new System.Drawing.Point(489, 625);
            this.btnGoCart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGoCart.Name = "btnGoCart";
            this.btnGoCart.Size = new System.Drawing.Size(194, 48);
            this.btnGoCart.TabIndex = 43;
            this.btnGoCart.Text = "Go to Cart";
            this.btnGoCart.UseVisualStyleBackColor = false;
            this.btnGoCart.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Gray;
            this.btnLogOut.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Linen;
            this.btnLogOut.Location = new System.Drawing.Point(907, 625);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(194, 48);
            this.btnLogOut.TabIndex = 44;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbxType
            // 
            this.cbxType.BackColor = System.Drawing.Color.RosyBrown;
            this.cbxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxType.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxType.ForeColor = System.Drawing.Color.Linen;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "TV",
            "Refrigerator",
            "Microwave",
            "Washing Machine",
            "Air Conditioner"});
            this.cbxType.Location = new System.Drawing.Point(284, 23);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(262, 33);
            this.cbxType.TabIndex = 45;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSort.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.Linen;
            this.btnSort.Location = new System.Drawing.Point(630, 74);
            this.btnSort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(195, 42);
            this.btnSort.TabIndex = 46;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1184, 701);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnGoCart);
            this.Controls.Add(this.cbxDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxQuan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvApplianceUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxSort);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.RosyBrown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Form";
            this.Load += new System.EventHandler(this.home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplianceUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvApplianceUser;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxQuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDuration;
        private System.Windows.Forms.Button btnGoCart;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button btnSort;
    }
}