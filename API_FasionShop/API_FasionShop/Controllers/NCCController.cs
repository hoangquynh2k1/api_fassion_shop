using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NCCController : ControllerBase
    {
        NCCBUS nccBUS;
        public NCCController(AppDBContext db)
        {
            nccBUS = new NCCBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, nccBUS.Gets());
        }
        [HttpGet]
        public Respone Search()
        {
            return new Respone(true, Status.Success, string.Empty, nccBUS.Gets());
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = nccBUS.Get(id);
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
        public Respone Create(Ncc o)
        {
            try
            {
                if (o.TenNCC == string.Empty || o.Email == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = nccBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, Ncc o)
        {
            try
            {
                if (o.TenNCC == string.Empty || o.Email == string.Empty)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = nccBUS.Update(o);
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
                var result = nccBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
    }
}
