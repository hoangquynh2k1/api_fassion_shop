using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CTHDBanController : ControllerBase
    {
        CTHDBanBUS cthdbanBUS;
        public CTHDBanController(AppDBContext db)
        {
            cthdbanBUS = new CTHDBanBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, cthdbanBUS.Gets());
        }
        [HttpGet]
        public Respone Search()
        {
            return new Respone(true, Status.Success, string.Empty, cthdbanBUS.Gets());
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = cthdbanBUS.Get(id);
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
        public Respone Create(CTHDBan o)
        {
            try
            {
                if (o.SoLuong != 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = cthdbanBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, CTHDBan o)
        {
            try
            {
                if (o.SoLuong != 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = cthdbanBUS.Update(o);
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
                var result = cthdbanBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
    }
}
