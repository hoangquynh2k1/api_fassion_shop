namespace API_FashionShop.Entities
{
    public class User
    {
        public int? MaNguoiDung { get; set; }
        public string TaiKhoan { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public int Role { get; set; }
        public string DiaChi { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DienThoai { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
