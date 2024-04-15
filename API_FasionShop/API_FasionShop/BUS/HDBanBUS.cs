using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class HDBanBUS : HDBanDAO
    {
        public HDBanBUS(AppDBContext db) : base(db) { }

    }
}
