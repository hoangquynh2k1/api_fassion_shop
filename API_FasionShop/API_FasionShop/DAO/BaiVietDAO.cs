using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class BaiVietDAO
    {
        AppDBContext db;
        public BaiVietDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<BaiViet> Gets()
        {
            return db.BaiViets.ToList();
        }
    }
}
