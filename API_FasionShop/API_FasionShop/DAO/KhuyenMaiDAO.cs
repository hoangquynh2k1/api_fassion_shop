using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class KhuyenMaiDAO
    {
        AppDBContext db;
        public KhuyenMaiDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<KhuyenMai> Gets()
        {
            return db.KhuyenMais.ToList();
        }
        public KhuyenMai? Get(int id)
        {
            return db.KhuyenMais.FirstOrDefault(x => x.Id == id);
        }
        public KhuyenMai? CheckDiscount(string id)
        {
            var km = db.KhuyenMais.FirstOrDefault(x => x.DiscountId == id);
            if (km != null)
            {
                return km;
            }
            return km;
        }
        public bool Create(KhuyenMai o)
        {
            var result = db.KhuyenMais.Add(o);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(KhuyenMai o)
        {
            var result = db.KhuyenMais.First(x => x.Id == o.Id);
            if (result != null)
            {
                result.NgayAD = o.NgayAD;
                result.NgayKT = o.NgayKT;
                result.TiLeKM = o.TiLeKM;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.KhuyenMais.First(x => x.Id == id);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
