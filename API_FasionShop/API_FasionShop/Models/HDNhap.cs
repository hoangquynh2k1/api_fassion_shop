namespace API_FasionShop.Models
{
    public class HDNhap
    {
        [Key]
        public int Id { get; set; }
        public int IdNcc { get; set; }
        public int IdNhanVien { get; set; }
        [Column(TypeName = "Date")]
        public DateTime NgayNhap { get; set; }
        public bool TrangThai { get; set; }
    }
}
