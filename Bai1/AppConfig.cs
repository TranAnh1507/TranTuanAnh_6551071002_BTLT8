using System.Globalization;

namespace Bai1;

public static class AppConfig
{
    public const string ConnectionString =
        @"Server=.;Database=TiemTapHoa;Trusted_Connection=True;TrustServerCertificate=True";

    public const string FrxBangGia = "BangGia.frx";

    public static readonly CultureInfo Vi = new("vi-VN");

    public static string ThuMucReport { get; } = TimThuMucReport();

    public static string DuongDanReport(string tenFile) => Path.Combine(ThuMucReport, tenFile);

    private static string TimThuMucReport()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            if (dir.GetFiles("*.csproj").Length > 0)
            {
                var p = Path.Combine(dir.FullName, "Reports");
                Directory.CreateDirectory(p);
                return p;
            }
            dir = dir.Parent;
        }

        var macDinh = Path.Combine(AppContext.BaseDirectory, "Reports");
        Directory.CreateDirectory(macDinh);
        return macDinh;
    }
}
