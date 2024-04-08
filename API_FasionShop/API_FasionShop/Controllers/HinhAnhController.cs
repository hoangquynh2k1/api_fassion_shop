using API_FasionShop.Models;
using APITest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FasionShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhAnhController : ControllerBase
    {
        private readonly AppDBContext _dBContext;
        public HinhAnhController(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(HinhAnh hinhAnh)
        //{
        //    _dBContext.HinhAnhs.Add(hinhAnh);
        //    await _dBContext.SaveChangesAsync();
        //    return Ok(hinhAnh);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var anhs = await _dBContext.HinhAnhs.ToListAsync();
        //    return Ok(anhs);
        //}
    }
}
