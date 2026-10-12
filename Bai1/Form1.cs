using System.Data;
using Microsoft.EntityFrameworkCore;
using Bai1.Helpers;
using Bai1.Models;
using Bai1.Services;

namespace Bai1;

public partial class Form1 : Form
{
    private readonly System.Windows.Forms.Timer _timerTim = new() { Interval = 350 };
    private int _maHangDangChon = 0;
    private List<HangHoa> _dsHienThi = new();

    public Form1()
    {
        InitializeComponent();

        Load += (_, _) => UiHelper.ChayAsync(this, KhoiTaoFormAsync);

        // Sự kiện tìm kiếm & bộ lọc
        txtTimKiem.TextChanged += (_, _) =>
        {
            _timerTim.Stop();
            _timerTim.Start();
        };

        _timerTim.Tick += (_, _) =>
        {
            _timerTim.Stop();
            UiHelper.ChayAsync(this, TaiDanhSachAsync);
        };

        cboLocLoaiHang.SelectedIndexChanged += (_, _) => UiHelper.ChayAsync(this, TaiDanhSachAsync);
        chkChiConKinhDoanh.CheckedChanged += (_, _) => UiHelper.ChayAsync(this, TaiDanhSachAsync);

        // DataGridView selection
        dgvHangHoa.SelectionChanged += (_, _) => DoDuLieuLenControl();

        // Nút bấm
        btnThem.Click += (_, _) => UiHelper.ChayAsync(this, ThemHangHoaAsync);
        btnSua.Click += (_, _) => UiHelper.ChayAsync(this, SuaHangHoaAsync);
        btnXoa.Click += (_, _) => UiHelper.ChayAsync(this, XoaHangHoaAsync);
        btnLamMoi.Click += (_, _) => UiHelper.ChayAsync(this, LamMoiAsync);

        btnXemBangGia.Click += (_, _) => UiHelper.ChayAsync(this, XemBangGiaAsync);
        btnXuatPdf.Click += (_, _) => UiHelper.ChayAsync(this, XuatPdfAsync);
        btnXuatExcelLuoi.Click += (_, _) => XuatExcelLuoi();
        btnXuatExcelTonKho.Click += (_, _) => UiHelper.ChayAsync(this, XuatExcelTonKhoAsync);

        FormClosed += (_, _) => _timerTim.Dispose();
    }

    private async Task KhoiTaoFormAsync()
    {
        // Khởi tạo ComboBox loại hàng cho tìm kiếm
        cboLocLoaiHang.Items.Clear();
        cboLocLoaiHang.Items.Add("Tất cả các loại");
        cboLocLoaiHang.Items.Add("Đồ uống");
        cboLocLoaiHang.Items.Add("Thực phẩm khô");
        cboLocLoaiHang.Items.Add("Gia vị");
        cboLocLoaiHang.Items.Add("Đồ gia dụng");
        cboLocLoaiHang.SelectedIndex = 0;

        // ComboBox nhập liệu
        if (cboLoaiHang.SelectedIndex < 0 && cboLoaiHang.Items.Count > 0)
            cboLoaiHang.SelectedIndex = 0;
        if (cboDonVi.SelectedIndex < 0 && cboDonVi.Items.Count > 0)
            cboDonVi.SelectedIndex = 0;

        dtpNgayNhap.Value = DateTime.Today;

        await TaiDanhSachAsync();
    }

    private async Task TaiDanhSachAsync()
    {
        using var db = new TiemTapHoaContext();
        var query = db.HangHoas.AsNoTracking().AsQueryable();

        // Lọc theo tên hàng
        string tuKhoa = txtTimKiem.Text.Trim();
        if (!string.IsNullOrWhiteSpace(tuKhoa))
        {
            query = query.Where(h => h.TenHang.Contains(tuKhoa));
        }

        // Lọc theo loại hàng
        string loaiChon = cboLocLoaiHang.SelectedItem?.ToString() ?? "";
        if (!string.IsNullOrEmpty(loaiChon) && loaiChon != "Tất cả các loại")
        {
            query = query.Where(h => h.LoaiHang == loaiChon);
        }

        // Lọc theo còn kinh doanh
        if (chkChiConKinhDoanh.Checked)
        {
            query = query.Where(h => h.ConKinhDoanh);
        }

        _dsHienThi = await query.OrderBy(h => h.MaHang).ToListAsync();
        dgvHangHoa.DataSource = _dsHienThi;

        lblTrangThai.Text = $"Tìm thấy {_dsHienThi.Count} mặt hàng";
    }

    private void DoDuLieuLenControl()
    {
        if (dgvHangHoa.CurrentRow?.DataBoundItem is HangHoa hh)
        {
            _maHangDangChon = hh.MaHang;
            txtTenHang.Text = hh.TenHang;

            if (!string.IsNullOrEmpty(hh.LoaiHang))
                cboLoaiHang.SelectedItem = hh.LoaiHang;

            if (!string.IsNullOrEmpty(hh.DonVi))
                cboDonVi.SelectedItem = hh.DonVi;

            nudGiaBan.Value = hh.GiaBan ?? 0;
            nudSoLuongTon.Value = hh.SoLuongTon ?? 0;
            dtpNgayNhap.Value = hh.NgayNhap ?? DateTime.Today;
            chkConKinhDoanh.Checked = hh.ConKinhDoanh;
        }
    }

    private async Task ThemHangHoaAsync()
    {
        if (string.IsNullOrWhiteSpace(txtTenHang.Text))
        {
            MessageBox.Show("Tên hàng không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenHang.Focus();
            return;
        }

        if (nudGiaBan.Value <= 0)
        {
            MessageBox.Show("Giá bán phải lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudGiaBan.Focus();
            return;
        }

        var hh = new HangHoa
        {
            TenHang = txtTenHang.Text.Trim(),
            LoaiHang = cboLoaiHang.SelectedItem?.ToString() ?? "Đồ uống",
            DonVi = cboDonVi.SelectedItem?.ToString() ?? "Chai",
            GiaBan = nudGiaBan.Value,
            SoLuongTon = (int)nudSoLuongTon.Value,
            NgayNhap = dtpNgayNhap.Value,
            ConKinhDoanh = chkConKinhDoanh.Checked
        };

        using var db = new TiemTapHoaContext();
        db.HangHoas.Add(hh);
        await db.SaveChangesAsync();

        MessageBox.Show("Thêm hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        await TaiDanhSachAsync();
    }

    private async Task SuaHangHoaAsync()
    {
        if (_maHangDangChon == 0)
        {
            MessageBox.Show("Vui lòng chọn hàng hóa cần sửa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTenHang.Text))
        {
            MessageBox.Show("Tên hàng không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenHang.Focus();
            return;
        }

        if (nudGiaBan.Value <= 0)
        {
            MessageBox.Show("Giá bán phải lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudGiaBan.Focus();
            return;
        }

        using var db = new TiemTapHoaContext();
        var hh = await db.HangHoas.FindAsync(_maHangDangChon);
        if (hh == null)
        {
            MessageBox.Show("Không tìm thấy hàng hóa cần sửa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        hh.TenHang = txtTenHang.Text.Trim();
        hh.LoaiHang = cboLoaiHang.SelectedItem?.ToString();
        hh.DonVi = cboDonVi.SelectedItem?.ToString();
        hh.GiaBan = nudGiaBan.Value;
        hh.SoLuongTon = (int)nudSoLuongTon.Value;
        hh.NgayNhap = dtpNgayNhap.Value;
        hh.ConKinhDoanh = chkConKinhDoanh.Checked;

        await db.SaveChangesAsync();

        MessageBox.Show("Cập nhật thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        await TaiDanhSachAsync();
    }

    private async Task XoaHangHoaAsync()
    {
        if (_maHangDangChon == 0)
        {
            MessageBox.Show("Vui lòng chọn hàng hóa cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var xacNhan = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa mặt hàng \"{txtTenHang.Text}\" (Mã: {_maHangDangChon}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes) return;

        using var db = new TiemTapHoaContext();
        var hh = await db.HangHoas.FindAsync(_maHangDangChon);
        if (hh != null)
        {
            db.HangHoas.Remove(hh);
            await db.SaveChangesAsync();
            MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DatLaiFormNhap();
            await TaiDanhSachAsync();
        }
        else
        {
            MessageBox.Show("Không tìm thấy hàng hóa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DatLaiFormNhap()
    {
        _maHangDangChon = 0;
        txtTenHang.Clear();
        if (cboLoaiHang.Items.Count > 0) cboLoaiHang.SelectedIndex = 0;
        if (cboDonVi.Items.Count > 0) cboDonVi.SelectedIndex = 0;
        nudGiaBan.Value = 0;
        nudSoLuongTon.Value = 0;
        dtpNgayNhap.Value = DateTime.Today;
        chkConKinhDoanh.Checked = true;
    }

    private async Task LamMoiAsync()
    {
        DatLaiFormNhap();
        txtTimKiem.Clear();
        cboLocLoaiHang.SelectedIndex = 0;
        chkChiConKinhDoanh.Checked = false;
        await TaiDanhSachAsync();
    }

    private async Task XemBangGiaAsync()
    {
        if (!UiHelper.CoMauReport(this, AppConfig.FrxBangGia)) return;

        using var db = new TiemTapHoaContext();
        var dsConKinhDoanh = await db.HangHoas.AsNoTracking()
            .Where(h => h.ConKinhDoanh)
            .OrderBy(h => h.MaHang)
            .ToListAsync();

        var dt = DataTableHelper.ToDataTable(dsConKinhDoanh, "HangHoa");
        using var r = ReportService.TaoReport(AppConfig.FrxBangGia);
        ReportService.DangKy(r, dt, "HangHoa");
        ReportService.DatThamSo(r, "NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
        ReportService.XemTruoc(r);
    }

    private async Task XuatPdfAsync()
    {
        if (!UiHelper.CoMauReport(this, AppConfig.FrxBangGia)) return;

        var path = UiHelper.ChonFileLuu("Tệp PDF (*.pdf)|*.pdf", $"BangGia_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
        if (path == null) return;

        using var db = new TiemTapHoaContext();
        var dsConKinhDoanh = await db.HangHoas.AsNoTracking()
            .Where(h => h.ConKinhDoanh)
            .OrderBy(h => h.MaHang)
            .ToListAsync();

        var dt = DataTableHelper.ToDataTable(dsConKinhDoanh, "HangHoa");
        using var r = ReportService.TaoReport(AppConfig.FrxBangGia);
        ReportService.DangKy(r, dt, "HangHoa");
        ReportService.DatThamSo(r, "NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
        ReportService.XuatPdf(r, path);

        UiHelper.HoiMoFile(this, path);
    }

    private void XuatExcelLuoi()
    {
        var path = UiHelper.ChonFileLuu("Tệp Excel (*.xlsx)|*.xlsx", $"HangHoa_Luoi_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");
        if (path == null) return;

        UiHelper.Chay(this, () =>
        {
            ExcelExporter.XuatDataGridView(dgvHangHoa, path, "DanhSachHangHoa");
            UiHelper.HoiMoFile(this, path);
        });
    }

    private async Task XuatExcelTonKhoAsync()
    {
        var path = UiHelper.ChonFileLuu("Tệp Excel (*.xlsx)|*.xlsx", $"HangHoa_TonKho_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");
        if (path == null) return;

        using var db = new TiemTapHoaContext();
        var dsConKinhDoanh = await db.HangHoas.AsNoTracking()
            .Where(h => h.ConKinhDoanh)
            .OrderBy(h => h.MaHang)
            .ToListAsync();

        ExcelExporter.XuatExcelTonKho(dsConKinhDoanh, path, "TonKho");
        UiHelper.HoiMoFile(this, path);
    }
}
