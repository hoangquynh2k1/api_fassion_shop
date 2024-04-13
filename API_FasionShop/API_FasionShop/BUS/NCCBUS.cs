using API_FashionShop.DAO;
using API_FashionShop.Models;

namespace API_FashionShop.BUS
{
    public class NCCBUS : NCCDAO
    {
        public NCCBUS(AppDBContext db) : base(db) { }
    }
}
