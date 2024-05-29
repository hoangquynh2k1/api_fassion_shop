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

        [HttpGet]
        public ActionResult SendMail(string email)
        {
            string emailHTML = " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">" +
                "<tr>    <td align=\"center\">        " +
                "<img src=\"https://cdn.tgdd.vn/Products/Images/522/163645/ipad-6th-wifi-32gb-1-400x460.png\" alt=\"ipad 2018\" width=\"280\" height=\"218\" border=\"0\" style=\"display: block;\" />    " +
                "</td>    </tr>    <tr>    " +
                "<td align=\"center\">        ipad 2019    </td>    </tr>    " +
                "<tr>    <td align=\"center\">        8500000vnd    " +
                "</td>    </tr>    <tr>    <td align=\"center\" class=\"link\">        " +
                "<a border=\"0\" href=\"#\" style=\"text-decoration:none;display:inline-block;color:#000000;background-color:#f6d16c;border-radius:0px;-webkit-border-radius:0px;-moz-border-radius:0px;width:auto; width:auto;;border-top:1px solid #f6d16c;border-right:1px solid #f6d16c;border-bottom:1px solid #f6d16c;border-left:1px solid #f6d16c;padding-top:1px;padding-bottom:2px;font-family:Merriwheater, Georgia, serif;text-align:center;mso-border-alt:none;word-break:keep-all;\">  " +
                "<span style=\"padding-left:10px;padding-right:10px;font-size:12px;display:inline-block;\">            Chi tiết        </span>" +
                "</a>    </td>    </tr></table>";
            var result = sendMailService.SendEmailAsync(email,"", emailHTML);
            return Ok(result);
        }
    }
}
