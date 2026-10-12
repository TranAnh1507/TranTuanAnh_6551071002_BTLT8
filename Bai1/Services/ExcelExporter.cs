using ClosedXML.Excel;
using System.Data;
using Bai1.Models;

namespace Bai1.Services;

public sealed record CotExcel(string TieuDe, string? DinhDang = null, bool CongTong = false, string? CongThuc = null, bool CanPhai = false);

public static class ExcelExporter
{
    public static void XuatDataGridView(DataGridView grid, string filePath, string tenSheet = "DanhSachHangHoa")
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add(tenSheet);

        var cols = grid.Columns.Cast<DataGridViewColumn>()
            .Where(c => c.Visible)
            .OrderBy(c => c.DisplayIndex)
            .ToList();

        // Tiêu đề cột
        for (int c = 0; c < cols.Count; c++)
        {
            ws.Cell(1, c + 1).Value = cols[c].HeaderText;
        }

        var tieuDe = ws.Range(1, 1, 1, cols.Count);
        tieuDe.Style.Font.Bold = true;
        tieuDe.Style.Fill.BackgroundColor = XLColor.FromHtml("#EFEFEF");
        tieuDe.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        var rows = grid.Rows.Cast<DataGridViewRow>()
            .Where(r => !r.IsNewRow)
            .ToList();

        int r = 1;
        foreach (var row in rows)
        {
            r++;
            for (int c = 0; c < cols.Count; c++)
            {
                var cell = ws.Cell(r, c + 1);
                var val = row.Cells[cols[c].Index].Value;

                if (val == null || val == DBNull.Value)
                {
                    cell.Value = "";
                    continue;
                }

                // Chuyển giá trị thành đúng kiểu dữ liệu trong Excel
                switch (val)
                {
                    case decimal dec:
                        cell.Value = Convert.ToDouble(dec);
                        cell.Style.NumberFormat.Format = "#,##0";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        break;
                    case int i:
                        cell.Value = i;
                        cell.Style.NumberFormat.Format = "#,##0";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        break;
                    case long l:
                        cell.Value = l;
                        cell.Style.NumberFormat.Format = "#,##0";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        break;
                    case double d:
                        cell.Value = d;
                        cell.Style.NumberFormat.Format = "#,##0";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        break;
                    case float f:
                        cell.Value = f;
                        cell.Style.NumberFormat.Format = "#,##0";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        break;
                    case DateTime dt:
                        cell.Value = dt;
                        cell.Style.DateFormat.Format = "dd/MM/yyyy";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        break;
                    case bool b:
                        cell.Value = b ? "Còn bán" : "Ngừng bán";
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        break;
                    default:
                        cell.Value = val.ToString();
                        break;
                }
            }
        }

        if (r >= 2)
        {
            ws.Range(1, 1, r, cols.Count).SetAutoFilter();
        }
        ws.SheetView.FreezeRows(1);
        ws.Columns().AdjustToContents();

        wb.SaveAs(filePath);
    }

    public static void XuatExcelTonKho(List<HangHoa> dsHangHoa, string filePath, string tenSheet = "TonKho")
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add(tenSheet);

        // Định nghĩa các cột: Mã hàng, Tên hàng, Loại hàng, Đơn vị, Giá bán, Số lượng tồn, Giá trị tồn
        string[] headers = { "Mã hàng", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Giá trị tồn" };

        for (int i = 0; i < headers.Length; i++)
        {
            ws.Cell(1, i + 1).Value = headers[i];
        }

        var tieuDe = ws.Range(1, 1, 1, headers.Length);
        tieuDe.Style.Font.Bold = true;
        tieuDe.Style.Fill.BackgroundColor = XLColor.FromHtml("#D9E1F2");
        tieuDe.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        int r = 1;
        foreach (var item in dsHangHoa)
        {
            r++;
            ws.Cell(r, 1).Value = item.MaHang;
            ws.Cell(r, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(r, 2).Value = item.TenHang;

            ws.Cell(r, 3).Value = item.LoaiHang ?? "";

            ws.Cell(r, 4).Value = item.DonVi ?? "";
            ws.Cell(r, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Giá bán (cột 5 - E)
            var cellGia = ws.Cell(r, 5);
            cellGia.Value = Convert.ToDouble(item.GiaBan ?? 0);
            cellGia.Style.NumberFormat.Format = "#,##0";
            cellGia.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            // Số lượng tồn (cột 6 - F)
            var cellTon = ws.Cell(r, 6);
            cellTon.Value = item.SoLuongTon ?? 0;
            cellTon.Style.NumberFormat.Format = "#,##0";
            cellTon.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            // Giá trị tồn (cột 7 - G) = Giá bán * Số lượng tồn (Formula E{r}*F{r})
            var cellGiaTri = ws.Cell(r, 7);
            cellGiaTri.FormulaA1 = $"E{r}*F{r}";
            cellGiaTri.Style.NumberFormat.Format = "#,##0";
            cellGiaTri.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        }

        int rCuoi = r;

        // Dòng "Tổng"
        if (rCuoi >= 2)
        {
            int rTong = rCuoi + 1;
            ws.Cell(rTong, 1).Value = "Tổng";
            ws.Range(rTong, 1, rTong, 5).Merge();
            ws.Cell(rTong, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Tổng tồn
            var cellTongTon = ws.Cell(rTong, 6);
            cellTongTon.FormulaA1 = $"SUM(F2:F{rCuoi})";
            cellTongTon.Style.NumberFormat.Format = "#,##0";
            cellTongTon.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            // Tổng giá trị tồn
            var cellTongGiaTri = ws.Cell(rTong, 7);
            cellTongGiaTri.FormulaA1 = $"SUM(G2:G{rCuoi})";
            cellTongGiaTri.Style.NumberFormat.Format = "#,##0";
            cellTongGiaTri.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            ws.Range(rTong, 1, rTong, headers.Length).Style.Font.Bold = true;
            ws.Range(rTong, 1, rTong, headers.Length).Style.Fill.BackgroundColor = XLColor.FromHtml("#F2F2F2");

            // Viền bảng
            ws.Range(1, 1, rTong, headers.Length).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            ws.Range(1, 1, rTong, headers.Length).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            // AutoFilter từ dòng 1 đến rCuoi
            ws.Range(1, 1, rCuoi, headers.Length).SetAutoFilter();
        }

        // Cố định dòng tiêu đề
        ws.SheetView.FreezeRows(1);
        ws.Columns().AdjustToContents();

        wb.SaveAs(filePath);
    }
}
