using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using API_FashionShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        BaiVietBUS baiVietBUS;
        FileService fileService;
        public BaiVietController(AppDBContext db)
        {
            baiVietBUS = new BaiVietBUS(db);
            fileService = new FileService();
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, baiVietBUS.Gets());
        }
        [HttpPost]
        public Respone Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = string.Empty;
                if (formData.Keys.Contains("tieuDe") && !string.IsNullOrEmpty(Convert.ToString(formData["tieuDe"])))
                { loc = formData["tieuDe"].ToString(); }
                List<BaiViet> list = baiVietBUS.Gets();
                long total = list.Count();
                list = list.Where(x => x.TieuDe!.ToLower().Contains(loc.ToLower())
                ).
                    Skip(pageSize * (page - 1)).Take(pageSize).ToList();
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
        public Respone GetById(int id)
        {
            try
            {
                var result = baiVietBUS.Get(id);
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
        public Respone Create(BaiViet o)
        {
            try
            {
                if (o.TieuDe == string.Empty )
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = baiVietBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public Respone Update(int id, BaiViet o)
        {
            try
            {
                if (o.TieuDe == string.Empty )
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = baiVietBUS.Update(o);
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
                var result = baiVietBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPost]
        public async Task<Respone> Upload(IFormFile f)
        {
            try
            {
                var result = await fileService.Upload(f, "Posts");
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
