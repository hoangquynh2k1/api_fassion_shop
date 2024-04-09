using API_FashionShop.Models;

namespace API_FashionShop.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<BaiViet> BaiViets { set; get; }
        public DbSet<CTGHang> CTGHangs { set; get; }
        public DbSet<CTHDBan> CTHDBans { set; get; }
        public DbSet<CTHDNhap> CTHDNhaps { set; get; }
        public DbSet<CTSPham> CTSPhams { set; get; }
        public DbSet<DiaChi> DiaChis { set; get; }
        public DbSet<GioHang> GioHangs { set; get; }
        public DbSet<HDBan> HDBans { set; get; }
        public DbSet<HDNhap> HDNhaps { set; get; }
        public DbSet<KhachHang> KhachHangs { set; get; }
        public DbSet<KhuyenMai> KhuyenMais { set; get; }
        public DbSet<LoaiSP> LoaiSPs { set; get; }
        public DbSet<Ncc> Nccs { set; get; }
        public DbSet<NhanVien> NhanViens { set; get; }
        public DbSet<SanPham> SanPhams { set; get; }
    }
}
