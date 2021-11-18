
namespace PBL3.GUI.FrmCon
{
    partial class FrmNhapHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenTK = new System.Windows.Forms.TextBox();
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbSanPham = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lvsanpham = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTaoPhieuNhap = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ tên:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenTK);
            this.groupBox1.Controls.Add(this.txtMaTK);
            this.groupBox1.Controls.Add(this.txtMaPN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 136);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.Silver;
            this.txtTime.ForeColor = System.Drawing.Color.Black;
            this.txtTime.Location = new System.Drawing.Point(582, 24);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(213, 26);
            this.txtTime.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(457, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Thời gian tạo:";
            // 
            // txtTenTK
            // 
            this.txtTenTK.BackColor = System.Drawing.Color.Silver;
            this.txtTenTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTK.ForeColor = System.Drawing.Color.Black;
            this.txtTenTK.Location = new System.Drawing.Point(162, 86);
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.ReadOnly = true;
            this.txtTenTK.Size = new System.Drawing.Size(260, 26);
            this.txtTenTK.TabIndex = 2;
            // 
            // txtMaTK
            // 
            this.txtMaTK.BackColor = System.Drawing.Color.Silver;
            this.txtMaTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTK.ForeColor = System.Drawing.Color.Black;
            this.txtMaTK.Location = new System.Drawing.Point(162, 55);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.ReadOnly = true;
            this.txtMaTK.Size = new System.Drawing.Size(260, 26);
            this.txtMaTK.TabIndex = 1;
            // 
            // txtMaPN
            // 
            this.txtMaPN.BackColor = System.Drawing.Color.Silver;
            this.txtMaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPN.ForeColor = System.Drawing.Color.Black;
            this.txtMaPN.Location = new System.Drawing.Point(162, 24);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.ReadOnly = true;
            this.txtMaPN.Size = new System.Drawing.Size(260, 26);
            this.txtMaPN.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(584, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbSanPham);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.lvsanpham);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 405);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin mặt hàng";
            // 
            // cbbSanPham
            // 
            this.cbbSanPham.FormattingEnabled = true;
            this.cbbSanPham.Location = new System.Drawing.Point(117, 37);
            this.cbbSanPham.Name = "cbbSanPham";
            this.cbbSanPham.Size = new System.Drawing.Size(175, 28);
            this.cbbSanPham.TabIndex = 7;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Image = global::PBL3.Properties.Resources.Update_icone;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(716, 31);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 33);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = global::PBL3.Properties.Resources.Files_Add_List_icon;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(603, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 33);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(391, 34);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(162, 26);
            this.txtSoLuong.TabIndex = 6;
            // 
            // lvsanpham
            // 
            this.lvsanpham.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvsanpham.ContextMenuStrip = this.contextMenuStrip1;
            this.lvsanpham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvsanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvsanpham.FullRowSelect = true;
            this.lvsanpham.HideSelection = false;
            this.lvsanpham.Location = new System.Drawing.Point(3, 89);
            this.lvsanpham.Name = "lvsanpham";
            this.lvsanpham.Size = new System.Drawing.Size(854, 313);
            this.lvsanpham.TabIndex = 1;
            this.lvsanpham.UseCompatibleStateImageBehavior = false;
            this.lvsanpham.View = System.Windows.Forms.View.Details;
            this.lvsanpham.SelectedIndexChanged += new System.EventHandler(this.lvsanpham_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã sản phẩm";
            this.columnHeader1.Width = 218;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sản phẩm";
            this.columnHeader2.Width = 315;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 265;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXoa});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 30);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuXoa
            // 
            this.mnuXoa.Image = global::PBL3.Properties.Resources.Trash_can_icon;
            this.mnuXoa.Name = "mnuXoa";
            this.mnuXoa.Size = new System.Drawing.Size(108, 26);
            this.mnuXoa.Text = "Xoá";
            this.mnuXoa.Click += new System.EventHandler(this.mnuXoa_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sản phẩm:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(313, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Số lượng:";
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::PBL3.Properties.Resources.Save_icon;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(359, 576);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(196, 44);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu phiếu nhập";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTaoPhieuNhap
            // 
            this.btnTaoPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhieuNhap.Image = global::PBL3.Properties.Resources.Button_Add_icon__1_;
            this.btnTaoPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoPhieuNhap.Location = new System.Drawing.Point(94, 576);
            this.btnTaoPhieuNhap.Name = "btnTaoPhieuNhap";
            this.btnTaoPhieuNhap.Size = new System.Drawing.Size(210, 44);
            this.btnTaoPhieuNhap.TabIndex = 3;
            this.btnTaoPhieuNhap.Text = "Tạo phiếu nhập ";
            this.btnTaoPhieuNhap.UseVisualStyleBackColor = true;
            this.btnTaoPhieuNhap.Click += new System.EventHandler(this.btnTaoPhieuNhap_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::PBL3.Properties.Resources.Windows_Close_Program_icon1;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(610, 576);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(196, 44);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Huỷ phiếu nhập";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FrmNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(884, 625);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnTaoPhieuNhap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNhapHang";
            this.Text = "6";
            this.Load += new System.EventHandler(this.FrmNhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ListView lvsanpham;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnTaoPhieuNhap;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.TextBox txtMaTK;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuXoa;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cbbSanPham;
    }
}