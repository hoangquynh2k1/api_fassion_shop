namespace API_FasionShop.Models
{
    public class HDBan
    {
        [Key]
        public int Id { get; set; }
        public int IdKH { get; set; }
        public int IdNV { get; set; }
        public int IdDiaChi { get; set; }
        public string? GhiChu { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime NgayTao { get; set; }
        public int KhuyenMai { get; set; }
        public int TongTien { get; set; }
        public bool TrangThai { get; set; }
    }
}
