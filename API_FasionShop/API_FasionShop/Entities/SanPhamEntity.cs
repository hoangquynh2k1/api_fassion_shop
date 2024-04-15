using API_FashionShop.Models;

namespace API_FashionShop.Entities
{
    public class SanPhamEntity
    {
        public int Id { get; set; }
        public int IdLoaiSP { get; set; }
        public string? TenSP { get; set; }
        public string? MoTa { get; set; }
        public int Gia { get; set; }
        public string? HinhAnh { get; set; }
        public List<CTSPham>? CTSPhams { get; set; }
    }
}
