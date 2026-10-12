using FastReport;
using FastReport.Data;
using FastReport.Export.Pdf;
using System.Collections;
using System.Data;

namespace Bai1.Services;

public static class ReportService
{
    public static bool CoMau(string tenFile) => File.Exists(AppConfig.DuongDanReport(tenFile));

    public static Report TaoReport(string tenFile)
    {
        var path = AppConfig.DuongDanReport(tenFile);
        var report = new Report();

        if (File.Exists(path))
        {
            report.Load(path);
        }
        else
        {
            var page = new ReportPage();
            report.Pages.Add(page);
            page.CreateUniqueName();
        }

        report.FileName = path;
        report.DoublePass = true;
        return report;
    }

    public static void DangKy(Report report, DataTable bang, string ten)
    {
        report.RegisterData(bang, ten);
        var ds = report.GetDataSource(ten);
        if (ds != null)
        {
            ds.Enabled = true;
        }
    }

    public static void DatThamSo(Report report, string ten, object? giaTri)
    {
        var p = report.GetParameter(ten);
        if (p == null)
        {
            p = new Parameter { Name = ten };
            report.Dictionary.Parameters.Add(p);
        }
        p.Value = giaTri;
    }

    public static void XemTruoc(Report report)
    {
        if (report.Prepare())
        {
            report.ShowPrepared(true);
        }
    }

    public static void XuatPdf(Report report, string filePath)
    {
        report.Prepare();
        var pdf = new PDFExport
        {
            ShowProgress = false,
            OpenAfterExport = false
        };
        report.Export(pdf, filePath);
    }
}
