namespace API_FasionShop.Models
{
    public class DiaChi
    {
        [Key]
        public int Id { get; set; }
        public int IdKH { get; set; }
        public string? DiaChiNH { get; set; }
        public string? SoDT { get; set; }
        public string? GhiChu { get; set; }
    }
}
