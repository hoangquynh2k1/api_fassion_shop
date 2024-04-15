using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class GioHangBUS : GioHangDAO
    {
        public GioHangBUS(AppDBContext db) : base(db) { }

    }
}
