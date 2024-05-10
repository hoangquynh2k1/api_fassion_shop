namespace API_FashionShop.Entities
{
    public class CTGHangEntity
    {
        public int Id { get; set; }
        public int IdGh { get; set; }
        public int IdCTSP { get; set; }
        public string TenSP { get; set; } = string.Empty;
        public string HinhAnh { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public string? Size { get; set; } = string.Empty;
        public string? MauSac { get; set; } = string.Empty;

    }
}
