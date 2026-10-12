using System.Diagnostics;
using System.Drawing.Printing;
using Bai1.Services;

namespace Bai1.Helpers;

public static class UiHelper
{
    public static string? ChonFileLuu(string boLoc, string tenMacDinh)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = boLoc,
            FileName = tenMacDinh,
            OverwritePrompt = true,
            Title = "Chọn nơi lưu file"
        };
        return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
    }

    public static void HoiMoFile(IWin32Window owner, string path)
    {
        var kq = MessageBox.Show(owner, $"Đã lưu file:\n{path}\n\nMở file ngay?", "Hoàn tất",
            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (kq == DialogResult.Yes)
        {
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }
    }

    public static bool CoMauReport(IWin32Window owner, string tenFile)
    {
        if (ReportService.CoMau(tenFile)) return true;

        MessageBox.Show(owner,
            $"Chưa có mẫu report \"{tenFile}\".\n\nVui lòng kiểm tra file trong thư mục Reports.",
            "Chưa có mẫu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    public static void Chay(IWin32Window owner, Action tacVu)
    {
        try
        {
            tacVu();
        }
        catch (Exception ex)
        {
            HienLoi(owner, ex);
        }
    }

    public static async void ChayAsync(IWin32Window owner, Func<Task> tacVu)
    {
        var ctl = owner as Control;
        try
        {
            if (ctl != null) ctl.Cursor = Cursors.WaitCursor;
            await tacVu();
        }
        catch (Exception ex)
        {
            HienLoi(owner, ex);
        }
        finally
        {
            if (ctl != null && !ctl.IsDisposed) ctl.Cursor = Cursors.Default;
        }
    }

    public static void HienLoi(IWin32Window owner, Exception ex)
    {
        var goc = ex.GetBaseException();
        string goiY = ex switch
        {
            InvalidPrinterException =>
                "\n\nGợi ý: Máy tính chưa có máy in. Cài \"Microsoft Print to PDF\" (Windows Features) để thử in.",
            IOException =>
                "\n\nGợi ý: File có thể đang được mở bởi ứng dụng khác (ví dụ: Excel hoặc trình đọc PDF). Hãy đóng file rồi thử lại.",
            _ when goc is Microsoft.Data.SqlClient.SqlException =>
                "\n\nGợi ý: Kiểm tra dịch vụ SQL Server LocalDB đã được bật và CSDL TiemTapHoa đã được tạo đầy đủ chưa.",
            _ => ""
        };

        MessageBox.Show(owner, goc.Message + goiY, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
