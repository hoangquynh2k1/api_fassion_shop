using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class DiaChiBUS : DiaChiDAO
    {
        public DiaChiBUS(AppDBContext db) : base(db) { }

    }
}
