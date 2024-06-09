using API_FashionShop.BUS;
using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        KhuyenMaiBUS khuyenmaiBUS;
        public KhuyenMaiController(AppDBContext db)
        {
            khuyenmaiBUS = new KhuyenMaiBUS(db);
        }
        [HttpGet]
        public Respone GetAll()
        {
            return new Respone(true, Status.Success, string.Empty, khuyenmaiBUS.Gets());
        }
        [HttpPost]
        public Respone Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = string.Empty;
                string email = string.Empty;
                if (formData.Keys.Contains("discountId") && !string.IsNullOrEmpty(Convert.ToString(formData["discountId"])))
                { loc = formData["hoTen"].ToString(); }
                List<KhuyenMai> list = khuyenmaiBUS.Gets();
                long total = list.Count();
                list = list.Where(x => x.DiscountId.ToLower().Contains(loc.ToLower())
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
        [HttpGet]
        public Respone CheckDiscount(string discountID)
        {
            try
            {
                var result = khuyenmaiBUS.CheckDiscount(discountID);
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
        [HttpGet("{id}")]
        public Respone GetById(int id)
        {
            try
            {
                var result = khuyenmaiBUS.Get(id);
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
        public Respone Create(KhuyenMai o)
        {
            try
            {
                if (o.TiLeKM < 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = khuyenmaiBUS.Create(o);
                return new Respone(true, Status.Success, string.Empty, o);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public Respone Update(int id, KhuyenMai o)
        {
            try
            {
                if (o.TiLeKM < 0)
                    return new Respone(false, Status.BadRequest, string.Empty);
                var result = khuyenmaiBUS.Update(o);
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
                var result = khuyenmaiBUS.Delete(id);
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex);
            }
        }
    }
}
