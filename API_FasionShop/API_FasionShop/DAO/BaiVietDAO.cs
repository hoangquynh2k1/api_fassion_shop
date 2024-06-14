using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class BaiVietDAO
    {
        AppDBContext db;
        public BaiVietDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<BaiViet> Gets()
        {
            return db.BaiViets.Where(x => x.TrangThai == true).ToList();
        }
        public BaiViet Get(int id)
        {
            return db.BaiViets.Where(x => x.TrangThai == true).First(x => x.Id == id);
        }
        public bool Create(BaiViet o)
        {
            var result = db.BaiViets.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(BaiViet o)
        {
            var result = db.BaiViets.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.TieuDe = o.TieuDe;
                result.NoiDung = o.NoiDung;
                result.NgayViet = o.NgayViet;
                result.HinhAnh = o.HinhAnh;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.BaiViets.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
