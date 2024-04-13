using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class HDNhapDAO
    {
        AppDBContext db;
        public HDNhapDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<HDNhap> Gets()
        {
            return db.HDNhaps.Where(x => x.TrangThai == true).ToList();
        }
        public HDNhap? Get(int id)
        {
            return db.HDNhaps.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);

        }
        public bool Create(HDNhap o)
        {
            var result = db.HDNhaps.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(HDNhap o)
        {
            var result = db.HDNhaps.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdNcc = o.IdNcc;
                result.IdNhanVien = o.IdNhanVien;
                result.NgayNhap = o.NgayNhap;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.HDNhaps.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
