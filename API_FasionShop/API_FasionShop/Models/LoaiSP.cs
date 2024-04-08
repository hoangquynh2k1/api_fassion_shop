namespace API_FasionShop.Models
{
    public class LoaiSP
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? TenLoai { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
    }
}
