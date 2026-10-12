using System.Data;
using System.Drawing.Imaging;
using Microsoft.EntityFrameworkCore;
using Bai1.Helpers;
using Bai1.Models;
using Bai1.Services;

namespace Bai1;

public static class TestCapture
{
    public static void ChayTuDong()
    {
        string thuMuc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Screenshots");
        Directory.CreateDirectory(thuMuc);

        var form = new Form1();

        form.Shown += async (_, _) =>
        {
            try
            {
                File.AppendAllText("capture.log", "Form Shown bat dau...\n");
                await Task.Delay(1200);
                File.AppendAllText("capture.log", "Delay 1200 xong\n");

                // 1. Chụp màn hình form chính đủ 6 hàng
                ChupForm(form, Path.Combine(thuMuc, "01_DanhSachDayDu.png"));

                // 2. Tìm kiếm "nước"
                var txtTim = form.Controls.Find("txtTimKiem", true).FirstOrDefault() as TextBox;
                if (txtTim != null)
                {
                    txtTim.Text = "nước";
                    await Task.Delay(800);
                    ChupForm(form, Path.Combine(thuMuc, "02_TimKiem_Nuoc.png"));
                }

                // 3. Tích thêm "Chỉ hiện hàng còn kinh doanh"
                var chkConKD = form.Controls.Find("chkChiConKinhDoanh", true).FirstOrDefault() as CheckBox;
                if (chkConKD != null)
                {
                    chkConKD.Checked = true;
                    await Task.Delay(800);
                    ChupForm(form, Path.Combine(thuMuc, "03_TimKiem_Nuoc_ConKinhDoanh.png"));
                }

                // 4. Xuất file Excel tồn kho
                using (var db = new TiemTapHoaContext())
                {
                    var dsConKinhDoanh = await db.HangHoas.AsNoTracking()
                        .Where(h => h.ConKinhDoanh)
                        .OrderBy(h => h.MaHang)
                        .ToListAsync();

                    string excelPath = Path.Combine(thuMuc, "HangHoa_TonKho.xlsx");
                    ExcelExporter.XuatExcelTonKho(dsConKinhDoanh, excelPath);

                    // Xuất Report Bảng giá sang PDF
                    var dt = DataTableHelper.ToDataTable(dsConKinhDoanh, "HangHoa");
                    using var r = ReportService.TaoReport(AppConfig.FrxBangGia);
                    ReportService.DangKy(r, dt, "HangHoa");
                    ReportService.DatThamSo(r, "NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));

                    string pdfPath = Path.Combine(thuMuc, "BangGia.pdf");
                    ReportService.XuatPdf(r, pdfPath);

                    // Xuất ảnh report
                    try
                    {
                        var imgExp = new FastReport.Export.Image.ImageExport
                        {
                            ShowProgress = false,
                            OpenAfterExport = false,
                            ImageFormat = FastReport.Export.Image.ImageExportFormat.Png
                        };
                        r.Export(imgExp, Path.Combine(thuMuc, "04_ReportBangGia.png"));
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText("capture.log", "ImageExport warning: " + ex.Message + "\n");
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("capture.log", "Lỗi trong Shown: " + ex.ToString() + "\n");
            }
            finally
            {
                form.Close();
            }
        };

        Application.Run(form);
    }

    private static void ChupForm(Form form, string duongDan)
    {
        using var bmp = new Bitmap(form.Width, form.Height);
        form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
        bmp.Save(duongDan, ImageFormat.Png);
    }
}
