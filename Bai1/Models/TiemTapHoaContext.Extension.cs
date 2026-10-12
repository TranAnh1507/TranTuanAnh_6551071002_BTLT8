using Microsoft.EntityFrameworkCore;

namespace Bai1.Models;

public partial class TiemTapHoaContext
{
    public TiemTapHoaContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }
}
