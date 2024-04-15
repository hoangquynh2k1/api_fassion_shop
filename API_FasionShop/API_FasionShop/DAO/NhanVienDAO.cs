using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class NhanVienDAO
    {
        AppDBContext db;
        public NhanVienDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<NhanVien> Gets()
        {
            return db.NhanViens.Where(x => x.TrangThai == true).ToList();
        }
        public NhanVien? Get(int id)
        {
            return db.NhanViens.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public bool Create(NhanVien o)
        {
            var result = db.NhanViens.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(NhanVien o)
        {
            var result = db.NhanViens.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.HoTen = o.HoTen;
                result.NgaySinh = o.NgaySinh;
                result.SoDT = o.SoDT;
                result.Email = o.Email;
                result.Password = o.Password;
                result.Quyen = o.Quyen;
                result.TenNH = o.TenNH;
                result.SoTK = o.SoTK;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.NhanViens.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
