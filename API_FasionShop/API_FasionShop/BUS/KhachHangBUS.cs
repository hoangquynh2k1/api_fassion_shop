using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class KhachHangBUS : KhachHangDAO
    {
        public KhachHangBUS(AppDBContext db) : base(db) { }
    }
}
