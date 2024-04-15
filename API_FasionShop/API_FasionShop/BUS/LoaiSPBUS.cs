using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class LoaiSPBUS : LoaiSPDAO
    {
        public LoaiSPBUS(AppDBContext db): base(db) { }
    }
}
