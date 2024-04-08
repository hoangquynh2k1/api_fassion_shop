namespace API_FasionShop.Models
{
    public class KhuyenMai
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime NgayAD { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime NgayKT { get; set; }
        public double TiLeKM { get; set; }
    }
}
