
namespace QuanLyCuaHang
{
    partial class fBaoHanh
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
            this.dtgvBH = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbb_TrangThaiBH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_IdBH = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_LyDoBH = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_XoaBH = new System.Windows.Forms.Button();
            this.btn_SuaBH = new System.Windows.Forms.Button();
            this.btn_ThemBH = new System.Windows.Forms.Button();
            this.btn_TimPBH = new System.Windows.Forms.Button();
            this.cbb_IdPBH = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBH)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvBH
            // 
            this.dtgvBH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBH.Location = new System.Drawing.Point(13, 268);
            this.dtgvBH.Name = "dtgvBH";
            this.dtgvBH.RowHeadersWidth = 62;
            this.dtgvBH.RowTemplate.Height = 28;
            this.dtgvBH.Size = new System.Drawing.Size(985, 313);
            this.dtgvBH.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Location = new System.Drawing.Point(177, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 234);
            this.panel1.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbb_TrangThaiBH);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(17, 173);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(489, 38);
            this.panel6.TabIndex = 9;
            // 
            // cbb_TrangThaiBH
            // 
            this.cbb_TrangThaiBH.FormattingEnabled = true;
            this.cbb_TrangThaiBH.Items.AddRange(new object[] {
            "Chờ xác nhận",
            "Đã từ chối",
            "Đang xử lý",
            "Hoàn tất"});
            this.cbb_TrangThaiBH.Location = new System.Drawing.Point(179, 4);
            this.cbb_TrangThaiBH.Name = "cbb_TrangThaiBH";
            this.cbb_TrangThaiBH.Size = new System.Drawing.Size(306, 30);
            this.cbb_TrangThaiBH.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trạng thái";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.txt_IdBH);
            this.panel9.Location = new System.Drawing.Point(17, 23);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(489, 38);
            this.panel9.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID";
            // 
            // txt_IdBH
            // 
            this.txt_IdBH.Location = new System.Drawing.Point(179, 6);
            this.txt_IdBH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_IdBH.Name = "txt_IdBH";
            this.txt_IdBH.Size = new System.Drawing.Size(306, 28);
            this.txt_IdBH.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.txt_LyDoBH);
            this.panel7.Location = new System.Drawing.Point(17, 123);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(489, 38);
            this.panel7.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Lý do bảo hành";
            // 
            // txt_LyDoBH
            // 
            this.txt_LyDoBH.Location = new System.Drawing.Point(179, 6);
            this.txt_LyDoBH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_LyDoBH.Name = "txt_LyDoBH";
            this.txt_LyDoBH.Size = new System.Drawing.Size(306, 28);
            this.txt_LyDoBH.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cbb_IdPBH);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(17, 73);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(489, 38);
            this.panel8.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "ID Phiếu bảo hành";
            // 
            // btn_XoaBH
            // 
            this.btn_XoaBH.Location = new System.Drawing.Point(715, 206);
            this.btn_XoaBH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_XoaBH.Name = "btn_XoaBH";
            this.btn_XoaBH.Size = new System.Drawing.Size(118, 38);
            this.btn_XoaBH.TabIndex = 19;
            this.btn_XoaBH.Text = "Xóa";
            this.btn_XoaBH.UseVisualStyleBackColor = true;
            this.btn_XoaBH.Click += new System.EventHandler(this.btn_XoaBH_Click);
            // 
            // btn_SuaBH
            // 
            this.btn_SuaBH.Location = new System.Drawing.Point(715, 142);
            this.btn_SuaBH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_SuaBH.Name = "btn_SuaBH";
            this.btn_SuaBH.Size = new System.Drawing.Size(118, 38);
            this.btn_SuaBH.TabIndex = 18;
            this.btn_SuaBH.Text = "Sửa";
            this.btn_SuaBH.UseVisualStyleBackColor = true;
            this.btn_SuaBH.Click += new System.EventHandler(this.btn_SuaBH_Click);
            // 
            // btn_ThemBH
            // 
            this.btn_ThemBH.Location = new System.Drawing.Point(715, 78);
            this.btn_ThemBH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ThemBH.Name = "btn_ThemBH";
            this.btn_ThemBH.Size = new System.Drawing.Size(118, 38);
            this.btn_ThemBH.TabIndex = 17;
            this.btn_ThemBH.Text = "Thêm";
            this.btn_ThemBH.UseVisualStyleBackColor = true;
            this.btn_ThemBH.Click += new System.EventHandler(this.btn_ThemBH_Click);
            // 
            // btn_TimPBH
            // 
            this.btn_TimPBH.Location = new System.Drawing.Point(715, 14);
            this.btn_TimPBH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_TimPBH.Name = "btn_TimPBH";
            this.btn_TimPBH.Size = new System.Drawing.Size(118, 38);
            this.btn_TimPBH.TabIndex = 16;
            this.btn_TimPBH.Text = "Tìm kiếm";
            this.btn_TimPBH.UseVisualStyleBackColor = true;
            this.btn_TimPBH.Click += new System.EventHandler(this.btn_TimPBH_Click);
            // 
            // cbb_IdPBH
            // 
            this.cbb_IdPBH.FormattingEnabled = true;
            this.cbb_IdPBH.Items.AddRange(new object[] {
            "Chờ xác nhận",
            "Đã từ chối",
            "Đang xử lý",
            "Hoàn tất"});
            this.cbb_IdPBH.Location = new System.Drawing.Point(179, 5);
            this.cbb_IdPBH.Name = "cbb_IdPBH";
            this.cbb_IdPBH.Size = new System.Drawing.Size(306, 30);
            this.cbb_IdPBH.TabIndex = 2;
            // 
            // fBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 593);
            this.Controls.Add(this.btn_XoaBH);
            this.Controls.Add(this.btn_SuaBH);
            this.Controls.Add(this.btn_ThemBH);
            this.Controls.Add(this.btn_TimPBH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvBH);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "fBaoHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bảo hành";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvBH;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbb_TrangThaiBH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_IdBH;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_LyDoBH;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_XoaBH;
        private System.Windows.Forms.Button btn_SuaBH;
        private System.Windows.Forms.Button btn_ThemBH;
        private System.Windows.Forms.Button btn_TimPBH;
        private System.Windows.Forms.ComboBox cbb_IdPBH;
    }
}