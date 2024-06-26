﻿namespace API_FashionShop.Models
{
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }
        public string? HoTen { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime NgaySinh { get; set; }
        public string? SoDT { get; set; }
        public string? Email { get; set; }
        public string? TenDN { get; set; }
        public string? MatKhau { get; set; }
        public bool GioiTinh { get; set; }
        public bool TrangThai { get; set; }
    }
}
