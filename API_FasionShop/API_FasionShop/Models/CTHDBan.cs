namespace API_FashionShop.Models
{
    public class CTHDBan
    {
        [Key]
        public int Id { get; set; }
        public int IdHDBan { get; set; }
        public int IdCTSPham { get; set; }
        public int SoLuong { get; set; }
    }
}
