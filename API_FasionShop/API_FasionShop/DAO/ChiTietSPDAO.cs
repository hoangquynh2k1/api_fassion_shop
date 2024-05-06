using API_FashionShop.Entities;
using API_FashionShop.Models;
using System.Collections.Generic;

namespace API_FashionShop.DAO
{
    public class ChiTietSPDAO
    {
        AppDBContext db;
        CTHDBanDAO cthDBanDAO;
        public ChiTietSPDAO(AppDBContext db)
        {
            this.db = db;
            cthDBanDAO = new CTHDBanDAO(db);
        }
        public List<int> GetBestSellerList()
        {
            var list = cthDBanDAO.GetIdCTSPSeller();
            var idSPs = new List<BestSeller>();
            foreach (var ct in list)
            {
                var idsp = db.CTSPhams.FirstOrDefault(x => x.Id == ct.IdCTSPham)?.IdSanPham;
                if (idsp != null)
                {
                    var existingSP = idSPs.FirstOrDefault(x => x.IdSp == idsp);
                    if (existingSP != null)
                    {
                        existingSP.SoLuong += ct.SoLuong; // Tăng số lượng nếu sản phẩm đã tồn tại
                    }
                    else
                    {
                        idSPs.Add(new BestSeller() { IdSp = idsp.Value, SoLuong = ct.SoLuong }); // Thêm sản phẩm mới vào danh sách
                    }
                }
            }
            var idBestSeller = idSPs.OrderByDescending(x => x.SoLuong).Select(x => x.IdSp).ToList();
            return idBestSeller;
        }

        public List<CTSPham> Gets()
        {
            return db.CTSPhams.Where(x => x.TrangThai == true).ToList();
        }
        public CTSPham? Get(int id)
        {
            return db.CTSPhams.Where(x => x.TrangThai == true).FirstOrDefault(x => x.Id == id);
        }

        public List<CTSPham> GetByIdSP(int id)
        {
            return db.CTSPhams.Where(x => x.TrangThai == true && x.IdSanPham == id).ToList();
        }

        public bool Create(CTSPham o)
        {
            var result = db.CTSPhams.Add(o);
            if(result != null)
            {
                db.CTSPhams.Add(o);
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
