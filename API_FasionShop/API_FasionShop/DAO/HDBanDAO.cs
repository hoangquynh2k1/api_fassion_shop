using API_FashionShop.Entities;
using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class HDBanDAO
    {
        AppDBContext db;
        CTHDBanDAO CTHDBanDAO;
        public HDBanDAO(AppDBContext db)
        {
            this.db = db;
            CTHDBanDAO = new CTHDBanDAO(db);
        }
        public List<HDBan> Gets()
        {
            return db.HDBans.Where(x => x.TrangThai == true).ToList();
        }
        public HDBanEntity? Get(int id)
        {
            var hd = db.HDBans.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
            if (hd == null) { return null; }
            var cthd = CTHDBanDAO.GetByIdHDBan(id);
            var hdBanE = new HDBanEntity();
            hdBanE.Id = id;
            hdBanE.IdKH = hd.IdKH;
            hdBanE.IdNV = hd.IdNV;
            hdBanE.IdDiaChi = hd.IdDiaChi;
            hdBanE.GhiChu = hd.GhiChu;
            hdBanE.NgayTao = hd.NgayTao;
            hdBanE.KhuyenMai = hd.KhuyenMai;
            hdBanE.TongTien = hd.TongTien;
            hdBanE.TinhTrangDH = hd.TinhTrangDH;
            hdBanE.TrangThai = hd.TrangThai;
            return hdBanE;
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
