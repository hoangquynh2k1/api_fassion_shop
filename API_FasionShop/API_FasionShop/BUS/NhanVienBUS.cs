using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class NhanVienBUS : NhanVienDAO
    {
        public NhanVienBUS(AppDBContext db) : base(db) { }

    }
}
