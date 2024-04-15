using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class GioHangDAO
    {
        AppDBContext db;
        public GioHangDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<GioHang> Gets()
        {
            return db.GioHangs.Where(x => x.TrangThai == true).ToList();
        }
        public GioHang? Get(int id)
        {
            return db.GioHangs.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public bool Create(GioHang o)
        {
            var result = db.GioHangs.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(GioHang o)
        {
            var result = db.GioHangs.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdKH = o.IdKH;
                result.NgayTao = o.NgayTao;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.GioHangs.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
