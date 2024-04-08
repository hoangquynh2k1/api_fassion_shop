namespace API_FashionShop.Models
{
    public class CTSPham
    {
        [Key]
        public int Id { get; set; }
        public int IdSanPham { get; set; }
        public string? Size { get; set; }
        public string? MauSac { get; set; }
        public int SoLuong { get; set; }
        public string? HinhAnh { get; set; }
        public bool TrangThai { get; set; }
    }
}
