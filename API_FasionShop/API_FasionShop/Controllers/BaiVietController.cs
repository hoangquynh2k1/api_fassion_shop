using API_FashionShop.BUS;
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
        public List<BaiViet> GetAll()
        {
            return baiVietBUS.Gets();
        }
    }
}
