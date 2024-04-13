using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class CTHDBanDAO
    {
        AppDBContext db;
        public CTHDBanDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<CTHDBan> Gets()
        {
            return db.CTHDBans.ToList();
        }
        public CTHDBan? Get(int id)
        {
            return db.CTHDBans.FirstOrDefault(x => x.Id == id);
        }
        public bool Create(CTHDBan o)
        {
            var result = db.CTHDBans.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(CTHDBan o)
        {
            var result = db.CTHDBans.First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdHDBan = o.IdHDBan;
                result.IdCTSPham = o.IdCTSPham;
                result.SoLuong = o.SoLuong;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.CTHDBans.First(x => x.Id == id);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
