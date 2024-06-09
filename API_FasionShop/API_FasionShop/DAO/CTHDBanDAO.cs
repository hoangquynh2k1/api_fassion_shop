using API_FashionShop.Entities;
using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class CTHDBanDAO
    {
        AppDBContext db;
        public CTHDBanDAO(AppDBContext db)
        {
            this.db = db;
        }
        public List<CTHDBan> Gets()
        {
            return db.CTHDBans.ToList();
        }
        public List<CTHDBanEntity> GetByIdHDBan(int id)
        {
            var list = db.CTHDBans.Where(x => x.IdHDBan == id).ToList();
            var listCTHDBan = new List<CTHDBanEntity>();
            CTHDBanEntity ct;
            CTSPham? ctsp;
            SanPham sp;
            for (int i = 0; i < list.Count; i++)
            {
                ct = new CTHDBanEntity();
                ct.IdCTSPham = list[i].IdCTSPham;
                ct.IdHDBan = list[i].IdHDBan;
                ctsp = db.CTSPhams.FirstOrDefault(x => x.Id == list[i].IdCTSPham)!;
                sp = db.SanPhams.FirstOrDefault(x => x.Id == ctsp.IdSanPham)!;
                ct.HinhAnh = sp.HinhAnh1!;
                ct.TenSP = sp.TenSP!;
                ct.Size = ctsp.Size;
                ct.SoLuong = list[i].SoLuong;
                ct.MauSac = ctsp.MauSac!;
                listCTHDBan.Add(ct);
            }

            return listCTHDBan;
        }
        public List<CTHDBanReport> GetIdCTSPSeller()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-60);
            var idhd = db.HDBans.Where(x => x.NgayTao >= thirtyDaysAgo).Select(x => x.Id).ToList();
            var list = db.CTHDBans.Where(x => idhd.Contains(x.IdHDBan)).ToList().GroupBy(x => x.IdCTSPham)
                .Select( x => new CTHDBanReport()
                {
                    IdCTSPham = x.Key,
                    SoLuong = x.Sum(y => y.SoLuong)
                }).OrderByDescending(x => x.SoLuong).ToList();
            return list;
        }
        public CTHDBan? Get(int id)
        {
            return db.CTHDBans.FirstOrDefault(x => x.Id == id);
        }
        public bool Create(CTHDBan o)
        {
            var result = db.CTHDBans.Add(o);
            if(result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(CTHDBan o)
        {
            var result = db.CTHDBans.First(x => x.Id == o.Id);
            if (result != null)
            {
                result.IdHDBan = o.IdHDBan;
                result.IdCTSPham = o.IdCTSPham;
                result.SoLuong = o.SoLuong;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var result = db.CTHDBans.First(x => x.Id == id);
            if (result != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
