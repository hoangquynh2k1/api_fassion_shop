namespace API_FasionShop.Models
{
    public class GioHang
    {
        [Key]
        public int Id { get; set; }
        public int IdKH { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
    }
}
