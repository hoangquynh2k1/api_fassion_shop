using API_FashionShop.Entities;
using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class CTGHangDAO
    {
        AppDBContext db;
        public CTGHangDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<CTGHang> Gets()
        {
            return db.CTGHangs.ToList();
        }
        public List<CTGHangEntity> GetByIdGH(int id)
        {
            var list = db.CTGHangs.Where(x => x.IdGh == id).ToList();
            var listCTGHang = new List<CTGHangEntity>();
            CTGHangEntity ct;
            CTSPham? ctsp;
            SanPham sp;
            for (int i = 0; i < list.Count; i ++)
            {
                ct = new CTGHangEntity();
                ct.Id = list[i].Id;
                ct.IdCTSP = list[i].IdCTSP;
                ct.IdGh = list[i].IdGh;
                ct.SoLuong = list[i].SoLuong;
                ctsp = db.CTSPhams.FirstOrDefault(x => x.Id == list[i].IdCTSP)!;
                sp = db.SanPhams.FirstOrDefault(x => x.Id == ctsp.IdSanPham)!;
                ct.HinhAnh = sp.HinhAnh1!;
                ct.TenSP = sp.TenSP!;
                ct.Gia = sp.Gia;
                ct.Size = ctsp.Size;
                ctsp.MauSac = ctsp.MauSac;
                listCTGHang.Add(ct);
            }    
            return listCTGHang;
        }
        public CTGHang? Get(int id)
        {
            return db.CTGHangs.FirstOrDefault(x => x.Id == id);
        }
        public bool Create(CTGHang o)
        {
            var result = db.CTGHangs.Add(o);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(CTGHang o)
        {
            var result = db.CTGHangs.First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdGh = o.IdGh;
                result.IdCTSP = o.IdCTSP;
                result.SoLuong = o.SoLuong;
                result.Size = o.Size;
                result.MauSac = o.MauSac;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.CTGHangs.First(x => x.Id == id);
            if (result != null)
            {
                db.CTGHangs.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
