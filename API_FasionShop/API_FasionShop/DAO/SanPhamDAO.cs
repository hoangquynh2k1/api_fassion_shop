using API_FashionShop.Entities;
using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class SanPhamDAO
    {
        AppDBContext db;
        ChiTietSPDAO cTSPhamDAO;
        public SanPhamDAO(AppDBContext db)
        {
            this.db = db;
            cTSPhamDAO = new ChiTietSPDAO(db);
        }
        public List<SanPham> Gets()
        {
            return db.SanPhams.Where(x => x.TrangThai == true).ToList();
        }
        public List<SanPham> GetBestSeller()
        {
            var list = cTSPhamDAO.GetBestSellerList();
            return db.SanPhams.Where(x => list.Contains(x.Id)).ToList();
        }
        public List<string> GetLabel()
        {
            var list = db.SanPhams.Where(x => x.TrangThai == true).GroupBy(x => x.ThuongHieu).Select(x => new string(x.Key))
                .ToList();
            return list;
        }
        public List<SanPham> GetRelated(int id)
        {
            var sp = db.SanPhams.FirstOrDefault(x => x.Id == id);
            var list = db.SanPhams.Where(x => (x.TrangThai == true && x.IdLoaiSP == sp.IdLoaiSP)).ToList();
            list.Remove(sp);
            list.Take(4);
            return list;
        }
        public SanPhamEntity? Get(int id)
        {
            var sp = db.SanPhams.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
            if (sp == null) { return null; }
            var ctsp = db.CTSPhams.Where(x => x.IdSanPham == id && x.TrangThai == true).ToList();
            var sanPhamE = new SanPhamEntity();
            sanPhamE.Id = id;
            sanPhamE.IdLoaiSP = sp.IdLoaiSP;
            sanPhamE.TenSP = sp.TenSP;
            sanPhamE.MoTa = sp.MoTa;
            sanPhamE.Gia = sp.Gia;
            sanPhamE.HinhAnh = sp.HinhAnh1;
            sanPhamE.CTSPhams = ctsp;
            return sanPhamE;
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
                result.IdLoaiSP = o.IdLoaiSP;
                result.TenSP = o.TenSP;
                result.MoTa = o.MoTa;
                result.ThuongHieu = o.ThuongHieu;
                result.ChatLieu = o.ChatLieu;
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
