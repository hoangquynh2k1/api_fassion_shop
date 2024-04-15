using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class CTGHangDAO
    {
        AppDBContext db;
        public CTGHangDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<CTGHang> Gets()
        {
            return db.CTGHangs.ToList();
        }
        public CTGHang? Get(int id)
        {
            return db.CTGHangs.FirstOrDefault(x => x.Id == id);
        }
        public bool Create(CTGHang o)
        {
            var result = db.CTGHangs.Add(o);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(CTGHang o)
        {
            var result = db.CTGHangs.First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdGh = o.IdGh;
                result.IdCTSP = o.IdCTSP;
                result.SoLuong = o.SoLuong;
                result.Size = o.Size;
                result.MauSac = o.MauSac;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.CTGHangs.First(x => x.Id == id);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
