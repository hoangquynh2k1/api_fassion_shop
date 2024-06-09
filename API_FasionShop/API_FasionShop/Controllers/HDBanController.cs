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
        ISendMailService sendMailService;
        public HDBanController(AppDBContext db, ISendMailService sendMailService)
        {
            hDBanBUS = new HDBanBUS(db);
            this.sendMailService = sendMailService;
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, hDBanBUS.Gets());
        }
        [HttpPost]
        public Respone Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = string.Empty;
                //kiểm tra và gán giá trị loc nếu có trong formData
                List<HDBanEntity> list = hDBanBUS.Gets();
                long total = list.Count();
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
        [HttpGet]
        public Respone GetStatistic()
        {
            try
            {
                var result = hDBanBUS.GetStatistic();
                result.Reverse();
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
                if (o.KhuyenMai < 0 || o.TongTien < 0)
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
                if (o.KhuyenMai < 0 || o.TongTien < 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = hDBanBUS.Update(o);
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

        [HttpPost]
        public ActionResult SendMail([FromQuery] string email, [FromBody] HDBanEntity hdb)
        {
            string emailHTML = MailHTML.RenderHTML(hdb);
            try
            {
                sendMailService.SendEmailAsync(email,"Thông báo xác nhận đặt hàng", emailHTML);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
