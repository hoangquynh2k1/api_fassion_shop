using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class KhachHangDAO
    {
        AppDBContext db;
        public KhachHangDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<KhachHang> Gets()
        {
            return db.KhachHangs.Where(x => x.TrangThai == true).ToList();
        }
        public KhachHang? Get(int id)
        {
            return db.KhachHangs.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public bool Create(KhachHang o)
        {
            var result = db.KhachHangs.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(KhachHang o)
        {
            var result = db.KhachHangs.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.HoTen = o.HoTen;
                result.NgaySinh = o.NgaySinh;
                result.SoDT = o.SoDT;
                result.Email = o.Email;
                result.GioiTinh = o.GioiTinh;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.KhachHangs.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
