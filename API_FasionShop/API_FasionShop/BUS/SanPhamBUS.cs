using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class SanPhamBUS : SanPhamDAO
    {
        public SanPhamBUS(AppDBContext db) : base(db) { }
    }
}
