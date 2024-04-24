namespace API_FashionShop.Entities
{
    public class CTHDBanEntity
    {
        public int Id { get; set; }
        public int IdHDBan { get; set; }
        public int IdCTSPham { get; set; }
        public string TenSP { get; set; } = string.Empty;
        public string HinhAnh { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public string? Size { get; set; } = string.Empty;
        public string? MauSac { get; set; } = string.Empty;
    }
    public class CTHDBanReport
    {
        public int IdCTSPham { get; set; }
        public int SoLuong { get; set; }

    }
}
