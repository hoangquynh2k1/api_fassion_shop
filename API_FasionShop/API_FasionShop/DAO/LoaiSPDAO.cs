using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class LoaiSPDAO
    {
        AppDBContext db;
        public LoaiSPDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<LoaiSP> Gets()
        {
            return db.LoaiSPs.Where(x => x.TrangThai == true).ToList();
        }
        public LoaiSP Get(int id)
        {
            return db.LoaiSPs.Where(x => x.TrangThai == true).First(x => x.Id == id);
        }
        public bool Create(LoaiSP o)
        {
            var result = db.LoaiSPs.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(LoaiSP o)
        {
            var result = db.LoaiSPs.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.TenLoai = o.TenLoai;
                result.MoTa = o.MoTa;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.LoaiSPs.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
