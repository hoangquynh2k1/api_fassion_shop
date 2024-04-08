namespace API_FasionShop.Models
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? SoDT { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Column(TypeName = "TINYINT")]
        public int Quyen { get; set; }
        public string? TenNH { get; set; }
        public string? SoTK { get; set; }
        public bool TrangThai { get; set; }
    }
}
