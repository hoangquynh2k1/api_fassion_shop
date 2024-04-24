using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class HDBanDAO
    {
        AppDBContext db;
        public HDBanDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<HDBan> Gets()
        {
            return db.HDBans.Where(x => x.TrangThai == true).ToList();
        }
        public HDBan? Get(int id)
        {
            return db.HDBans.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }
        public List<HDBan> GetByIdHKH(int id)
        {
            return db.HDBans.Where(x => x.TrangThai == true && x.IdKH == id).ToList();
        }
        public bool Create(HDBan o)
        {
            var result = db.HDBans.Add(o);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(HDBan o)
        {
            var result = db.HDBans.Where(x => x.TrangThai == true).First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdKH = o.IdKH;
                result.IdNV = o.IdNV;
                result.IdDiaChi = o.IdDiaChi;
                result.GhiChu = o.GhiChu;
                result.NgayTao = o.NgayTao;
                result.KhuyenMai = o.KhuyenMai;
                result.TongTien = o.TongTien;
                result.TrangThai = o.TrangThai;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.HDBans.Where(x => x.TrangThai == true).First(x => x.Id == id);
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
