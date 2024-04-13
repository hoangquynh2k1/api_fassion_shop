using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class KhuyenMaiBUS : KhuyenMaiDAO
    {
        public KhuyenMaiBUS(AppDBContext db) : base(db) { }

    }
}
