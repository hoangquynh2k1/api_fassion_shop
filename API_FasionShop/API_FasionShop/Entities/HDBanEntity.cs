namespace API_FashionShop.Entities
{
    public class HDBanEntity
    {
        public int Id { get; set; }
        public int IdKH { get; set; }
        public int IdNV { get; set; }
        public int IdDiaChi { get; set; }
        public string? GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public int KhuyenMai { get; set; }
        public int TongTien { get; set; }
        public bool TrangThai { get; set; }
        public List<CTHDBanEntity> CTHDBans { get; set; } = new List<CTHDBanEntity>(); 
    }
}
