using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using API_FashionShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        SanPhamBUS sanPhamBUS;
        FileService fileService;
        public SanPhamController(AppDBContext db)
        {
            sanPhamBUS = new SanPhamBUS(db);
            fileService = new FileService();
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, sanPhamBUS.Gets());
        }
        [HttpGet]
        public Respone GetBestSeller()
        {
            try
            {
                var result = sanPhamBUS.GetBestSeller();
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet]
        public Respone GetNews()
        {
            try
            {
                var result = sanPhamBUS.Gets().OrderByDescending(x => x.Id).ToList();
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet]
        public Respone GetLabel()
        {
            try
            {
                var result = sanPhamBUS.GetLabel();
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPost]
        public Respone Search([FromBody] Dictionary<string, object> formData)
        {
            try
            
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = string.Empty;
                string thuongHieu = string.Empty;
                int IdLoaiSP = int.Parse( formData["idloaiSP"].ToString());
                if (formData.Keys.Contains("tenSP") && !string.IsNullOrEmpty(Convert.ToString(formData["tenSP"])))
                { loc = formData["tenSP"].ToString(); }
                if (formData.Keys.Contains("thuongHieu") && !string.IsNullOrEmpty(Convert.ToString(formData["thuongHieu"])))
                { thuongHieu = formData["thuongHieu"].ToString(); }
                List<SanPham> list = sanPhamBUS.Gets();
                long total = list.Count();
                if (IdLoaiSP > 0)
                    list = list.Where(x => x.IdLoaiSP == IdLoaiSP).ToList();
                if (thuongHieu != string.Empty)
                    list = list.Where(x => x.ThuongHieu!.ToLower().Contains(thuongHieu.ToLower())).ToList();
                list = list.Where(x => x.TenSP!.ToLower().Contains(loc.ToLower())).ToList();
                list = list.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
                return new Respone(true, Status.Success, string.Empty,
                           new DataSearch
                           {
                               page = page,
                               totalItem = total,
                               pageSize = pageSize,
                               data = list
                           }
                         );
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public Respone GetByID(int id)
        {
            try
            {
                var result = sanPhamBUS.Get(id);
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public Respone GetRelated(int id)
        {
            try
            {
                var result = sanPhamBUS.GetRelated(id);
                if (result == null)
                {
                    return new Respone(false, Status.NotFound);
                }
                return new Respone(true, Status.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPost]
        public Respone Create(SanPham o)
        {
            try
            {
                if (o.TenSP == string.Empty || o.MoTa == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = sanPhamBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, SanPham o)
        {
            try
            {
                if (o.TenSP == string.Empty || o.MoTa == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = sanPhamBUS.Update(o);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public Respone Delete(int id)
        {
            try
            {
                var result = sanPhamBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
        [HttpPost]
        public async Task<Respone> Upload(IFormFile f)
        {
            try
            {
                var result = await fileService.Upload(f, "Products");
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet]
        public ActionResult ReadFile(string path)
        {
            try
            {
                var result = fileService.Read(path);
                return File(result, "image/jpeg");
                //return new Respone(true, Status.Success, string.Empty, a);
            }
            catch (Exception ex)
            {
                //return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
                return null;
            }
        }
    }
}
