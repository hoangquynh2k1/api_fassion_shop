﻿namespace API_FashionShop.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        public int IdLoaiSP { get; set; }
        public string? TenSP { get; set; }
        public string? MoTa { get; set; }
        public string? ChatLieu { get; set; }
        public string? ThuongHieu { get; set; }
        public int Gia { get; set; }
        public string? HinhAnh1 { get; set; }
        public string? HinhAnh2 { get; set; }
        public string? HinhAnh3 { get; set; }
        public bool TrangThai { get; set; }
    }
}
