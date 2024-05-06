using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChiTietSPController : ControllerBase
    {
        ChiTietSPBUS chiTietSPBUS;
        public ChiTietSPController(AppDBContext db)
        {
            chiTietSPBUS = new ChiTietSPBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty,chiTietSPBUS.Gets());
        }
        [HttpGet]
        public Respone Search()
        {
            return new Respone(true, Status.Success, string.Empty, chiTietSPBUS.Gets());
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = chiTietSPBUS.Get(id);
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
        public Respone Create(CTSPham o)
        {
            try
            {
                if (o.SoLuong < 0 || o.Size == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = chiTietSPBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, CTSPham o)
        {
            try
            {
                if (o.SoLuong > 0 || o.Size == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = chiTietSPBUS.Update(o);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public Respone GetByIdSP(int id)
        {
            try
            {
                var result = chiTietSPBUS.GetByIdSP(id);
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
                var result = chiTietSPBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
    }
}
