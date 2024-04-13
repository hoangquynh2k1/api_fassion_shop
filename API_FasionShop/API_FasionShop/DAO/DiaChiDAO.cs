using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class DiaChiDAO
    {
        AppDBContext db;
        public DiaChiDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<DiaChi> Gets()
        {
            return db.DiaChis.ToList();
        }
        public DiaChi? Get(int id)
        {
            return db.DiaChis.FirstOrDefault(x => x.Id == id);
        }
        public bool Create(DiaChi o)
        {
            var result = db.DiaChis.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(DiaChi o)
        {
            var result = db.DiaChis.First(x => x.Id == o.Id);
            if(result != null)
            {
                result.IdKH = o.IdKH;
                result.DiaChiNH = o.DiaChiNH;
                result.SoDT = o.SoDT;
                result.GhiChu = o.GhiChu;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.DiaChis.First(x =>x.Id == id);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
