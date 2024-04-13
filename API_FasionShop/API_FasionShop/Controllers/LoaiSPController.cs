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
        [HttpGet]
        public Respone Search()
        {
            return new Respone(true, Status.Success, string.Empty, loaiSPBUS.Gets());
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
