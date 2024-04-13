using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class NCCDAO
    {
        AppDBContext db;
        public NCCDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<Ncc> Gets()
        {
            return db.Nccs.Where(x => x.TrangThai == true).ToList();
        }
        public Ncc? Get(int id)
        {
            return db.Nccs.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public bool Create(Ncc o)
        {
            var result = db.Nccs.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(Ncc o)
        {
            var result = db.Nccs.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.TenNCC = o.TenNCC;
                result.DiaChi = o.DiaChi;
                result.SoDT = o.SoDT;
                result.Email = o.Email;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.Nccs.Where(x => x.TrangThai == true).First(x => x.Id == id);
            if (result != null)
            {
                result.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
