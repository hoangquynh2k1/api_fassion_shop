using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class SanPhamDAO
    {
        AppDBContext db;
        public SanPhamDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<SanPham> Gets()
        {
            return db.SanPhams.Where(x => x.TrangThai == true).ToList();
        }
        public SanPham? Get(int id)
        {
            return db.SanPhams.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public bool Create(SanPham o)
        {
            var result = db.SanPhams.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(SanPham o)
        {
            var result = db.SanPhams.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == o.Id);
            if (result != null)
            {
                result.TenSP = o.TenSP;
                result.MoTa = o.MoTa;
                result.Gia = o.Gia;
                result.HinhAnh1 = o.HinhAnh1;
                result.HinhAnh2 = o.HinhAnh2;
                result.HinhAnh3 = o.HinhAnh3;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.SanPhams.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
