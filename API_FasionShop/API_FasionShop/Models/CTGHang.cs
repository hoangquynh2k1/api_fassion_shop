namespace API_FashionShop.Models
{
    public class CTGHang
    {
        [Key]
        public int Id { get; set; }
        public int IdGh {  get; set; }
        public int IdCTSP { get; set; }
        public int SoLuong { get; set; }
        public string? Size { get; set; }
        public string? MauSac { get; set; }
    }
}
