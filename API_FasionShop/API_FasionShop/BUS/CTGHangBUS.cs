using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class CTGHangBUS : CTGHangDAO
    {
        public CTGHangBUS(AppDBContext db) : base(db) { }

    }
}
