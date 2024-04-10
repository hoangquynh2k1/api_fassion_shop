using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        BaiVietBUS baiVietBUS;
        public BaiVietController(AppDBContext db)
        {
            baiVietBUS = new BaiVietBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, baiVietBUS.Gets());
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            return new Respone(true, Status.Success, string.Empty, baiVietBUS.Get(id));
        }
        [HttpPost]
        public Respone Create(BaiViet o)
        {
            try
            {
                if (o.TieuDe == string.Empty || o.NoiDung == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = baiVietBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty);
            }
        }

        [HttpPut("{id}")]
        public Respone Upfate(int id, BaiViet o)
        {
            try
            {
                if (o.TieuDe == string.Empty || o.NoiDung == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = baiVietBUS.Update(o);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty);
            }
        }

        [HttpDelete]
        public Respone Delete(int id)
        {
            try
            {
                var result = baiVietBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty);
            }
        }
    }
}
