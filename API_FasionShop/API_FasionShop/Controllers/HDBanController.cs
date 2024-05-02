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
    public class HDBanController : ControllerBase
    {
        HDBanBUS hDBanBUS;
        PaymentService paymentService = new PaymentService();
        public HDBanController(AppDBContext db)
        {
            hDBanBUS = new HDBanBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, hDBanBUS.Gets());
        }
        [HttpGet]
        public Respone Search()
        {
            return new Respone(true, Status.Success, string.Empty, hDBanBUS.Gets());
        }
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = hDBanBUS.Get(id);
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
        public Respone Create(HDBan o)
        {
            try
            {
                if (o.KhuyenMai != 0 || o.TongTien > 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = hDBanBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, HDBan o)
        {
            try
            {
                if (o.KhuyenMai != 0 || o.TongTien > 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = hDBanBUS.Update(o);
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
                var result = hDBanBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }

        [HttpGet]
        public ActionResult CreatePayment(string amout, string info)
        {
            try
            {
                var result = paymentService.Genarate(amout, info);
                return File(result, "image/png");
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
