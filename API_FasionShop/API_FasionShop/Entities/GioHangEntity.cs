using API_FashionShop.Models;

namespace API_FashionShop.Entities
{
    public class GioHangEntity
    {
        public int Id { get; set; }
        public int IdKH { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
        public List<CTGHangEntity> cTGHangs { get; set; } = new List<CTGHangEntity>();

    }
}
