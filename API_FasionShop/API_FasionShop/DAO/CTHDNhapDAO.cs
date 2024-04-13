using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class CTHDNhapDAO
    {
        AppDBContext db;
        public CTHDNhapDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<CTHDNhap> Gets()
        {
            return db.CTHDNhaps.ToList();
        }
        public CTHDNhap? Get(int id)
        {
            return db.CTHDNhaps.FirstOrDefault(x => x.Id == id);
        }
        public bool Create(CTHDNhap o)
        {
            var result = db.CTHDNhaps.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(CTHDNhap o)
        {
            var result = db.CTHDNhaps.First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdHDNhap = o.IdHDNhap;
                result.IdCTSPham = o.IdCTSPham;
                result.GiaNhap = o.GiaNhap;
                result.SoLuong = o.SoLuong;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.CTHDNhaps.First(x => x.Id == id);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
