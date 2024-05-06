using API_FashionShop.Entities;
using API_FashionShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        FileService fileService = new FileService();

        [HttpPost("Upload/Avatar")]
        public async Task<Respone> UploadAvartar(IFormFile f)
        {
            try
            {
                var result = await fileService.Upload(f, "Avatars");
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }

        [HttpPost("Upload/Product")]
        public async Task<Respone> UploadProduct(IFormFile f)
        {
            try
            {
                var result = await fileService.Upload(f, "Products");
                return new Respone(true, Status.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new Respone(false, Status.ApplicationError, string.Empty, ex.Message);
            }
        }

        [HttpGet("ReadFile")]
        public ActionResult ReadFile(string path)
        {
            try
            {
                var result = fileService.Read(path);
                return File(result, "image/jpeg");
                //return new Respone(true, Status.Success, string.Empty, a);
            }
            catch (Exception ex)
            {
                return Ok(null);
            }
        }
    }
}
