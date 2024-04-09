namespace API_FashionShop.Models
{
    public class CTHDNhap
    {
        [Key]
        public int Id { get; set; }
        public int IdHDNhap { get; set; }
        public int IdCTSPham { get; set; }
        public int GiaNhap { get; set; }
        public int SoLuong { get; set; }
    }
}
