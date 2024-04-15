using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        NhanVienBUS nhanvienBUS;
        public NhanVienController(AppDBContext db)
        {
            nhanvienBUS = new NhanVienBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, nhanvienBUS.Gets());
        }
        [HttpGet]
        public Respone Search()
        {
            return new Respone(true, Status.Success, string.Empty, nhanvienBUS.Gets());
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = nhanvienBUS.Get(id);
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
        public Respone Create(NhanVien o)
        {
            try
            {
                if (o.SoDT == string.Empty || o.Email == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = nhanvienBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, NhanVien o)
        {
            try
            {
                if (o.SoDT == string.Empty || o.Email == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result =nhanvienBUS.Update(o);
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
                var result = nhanvienBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
    }
}
