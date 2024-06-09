using API_FashionShop.Entities;
using API_FashionShop.Models;

namespace API_FashionShop.DAO
{
    public class HDBanDAO
    {
        AppDBContext db;
        CTHDBanDAO CTHDBanDAO;
        KhachHangDAO khachHangDAO;
        NhanVienDAO nhanVienDAO;
        DiaChiDAO diaChiDAO;
        public HDBanDAO(AppDBContext db)
        {
            this.db = db;
            CTHDBanDAO = new CTHDBanDAO(db);
            khachHangDAO = new KhachHangDAO(db);
            nhanVienDAO = new NhanVienDAO(db);
            diaChiDAO = new DiaChiDAO(db);
        }
        public List<HDBanEntity> Gets()
        {
            var list = db.HDBans.Where(x => x.TrangThai).ToList();
            List<HDBanEntity> result = new List<HDBanEntity>();
            HDBanEntity hDBan;
            for (int i = 0; i < list.Count; i++)
            {
                hDBan = Get(list[i].Id);
                result.Add(hDBan);
            }
            return result;
        }
        public List<Statistic> GetStatistic()
        {
            var result = db.HDBans.Where(x => x.TrangThai == true && x.NgayTao > DateTime.Now.AddMonths(-5))
                .OrderByDescending(x => x.NgayTao).ToList();
            var list = new List<Statistic>();
            var item = result[0];
            Statistic s = new Statistic();
            s.Name = item.NgayTao.Month + "/" + item.NgayTao.Year;
            s.Value = item.TongTien;
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i].NgayTao.Month == item.NgayTao.Month)
                {
                    if (i == result.Count - 1)
                    {
                        s.Value = s.Value + result[i].TongTien;
                        list.Add(s);
                    }
                    s.Value = s.Value + result[i].TongTien;
                    item = result[i];
                }
                else
                {
                    list.Add(s);
                    s = new Statistic();
                    s.Name = result[i].NgayTao.Month + "/" + result[i].NgayTao.Year;
                    s.Value = result[i].TongTien;
                    item = result[i];
                    if (i == result.Count - 1)
                    {
                        list.Add(s);
                    }
                }
            }
            return list;
        }
        public HDBanEntity? Get(int id)
        {
            var hd = db.HDBans.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
            if (hd == null) { return null; }
            var cthd = CTHDBanDAO.GetByIdHDBan(id);
            var kh = khachHangDAO.Get(hd.IdKH);
            var nv = nhanVienDAO.Get(hd.IdNV);
            var hdBanE = new HDBanEntity();
            var dc = diaChiDAO.Get(hd.IdDiaChi);
            hdBanE.Id = id;
            hdBanE.TenKH = kh.HoTen;
            hdBanE.Email = kh.Email;
            hdBanE.TenNV = nv != null ? nv.HoTen : "";
            hdBanE.DiaChi = dc;
            hdBanE.GhiChu = hd.GhiChu;
            hdBanE.NgayTao = hd.NgayTao;
            hdBanE.KhuyenMai = hd.KhuyenMai;
            hdBanE.TongTien = hd.TongTien;
            hdBanE.TinhTrangDH = hd.TinhTrangDH;
            hdBanE.CTHDBans = cthd;
            hdBanE.TrangThai = hd.TrangThai;
            return hdBanE;
        }
        public List<HDBanEntity> GetByIdHKH(int id)
        {
            var list = db.HDBans.Where(x => x.TrangThai == true && x.IdKH == id).ToList();
            List<HDBanEntity> result = new List<HDBanEntity>();
            HDBanEntity hDBan;
            for(int i = 0; i < list.Count; i++)
            {
                hDBan = Get(list[i].Id);
                result.Add(hDBan);
            }
            return result;
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
                result.IdNV = o.IdNV;
                result.TrangThai = o.TrangThai;
                result.TinhTrangDH = o.TinhTrangDH;
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
