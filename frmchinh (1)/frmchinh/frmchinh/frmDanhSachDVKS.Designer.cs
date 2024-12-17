namespace frmchinh
{
    partial class frmDanhSachDVKS
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
            this.components = new System.ComponentModel.Container();
            this.dgvDanhSachDichVu = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmXoaDV = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLoaiDV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTongDichVu = new System.Windows.Forms.Label();
            this.btnTh = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoaiDV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDichVu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDanhSachDichVu
            // 
            this.dgvDanhSachDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachDichVu.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDanhSachDichVu.Location = new System.Drawing.Point(5, 18);
            this.dgvDanhSachDichVu.MultiSelect = false;
            this.dgvDanhSachDichVu.Name = "dgvDanhSachDichVu";
            this.dgvDanhSachDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachDichVu.Size = new System.Drawing.Size(613, 254);
            this.dgvDanhSachDichVu.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmXoaDV});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // tsmXoaDV
            // 
            this.tsmXoaDV.Name = "tsmXoaDV";
            this.tsmXoaDV.Size = new System.Drawing.Size(136, 22);
            this.tsmXoaDV.Text = "Xoá dịch vụ";
            this.tsmXoaDV.Click += new System.EventHandler(this.tsmXoaDV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtSearchByName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbLoaiDV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(618, 58);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc và tìm kiếm";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(313, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(53, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Tải lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(243, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(64, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(465, 26);
            this.txtSearchByName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(138, 20);
            this.txtSearchByName.TabIndex = 3;
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm kiếm theo tên";
            // 
            // cbbLoaiDV
            // 
            this.cbbLoaiDV.FormattingEnabled = true;
            this.cbbLoaiDV.Items.AddRange(new object[] {
            "Nhà hàng",
            "Giặt ủi",
            "Spa",
            "Thuê xe"});
            this.cbbLoaiDV.Location = new System.Drawing.Point(78, 24);
            this.cbbLoaiDV.Margin = new System.Windows.Forms.Padding(2);
            this.cbbLoaiDV.Name = "cbbLoaiDV";
            this.cbbLoaiDV.Size = new System.Drawing.Size(160, 21);
            this.cbbLoaiDV.TabIndex = 1;
            this.cbbLoaiDV.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiDV_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Dịch Vụ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Loại dịch vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-173, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Loại dịch vụ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-264, 533);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Có tất cả";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDanhSachDichVu);
            this.groupBox2.Location = new System.Drawing.Point(11, 72);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(623, 277);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách dịch vụ";
            // 
            // lblTongDichVu
            // 
            this.lblTongDichVu.AutoSize = true;
            this.lblTongDichVu.Location = new System.Drawing.Point(66, 357);
            this.lblTongDichVu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDichVu.Name = "lblTongDichVu";
            this.lblTongDichVu.Size = new System.Drawing.Size(16, 13);
            this.lblTongDichVu.TabIndex = 10;
            this.lblTongDichVu.Text = "...";
            // 
            // btnTh
            // 
            this.btnTh.Location = new System.Drawing.Point(285, 354);
            this.btnTh.Name = "btnTh";
            this.btnTh.Size = new System.Drawing.Size(75, 23);
            this.btnTh.TabIndex = 16;
            this.btnTh.Text = "Thêm";
            this.btnTh.UseVisualStyleBackColor = true;
            this.btnTh.Click += new System.EventHandler(this.btnTh_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(385, 354);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(95, 23);
            this.btnCapNhat.TabIndex = 16;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnXoaCN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Có tất cả";
            // 
            // lblLoaiDV
            // 
            this.lblLoaiDV.AutoSize = true;
            this.lblLoaiDV.Location = new System.Drawing.Point(187, 357);
            this.lblLoaiDV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoaiDV.Name = "lblLoaiDV";
            this.lblLoaiDV.Size = new System.Drawing.Size(16, 13);
            this.lblLoaiDV.TabIndex = 11;
            this.lblLoaiDV.Text = "...";
            // 
            // frmDanhSachDVKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 407);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnTh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLoaiDV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTongDichVu);
            this.Name = "frmDanhSachDVKS";
            this.Text = "frmDanhSachDVKS";
            this.Load += new System.EventHandler(this.frmDanhSachDVKS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDichVu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSachDichVu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLoaiDV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTongDichVu;
        private System.Windows.Forms.Button btnTh;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLoaiDV;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmXoaDV;
    }
}