namespace frmchinh
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbDichVu = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.MaskedTextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtCCHC = new System.Windows.Forms.TextBox();
            this.lblCCHC = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.lvDichVu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnXemInBill = new System.Windows.Forms.Button();
            this.lblCoc = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.btnLuu1 = new System.Windows.Forms.Button();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.lblTong = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.txtCoc = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMoQL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 653);
            this.splitContainer1.SplitterDistance = 560;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(549, 610);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMoQL);
            this.panel2.Controls.Add(this.cbbDichVu);
            this.panel2.Controls.Add(this.lblTimKiem);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 28);
            this.panel2.TabIndex = 1;
            // 
            // cbbDichVu
            // 
            this.cbbDichVu.FormattingEnabled = true;
            this.cbbDichVu.Location = new System.Drawing.Point(213, 3);
            this.cbbDichVu.Name = "cbbDichVu";
            this.cbbDichVu.Size = new System.Drawing.Size(212, 21);
            this.cbbDichVu.TabIndex = 1;
            this.cbbDichVu.SelectedIndexChanged += new System.EventHandler(this.cbbDichVu_SelectedIndexChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(123, 6);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(71, 15);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "TÌM KIẾM :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lblHoTen);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.txtSDT);
            this.groupBox2.Controls.Add(this.lblSDT);
            this.groupBox2.Controls.Add(this.txtCCHC);
            this.groupBox2.Controls.Add(this.lblCCHC);
            this.groupBox2.Controls.Add(this.lblGhiChu);
            this.groupBox2.Controls.Add(this.txtHoTen);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 204);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khách hàng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 20);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(13, 26);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(75, 13);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "HỌ VÀ TÊN :";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(137, 133);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(341, 20);
            this.txtGhiChu.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(138, 52);
            this.txtSDT.Mask = "0000.000.000";
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(340, 20);
            this.txtSDT.TabIndex = 7;
            this.txtSDT.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtSDT_MaskInputRejected);
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(13, 59);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(100, 13);
            this.lblSDT.TabIndex = 0;
            this.lblSDT.Text = "SỐ ĐIỆN THOẠI :\r\n";
            // 
            // txtCCHC
            // 
            this.txtCCHC.Location = new System.Drawing.Point(137, 91);
            this.txtCCHC.Name = "txtCCHC";
            this.txtCCHC.Size = new System.Drawing.Size(341, 20);
            this.txtCCHC.TabIndex = 6;
            // 
            // lblCCHC
            // 
            this.lblCCHC.AutoSize = true;
            this.lblCCHC.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCHC.Location = new System.Drawing.Point(13, 98);
            this.lblCCHC.Name = "lblCCHC";
            this.lblCCHC.Size = new System.Drawing.Size(110, 13);
            this.lblCCHC.TabIndex = 0;
            this.lblCCHC.Text = "CCCD/HỘ CHIẾU :";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(13, 140);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(65, 13);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "GHI CHÚ :\r\n";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(138, 19);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(341, 20);
            this.txtHoTen.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnKH);
            this.groupBox1.Controls.Add(this.lvDichVu);
            this.groupBox1.Controls.Add(this.lblThanhTien);
            this.groupBox1.Controls.Add(this.btnXemInBill);
            this.groupBox1.Controls.Add(this.lblCoc);
            this.groupBox1.Controls.Add(this.btnThanhToan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblGiamGia);
            this.groupBox1.Controls.Add(this.btnLuu1);
            this.groupBox1.Controls.Add(this.txtTong);
            this.groupBox1.Controls.Add(this.lblTong);
            this.groupBox1.Controls.Add(this.txtThanhTien);
            this.groupBox1.Controls.Add(this.txtGiamGia);
            this.groupBox1.Controls.Add(this.txtCoc);
            this.groupBox1.Location = new System.Drawing.Point(4, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 428);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết hóa đơn";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(472, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Tính Tiền";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnKH
            // 
            this.btnKH.Location = new System.Drawing.Point(337, 399);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(74, 23);
            this.btnKH.TabIndex = 0;
            this.btnKH.Text = "Khách hàng";
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // lvDichVu
            // 
            this.lvDichVu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDichVu.GridLines = true;
            this.lvDichVu.HideSelection = false;
            this.lvDichVu.Location = new System.Drawing.Point(3, 19);
            this.lvDichVu.Name = "lvDichVu";
            this.lvDichVu.Size = new System.Drawing.Size(544, 196);
            this.lvDichVu.TabIndex = 4;
            this.lvDichVu.UseCompatibleStateImageBehavior = false;
            this.lvDichVu.View = System.Windows.Forms.View.Details;
            this.lvDichVu.SelectedIndexChanged += new System.EventHandler(this.lvCTHoaDon_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên dịch vụ";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Loại Dịch Vụ";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ghi chú";
            this.columnHeader5.Width = 150;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.Location = new System.Drawing.Point(12, 231);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(92, 17);
            this.lblThanhTien.TabIndex = 5;
            this.lblThanhTien.Text = "Thành Tiền :";
            // 
            // btnXemInBill
            // 
            this.btnXemInBill.Location = new System.Drawing.Point(440, 399);
            this.btnXemInBill.Name = "btnXemInBill";
            this.btnXemInBill.Size = new System.Drawing.Size(92, 23);
            this.btnXemInBill.TabIndex = 0;
            this.btnXemInBill.Text = "Hóa đơn đã lưu\r\n";
            this.btnXemInBill.UseVisualStyleBackColor = true;
            this.btnXemInBill.Click += new System.EventHandler(this.btnXemInBill_Click);
            // 
            // lblCoc
            // 
            this.lblCoc.AutoSize = true;
            this.lblCoc.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoc.Location = new System.Drawing.Point(12, 272);
            this.lblCoc.Name = "lblCoc";
            this.lblCoc.Size = new System.Drawing.Size(43, 17);
            this.lblCoc.TabIndex = 5;
            this.lblCoc.Text = "Cọc :";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(476, 351);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(74, 23);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "%";
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamGia.Location = new System.Drawing.Point(12, 315);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(74, 17);
            this.lblGiamGia.TabIndex = 5;
            this.lblGiamGia.Text = "Giảm giá :";
            // 
            // btnLuu1
            // 
            this.btnLuu1.Location = new System.Drawing.Point(125, 399);
            this.btnLuu1.Name = "btnLuu1";
            this.btnLuu1.Size = new System.Drawing.Size(74, 23);
            this.btnLuu1.TabIndex = 0;
            this.btnLuu1.Text = "Lưu";
            this.btnLuu1.UseVisualStyleBackColor = true;
            this.btnLuu1.Click += new System.EventHandler(this.btnLuu1_Click);
            // 
            // txtTong
            // 
            this.txtTong.Location = new System.Drawing.Point(125, 354);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(340, 20);
            this.txtTong.TabIndex = 6;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.Location = new System.Drawing.Point(12, 354);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(51, 17);
            this.lblTong.TabIndex = 5;
            this.lblTong.Text = "Tổng :";
            this.lblTong.Click += new System.EventHandler(this.lblTong_Click);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(125, 231);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(341, 20);
            this.txtThanhTien.TabIndex = 6;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.txtCoc_TextChanged);
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(125, 312);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(340, 20);
            this.txtGiamGia.TabIndex = 6;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtCoc_TextChanged);
            // 
            // txtCoc
            // 
            this.txtCoc.Location = new System.Drawing.Point(126, 269);
            this.txtCoc.Name = "txtCoc";
            this.txtCoc.Size = new System.Drawing.Size(340, 20);
            this.txtCoc.TabIndex = 6;
            this.txtCoc.TextChanged += new System.EventHandler(this.txtCoc_TextChanged);
            // 
            // btnMoQL
            // 
            this.btnMoQL.Location = new System.Drawing.Point(9, 3);
            this.btnMoQL.Name = "btnMoQL";
            this.btnMoQL.Size = new System.Drawing.Size(25, 23);
            this.btnMoQL.TabIndex = 0;
            this.btnMoQL.Text = "--\r\n";
            this.btnMoQL.UseVisualStyleBackColor = true;
            this.btnMoQL.Click += new System.EventHandler(this.btnMoQL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 653);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Main ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblCCHC;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.ListView lvDichVu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.TextBox txtCoc;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblCoc;
        private System.Windows.Forms.TextBox txtCCHC;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnLuu1;
        private System.Windows.Forms.MaskedTextBox txtSDT;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnXemInBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.ComboBox cbbDichVu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMoQL;
    }
}

