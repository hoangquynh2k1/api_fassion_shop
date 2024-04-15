using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class CTHDBanBUS : CTHDBanDAO
    {
        public CTHDBanBUS(AppDBContext db) : base(db) { }

    }
}
