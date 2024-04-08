namespace API_FasionShop.Models
{
    public class Ncc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? TenNCC { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDT { get; set; }
        public string? Email { get; set; }
        public bool TrangThai { get; set; }
    }
}
