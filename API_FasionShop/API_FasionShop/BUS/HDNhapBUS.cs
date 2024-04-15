using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class HDNhapBUS : HDNhapDAO
    {
        public HDNhapBUS(AppDBContext db) : base(db) { }

    }
}
