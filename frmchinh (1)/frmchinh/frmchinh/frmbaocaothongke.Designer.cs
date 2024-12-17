namespace frmchinh
{
    partial class frmbaocaothongke
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
            this.grpSoLuongDV = new System.Windows.Forms.GroupBox();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTongDT = new System.Windows.Forms.Label();
            this.btnXemBC = new System.Windows.Forms.Button();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBaoCao = new System.Windows.Forms.GroupBox();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.rdThapCao = new System.Windows.Forms.RadioButton();
            this.rdCaoThap = new System.Windows.Forms.RadioButton();
            this.grpSoLuongDV.SuspendLayout();
            this.grpBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.grpBoLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSoLuongDV
            // 
            this.grpSoLuongDV.Controls.Add(this.txtTongDoanhThu);
            this.grpSoLuongDV.Controls.Add(this.lblTongDT);
            this.grpSoLuongDV.Controls.Add(this.btnXemBC);
            this.grpSoLuongDV.Controls.Add(this.dtpTuNgay);
            this.grpSoLuongDV.Controls.Add(this.label1);
            this.grpSoLuongDV.Location = new System.Drawing.Point(28, 6);
            this.grpSoLuongDV.Margin = new System.Windows.Forms.Padding(2);
            this.grpSoLuongDV.Name = "grpSoLuongDV";
            this.grpSoLuongDV.Padding = new System.Windows.Forms.Padding(2);
            this.grpSoLuongDV.Size = new System.Drawing.Size(439, 135);
            this.grpSoLuongDV.TabIndex = 3;
            this.grpSoLuongDV.TabStop = false;
            this.grpSoLuongDV.Text = "Số lượng dịch vụ";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Location = new System.Drawing.Point(314, 29);
            this.txtTongDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(111, 20);
            this.txtTongDoanhThu.TabIndex = 30;
            this.txtTongDoanhThu.Text = ".";
            // 
            // lblTongDT
            // 
            this.lblTongDT.AutoSize = true;
            this.lblTongDT.Location = new System.Drawing.Point(229, 34);
            this.lblTongDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDT.Name = "lblTongDT";
            this.lblTongDT.Size = new System.Drawing.Size(83, 13);
            this.lblTongDT.TabIndex = 29;
            this.lblTongDT.Text = "Tổng doanh thu";
            // 
            // btnXemBC
            // 
            this.btnXemBC.Location = new System.Drawing.Point(168, 88);
            this.btnXemBC.Margin = new System.Windows.Forms.Padding(2);
            this.btnXemBC.Name = "btnXemBC";
            this.btnXemBC.Size = new System.Drawing.Size(99, 25);
            this.btnXemBC.TabIndex = 28;
            this.btnXemBC.Text = "Xem báo cáo";
            this.btnXemBC.UseVisualStyleBackColor = true;
            this.btnXemBC.Click += new System.EventHandler(this.btnXemBC_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(71, 31);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(103, 20);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian";
            // 
            // grpBaoCao
            // 
            this.grpBaoCao.Controls.Add(this.dgvBaoCao);
            this.grpBaoCao.Location = new System.Drawing.Point(49, 177);
            this.grpBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.grpBaoCao.Name = "grpBaoCao";
            this.grpBaoCao.Padding = new System.Windows.Forms.Padding(2);
            this.grpBaoCao.Size = new System.Drawing.Size(923, 231);
            this.grpBaoCao.TabIndex = 4;
            this.grpBaoCao.TabStop = false;
            this.grpBaoCao.Text = "Báo cáo";
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(11, 16);
            this.dgvBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 62;
            this.dgvBaoCao.RowTemplate.Height = 28;
            this.dgvBaoCao.Size = new System.Drawing.Size(901, 211);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.rdThapCao);
            this.grpBoLoc.Controls.Add(this.rdCaoThap);
            this.grpBoLoc.Location = new System.Drawing.Point(493, 19);
            this.grpBoLoc.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoLoc.Size = new System.Drawing.Size(176, 122);
            this.grpBoLoc.TabIndex = 5;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc tìm kiếm";
            // 
            // rdThapCao
            // 
            this.rdThapCao.AutoSize = true;
            this.rdThapCao.Location = new System.Drawing.Point(13, 40);
            this.rdThapCao.Margin = new System.Windows.Forms.Padding(2);
            this.rdThapCao.Name = "rdThapCao";
            this.rdThapCao.Size = new System.Drawing.Size(141, 17);
            this.rdThapCao.TabIndex = 1;
            this.rdThapCao.Text = "Tổng tiền từ thấp tới cao";
            this.rdThapCao.UseVisualStyleBackColor = true;
            this.rdThapCao.CheckedChanged += new System.EventHandler(this.rdThapCao_CheckedChanged);
            // 
            // rdCaoThap
            // 
            this.rdCaoThap.AutoSize = true;
            this.rdCaoThap.Checked = true;
            this.rdCaoThap.Location = new System.Drawing.Point(13, 18);
            this.rdCaoThap.Margin = new System.Windows.Forms.Padding(2);
            this.rdCaoThap.Name = "rdCaoThap";
            this.rdCaoThap.Size = new System.Drawing.Size(141, 17);
            this.rdCaoThap.TabIndex = 0;
            this.rdCaoThap.TabStop = true;
            this.rdCaoThap.Text = "Tổng tiền từ cao tới thấp";
            this.rdCaoThap.UseVisualStyleBackColor = true;
            this.rdCaoThap.CheckedChanged += new System.EventHandler(this.rdCaoThap_CheckedChanged);
            // 
            // frmbaocaothongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 415);
            this.Controls.Add(this.grpSoLuongDV);
            this.Controls.Add(this.grpBaoCao);
            this.Controls.Add(this.grpBoLoc);
            this.Name = "frmbaocaothongke";
            this.Text = "frmbaocaothongke";
            this.grpSoLuongDV.ResumeLayout(false);
            this.grpSoLuongDV.PerformLayout();
            this.grpBaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSoLuongDV;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label lblTongDT;
        private System.Windows.Forms.Button btnXemBC;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBaoCao;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.RadioButton rdThapCao;
        private System.Windows.Forms.RadioButton rdCaoThap;
    }
}