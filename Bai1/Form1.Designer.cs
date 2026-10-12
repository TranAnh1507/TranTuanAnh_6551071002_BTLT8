namespace Bai1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            gbThongTin = new GroupBox();
            chkConKinhDoanh = new CheckBox();
            dtpNgayNhap = new DateTimePicker();
            nudSoLuongTon = new NumericUpDown();
            nudGiaBan = new NumericUpDown();
            cboDonVi = new ComboBox();
            cboLoaiHang = new ComboBox();
            txtTenHang = new TextBox();
            lblNgayNhap = new Label();
            lblSoLuongTon = new Label();
            lblGiaBan = new Label();
            lblDonVi = new Label();
            lblLoaiHang = new Label();
            lblTenHang = new Label();
            gbTimKiem = new GroupBox();
            chkChiConKinhDoanh = new CheckBox();
            cboLocLoaiHang = new ComboBox();
            txtTimKiem = new TextBox();
            dgvHangHoa = new DataGridView();
            colMaHang = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colLoaiHang = new DataGridViewTextBoxColumn();
            colDonVi = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSoLuongTon = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colConKinhDoanh = new DataGridViewCheckBoxColumn();
            pnlButtons = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXemBangGia = new Button();
            btnXuatPdf = new Button();
            btnXuatExcelLuoi = new Button();
            btnXuatExcelTonKho = new Button();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
            gbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).BeginInit();
            pnlButtons.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbThongTin
            // 
            gbThongTin.Controls.Add(chkConKinhDoanh);
            gbThongTin.Controls.Add(dtpNgayNhap);
            gbThongTin.Controls.Add(nudSoLuongTon);
            gbThongTin.Controls.Add(nudGiaBan);
            gbThongTin.Controls.Add(cboDonVi);
            gbThongTin.Controls.Add(cboLoaiHang);
            gbThongTin.Controls.Add(txtTenHang);
            gbThongTin.Controls.Add(lblNgayNhap);
            gbThongTin.Controls.Add(lblSoLuongTon);
            gbThongTin.Controls.Add(lblGiaBan);
            gbThongTin.Controls.Add(lblDonVi);
            gbThongTin.Controls.Add(lblLoaiHang);
            gbThongTin.Controls.Add(lblTenHang);
            gbThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbThongTin.Location = new Point(12, 12);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Size = new Size(570, 160);
            gbThongTin.TabIndex = 0;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "Thông tin hàng hóa";
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(380, 124);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(111, 19);
            chkConKinhDoanh.TabIndex = 12;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(380, 90);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(170, 23);
            dtpNgayNhap.TabIndex = 11;
            // 
            // nudSoLuongTon
            // 
            nudSoLuongTon.Location = new Point(380, 57);
            nudSoLuongTon.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(170, 23);
            nudSoLuongTon.TabIndex = 10;
            nudSoLuongTon.ThousandsSeparator = true;
            // 
            // nudGiaBan
            // 
            nudGiaBan.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            nudGiaBan.Location = new Point(88, 123);
            nudGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudGiaBan.Name = "nudGiaBan";
            nudGiaBan.Size = new Size(180, 23);
            nudGiaBan.TabIndex = 9;
            nudGiaBan.ThousandsSeparator = true;
            // 
            // cboDonVi
            // 
            cboDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDonVi.FormattingEnabled = true;
            cboDonVi.Items.AddRange(new object[] { "Chai", "Gói", "Hộp", "Túi" });
            cboDonVi.Location = new Point(88, 90);
            cboDonVi.Name = "cboDonVi";
            cboDonVi.Size = new Size(180, 23);
            cboDonVi.TabIndex = 8;
            // 
            // cboLoaiHang
            // 
            cboLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiHang.FormattingEnabled = true;
            cboLoaiHang.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
            cboLoaiHang.Location = new Point(88, 57);
            cboLoaiHang.Name = "cboLoaiHang";
            cboLoaiHang.Size = new Size(180, 23);
            cboLoaiHang.TabIndex = 7;
            // 
            // txtTenHang
            // 
            txtTenHang.Location = new Point(88, 24);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(462, 23);
            txtTenHang.TabIndex = 6;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(295, 93);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(68, 15);
            lblNgayNhap.TabIndex = 5;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // lblSoLuongTon
            // 
            lblSoLuongTon.AutoSize = true;
            lblSoLuongTon.Location = new Point(295, 60);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Size = new Size(79, 15);
            lblSoLuongTon.TabIndex = 4;
            lblSoLuongTon.Text = "Số lượng tồn:";
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(15, 126);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(50, 15);
            lblGiaBan.TabIndex = 3;
            lblGiaBan.Text = "Giá bán:";
            // 
            // lblDonVi
            // 
            lblDonVi.AutoSize = true;
            lblDonVi.Location = new Point(15, 93);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new Size(44, 15);
            lblDonVi.TabIndex = 2;
            lblDonVi.Text = "Đơn vị:";
            // 
            // lblLoaiHang
            // 
            lblLoaiHang.AutoSize = true;
            lblLoaiHang.Location = new Point(15, 60);
            lblLoaiHang.Name = "lblLoaiHang";
            lblLoaiHang.Size = new Size(62, 15);
            lblLoaiHang.TabIndex = 1;
            lblLoaiHang.Text = "Loại hàng:";
            // 
            // lblTenHang
            // 
            lblTenHang.AutoSize = true;
            lblTenHang.Location = new Point(15, 27);
            lblTenHang.Name = "lblTenHang";
            lblTenHang.Size = new Size(59, 15);
            lblTenHang.TabIndex = 0;
            lblTenHang.Text = "Tên hàng:";
            // 
            // gbTimKiem
            // 
            gbTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbTimKiem.Controls.Add(chkChiConKinhDoanh);
            gbTimKiem.Controls.Add(cboLocLoaiHang);
            gbTimKiem.Controls.Add(txtTimKiem);
            gbTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbTimKiem.Location = new Point(595, 12);
            gbTimKiem.Name = "gbTimKiem";
            gbTimKiem.Size = new Size(357, 160);
            gbTimKiem.TabIndex = 1;
            gbTimKiem.TabStop = false;
            gbTimKiem.Text = "Tìm kiếm";
            // 
            // chkChiConKinhDoanh
            // 
            chkChiConKinhDoanh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chkChiConKinhDoanh.AutoSize = true;
            chkChiConKinhDoanh.Location = new Point(15, 95);
            chkChiConKinhDoanh.Name = "chkChiConKinhDoanh";
            chkChiConKinhDoanh.Size = new Size(181, 19);
            chkChiConKinhDoanh.TabIndex = 2;
            chkChiConKinhDoanh.Text = "Chỉ hiện hàng còn kinh doanh";
            chkChiConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // cboLocLoaiHang
            // 
            cboLocLoaiHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLocLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiHang.FormattingEnabled = true;
            cboLocLoaiHang.Location = new Point(15, 58);
            cboLocLoaiHang.Name = "cboLocLoaiHang";
            cboLocLoaiHang.Size = new Size(328, 23);
            cboLocLoaiHang.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(15, 24);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo tên hàng...";
            txtTimKiem.Size = new Size(328, 23);
            txtTimKiem.TabIndex = 0;
            // 
            // dgvHangHoa
            // 
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.AllowUserToDeleteRows = false;
            dgvHangHoa.AllowUserToResizeRows = false;
            dgvHangHoa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangHoa.BackgroundColor = SystemColors.Window;
            dgvHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangHoa.Columns.AddRange(new DataGridViewColumn[] { colMaHang, colTenHang, colLoaiHang, colDonVi, colGiaBan, colSoLuongTon, colNgayNhap, colConKinhDoanh });
            dgvHangHoa.Location = new Point(12, 185);
            dgvHangHoa.MultiSelect = false;
            dgvHangHoa.Name = "dgvHangHoa";
            dgvHangHoa.ReadOnly = true;
            dgvHangHoa.RowHeadersVisible = true;
            dgvHangHoa.RowHeadersWidth = 25;
            dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.Size = new Size(940, 290);
            dgvHangHoa.TabIndex = 2;
            // 
            // colMaHang
            // 
            colMaHang.DataPropertyName = "MaHang";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaHang.DefaultCellStyle = dataGridViewCellStyle1;
            colMaHang.FillWeight = 50F;
            colMaHang.HeaderText = "Mã";
            colMaHang.Name = "colMaHang";
            colMaHang.ReadOnly = true;
            // 
            // colTenHang
            // 
            colTenHang.DataPropertyName = "TenHang";
            colTenHang.FillWeight = 180F;
            colTenHang.HeaderText = "Tên hàng";
            colTenHang.Name = "colTenHang";
            colTenHang.ReadOnly = true;
            // 
            // colLoaiHang
            // 
            colLoaiHang.DataPropertyName = "LoaiHang";
            colLoaiHang.FillWeight = 110F;
            colLoaiHang.HeaderText = "Loại hàng";
            colLoaiHang.Name = "colLoaiHang";
            colLoaiHang.ReadOnly = true;
            // 
            // colDonVi
            // 
            colDonVi.DataPropertyName = "DonVi";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDonVi.DefaultCellStyle = dataGridViewCellStyle2;
            colDonVi.FillWeight = 65F;
            colDonVi.HeaderText = "Đơn vị";
            colDonVi.Name = "colDonVi";
            colDonVi.ReadOnly = true;
            // 
            // colGiaBan
            // 
            colGiaBan.DataPropertyName = "GiaBan";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            colGiaBan.DefaultCellStyle = dataGridViewCellStyle3;
            colGiaBan.FillWeight = 90F;
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.Name = "colGiaBan";
            colGiaBan.ReadOnly = true;
            // 
            // colSoLuongTon
            // 
            colSoLuongTon.DataPropertyName = "SoLuongTon";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            colSoLuongTon.DefaultCellStyle = dataGridViewCellStyle4;
            colSoLuongTon.FillWeight = 60F;
            colSoLuongTon.HeaderText = "Tồn";
            colSoLuongTon.Name = "colSoLuongTon";
            colSoLuongTon.ReadOnly = true;
            // 
            // colNgayNhap
            // 
            colNgayNhap.DataPropertyName = "NgayNhap";
            colNgayNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNgayNhap.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayNhap.FillWeight = 95F;
            colNgayNhap.HeaderText = "Ngày nhập";
            colNgayNhap.Name = "colNgayNhap";
            colNgayNhap.ReadOnly = true;
            // 
            // colConKinhDoanh
            // 
            colConKinhDoanh.DataPropertyName = "ConKinhDoanh";
            colConKinhDoanh.FillWeight = 85F;
            colConKinhDoanh.HeaderText = "Kinh doanh";
            colConKinhDoanh.Name = "colConKinhDoanh";
            colConKinhDoanh.ReadOnly = true;
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlButtons.Controls.Add(btnThem);
            pnlButtons.Controls.Add(btnSua);
            pnlButtons.Controls.Add(btnXoa);
            pnlButtons.Controls.Add(btnLamMoi);
            pnlButtons.Controls.Add(btnXemBangGia);
            pnlButtons.Controls.Add(btnXuatPdf);
            pnlButtons.Controls.Add(btnXuatExcelLuoi);
            pnlButtons.Controls.Add(btnXuatExcelTonKho);
            pnlButtons.Location = new Point(12, 485);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(940, 40);
            pnlButtons.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(3, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 32);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(89, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 32);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(175, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 32);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(261, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(85, 32);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXemBangGia
            // 
            btnXemBangGia.Location = new Point(352, 3);
            btnXemBangGia.Name = "btnXemBangGia";
            btnXemBangGia.Size = new Size(110, 32);
            btnXemBangGia.TabIndex = 4;
            btnXemBangGia.Text = "Xem bảng giá";
            btnXemBangGia.UseVisualStyleBackColor = true;
            // 
            // btnXuatPdf
            // 
            btnXuatPdf.Location = new Point(468, 3);
            btnXuatPdf.Name = "btnXuatPdf";
            btnXuatPdf.Size = new Size(90, 32);
            btnXuatPdf.TabIndex = 5;
            btnXuatPdf.Text = "Xuất PDF";
            btnXuatPdf.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcelLuoi
            // 
            btnXuatExcelLuoi.Location = new Point(564, 3);
            btnXuatExcelLuoi.Name = "btnXuatExcelLuoi";
            btnXuatExcelLuoi.Size = new Size(125, 32);
            btnXuatExcelLuoi.TabIndex = 6;
            btnXuatExcelLuoi.Text = "Xuất Excel (lưới)";
            btnXuatExcelLuoi.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcelTonKho
            // 
            btnXuatExcelTonKho.Location = new Point(695, 3);
            btnXuatExcelTonKho.Name = "btnXuatExcelTonKho";
            btnXuatExcelTonKho.Size = new Size(135, 32);
            btnXuatExcelTonKho.TabIndex = 7;
            btnXuatExcelTonKho.Text = "Xuất Excel tồn kho";
            btnXuatExcelTonKho.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai });
            statusStrip1.Location = new Point(0, 539);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(964, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(115, 17);
            lblTrangThai.Text = "Tìm thấy 6 mặt hàng";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 561);
            Controls.Add(statusStrip1);
            Controls.Add(pnlButtons);
            Controls.Add(dgvHangHoa);
            Controls.Add(gbTimKiem);
            Controls.Add(gbThongTin);
            MinimumSize = new Size(900, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hàng hóa - Tạp hóa UTC2";
            gbThongTin.ResumeLayout(false);
            gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
            gbTimKiem.ResumeLayout(false);
            gbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).EndInit();
            pnlButtons.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbThongTin;
        private Label lblTenHang;
        private Label lblLoaiHang;
        private Label lblDonVi;
        private Label lblGiaBan;
        private Label lblSoLuongTon;
        private Label lblNgayNhap;
        private TextBox txtTenHang;
        private ComboBox cboLoaiHang;
        private ComboBox cboDonVi;
        private NumericUpDown nudGiaBan;
        private NumericUpDown nudSoLuongTon;
        private DateTimePicker dtpNgayNhap;
        private CheckBox chkConKinhDoanh;
        private GroupBox gbTimKiem;
        private TextBox txtTimKiem;
        private ComboBox cboLocLoaiHang;
        private CheckBox chkChiConKinhDoanh;
        private DataGridView dgvHangHoa;
        private FlowLayoutPanel pnlButtons;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnXemBangGia;
        private Button btnXuatPdf;
        private Button btnXuatExcelLuoi;
        private Button btnXuatExcelTonKho;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
        private DataGridViewTextBoxColumn colMaHang;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colLoaiHang;
        private DataGridViewTextBoxColumn colDonVi;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewCheckBoxColumn colConKinhDoanh;
    }
}
