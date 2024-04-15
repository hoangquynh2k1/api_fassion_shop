using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class ChiTietSPDAO
    {
        AppDBContext db;
        public ChiTietSPDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<CTSPham> Gets()
        {
            return db.CTSPhams.Where(x => x.TrangThai == true).ToList();
        }
        public CTSPham? Get(int id)
        {
            return db.CTSPhams.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public bool Create(CTSPham o)
        {
            var result = db.CTSPhams.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(CTSPham o)
        {
            var result = db.CTSPhams.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if( result != null )
            {
                result.Size = o.Size;
                result.MauSac = o.MauSac;
                result.SoLuong = o.SoLuong;
                result.HinhAnh = o.HinhAnh;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.CTSPhams.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
