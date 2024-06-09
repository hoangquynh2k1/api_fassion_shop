using API_FashionShop.Models;

namespace API_FashionShop.Entities
{
    public class HDBanEntity
    {
        public int Id { get; set; }
        public string TenKH { get; set; }
        public string Email { get; set; }
        public string TenNV { get; set; }
        public DiaChi DiaChi { get; set; }
        public string? GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public int KhuyenMai { get; set; }
        public int TongTien { get; set; }
        public int TinhTrangDH { get; set; }
        public bool TrangThai { get; set; }
        public List<CTHDBanEntity> CTHDBans { get; set; } = new List<CTHDBanEntity>(); 
    }
}
