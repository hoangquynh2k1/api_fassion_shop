namespace API_FashionShop.Models
{
    public class BaiViet
    {
        [Key]
        public int Id { get; set; }
        public int IdNV { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime NgayViet { get; set; }
        public bool TrangThai { get; set; }
    }
}
