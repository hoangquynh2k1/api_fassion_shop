using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        LoaiSPBUS loaiSPBUS;
        public LoaiSPController(AppDBContext db)
        {
            loaiSPBUS = new LoaiSPBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, loaiSPBUS.Gets());
        }
        [HttpPost]
        public Respone Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = string.Empty;
                if (formData.Keys.Contains("tenLoai") && !string.IsNullOrEmpty(Convert.ToString(formData["tenLoai"])))
                { loc = formData["tenLoai"].ToString(); }
                List<LoaiSP> list = loaiSPBUS.Gets();
                long total = list.Count();
                list = list.Where(x => x.TenLoai!.ToLower().Contains(loc.ToLower())
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
                var result = loaiSPBUS.Get(id);
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
        public Respone Create(LoaiSP o)
        {
            try
            {
                if (o.TenLoai == string.Empty || o.TenLoai == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = loaiSPBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, LoaiSP o)
        {
            try
            {
                if (o.TenLoai == string.Empty || o.MoTa == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = loaiSPBUS.Update(o);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }

        [HttpDelete]
        public Respone Delete(int id)
        {
            try
            {
                var result = loaiSPBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
    }
}
