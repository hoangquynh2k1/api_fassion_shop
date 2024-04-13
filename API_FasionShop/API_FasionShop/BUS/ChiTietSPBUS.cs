using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class ChiTietSPBUS : ChiTietSPDAO
    {
        public ChiTietSPBUS(AppDBContext db) : base(db) { }

    }
}
