using API_FashionShop.Entities;
using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class GioHangDAO
    {
        AppDBContext db;
        CTGHangDAO CTGHangDAO;
        public GioHangDAO(AppDBContext db)
        {
            this.db = db;
            CTGHangDAO = new CTGHangDAO(db);
        }
        public List<GioHang> Gets()
        {
            return db.GioHangs.Where(x => x.TrangThai == true).ToList();
        }
        public GioHangEntity? Get(int id)
        {
            var gh = db.GioHangs.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
            if (gh == null) { return null; }
            var ctgh = CTGHangDAO.GetByIdGH(id);
            var gioHangE = new GioHangEntity();
            gioHangE.Id = id;
            gioHangE.IdKH = gh.IdKH;
            gioHangE.NgayTao = gh.NgayTao;
            gioHangE.TrangThai = gh.TrangThai;
            gioHangE.cTGHangs = ctgh;
            return gioHangE;
        }
        public GioHangEntity? GetByIdKH(int id)
        {
            var gh = db.GioHangs.Where(x => x.TrangThai == true).FirstOrDefault(x => x.IdKH == id);
            if (gh == null) { return null; }
            var ctgh = CTGHangDAO.GetByIdGH(gh.Id);
            var gioHangE = new GioHangEntity();
            gioHangE.Id = id;
            gioHangE.IdKH = gh.IdKH;
            gioHangE.NgayTao = gh.NgayTao;
            gioHangE.TrangThai = gh.TrangThai;
            gioHangE.cTGHangs = ctgh;
            return gioHangE;
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
