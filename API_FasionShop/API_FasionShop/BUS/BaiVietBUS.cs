using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class BaiVietBUS : BaiVietDAO
    {
        public BaiVietBUS(AppDBContext db): base(db) { }
    }
}
